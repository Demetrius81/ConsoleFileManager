using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    internal class DirectiveCOPY : IDirective
    {
        private const string _directiveName = "COPY";
        public string DirectiveName { get => _directiveName; }

        void IDirective.RunDirective(params string[] args)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Метод выводит на экран скопированные файлы
        /// </summary>
        public static void ShowCopyCommand(List<string> files)
        {
            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine();

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine($"Sucsessfully copied {files.Count / 2} files:");

            for (int i = 0; i < files.Count; i += 2)
            {
                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                Console.WriteLine($"Copy {files[i]} to {files[i + 1]} is done.");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод копирует файлы или директории по указанному пути
        /// </summary>
        /// <returns>На выходе список скопированных файлов</returns>
        public static List<string> CopyCommandExecuter()
        {
            string[] commands = UserCommands.Command.Split();

            List<string> files = new List<string>();

            if (commands.Length > 3 && (commands[commands.Length - 1].Contains(":\\") || commands[commands.Length - 1].Contains(":/")))
            {
                for (int i = 1; i < commands.Length - 1; i++)
                {
                    if (File.Exists(commands[i]))
                    {
                        try
                        {
                            string[] path = commands[i].Split('\\', '/');

                            File.Copy(commands[i], $"{commands[commands.Length - 1]}\\{path[path.Length - 1]}", false);

                            files.Add(commands[i]);

                            files.Add($"{commands[commands.Length - 1]}\\{path[path.Length - 1]}");
                        }
                        catch (Exception ex)
                        {
                            Exeptions.ShowException(ex);

                            Exeptions.ExceptionInFile(ex);
                        }
                    }
                }
            }
            return files;
        }



    }
}
