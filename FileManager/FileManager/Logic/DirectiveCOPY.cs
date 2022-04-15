using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    internal class DirectiveCOPY : Directive, IDirective
    {
        private const string _directiveName = "COPY";
        public string DirectiveName { get => _directiveName; }

        public Varibles RunDirective(Varibles varibles)
        {
            NameToSerch = DirectiveName;

            SVarible = varibles;

            CopyCommandExecuter();            

            DirectivesConsole();

            PrintDirectiveSelection();

            return SVarible;
        }
        

        /// <summary>
        /// Метод копирует файлы или директории по указанному пути
        /// </summary>
        /// <returns>На выходе список скопированных файлов</returns>
        public static void CopyCommandExecuter()
        {
            string[] commands = FileManager.Varibles.Command.Split();

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
            FileManager.Varibles.Files.Clear();

            FileManager.Varibles.Files.AddRange(files);
        }
    }
}
