using System;
using System.IO;

namespace FileManager
{
    /// <summary>
    /// Класс директивы рекурсивного удаления дерева каталогов
    /// </summary>
    internal class DirectiveDELTREE : Directive, IDirective
    {
        private const string _directiveName = "DELTREE";
        public string DirectiveName { get => _directiveName; }

        public Varibles RunDirective(Varibles varibles)
        {
            SVarible = varibles;

            DeleteTreeCommandExecuter();

            return SVarible;
        }


        /// <summary>
        /// Метод рекурсивно удаляет каталог и все подкаталоги и файлы
        /// </summary>
        /// <param name="path">string Путь к удаляемому каталогу</param>
        private static void DeleteTree(string path)
        {
            if ((path.Contains(":\\") || path.Contains(":/")) && path.Split('\\', '/').Length == 1)
            {
                return;
            }
            DirectoryInfo directory = new DirectoryInfo(path);
            try
            {
                if (directory.Exists)
                {
                    DirectoryInfo[] directories = directory.GetDirectories();

                    foreach (DirectoryInfo dir in directories)
                    {
                        FileInfo[] files = dir.GetFiles();
                        foreach (FileInfo file in files)
                        {
                            if (file.Exists)
                            {
                                file.Delete();
                            }
                        }
                        DeleteTree(dir.FullName);
                    }
                    directory.Delete(false);
                }
            }
            catch (Exception ex)
            {
                Exeptions.ShowException(ex);

                Exeptions.ExceptionInFile(ex);

                return;
            }
        }

        /// <summary>
        /// Метод в зависимости от команды двумя разными способами рекурсивно
        /// удаляет каталог и все подкаталоги и файлы
        /// </summary>
        private static void DeleteTreeCommandExecuter()
        {
            string[] commandsStringArray = SVarible.Command.Split();

            if (commandsStringArray.Length == 1)
            {
                string path = SVarible.DrivesAndDirs.CuttentDirectory.ToString();

                DirectiveCD dirCD = new DirectiveCD();

                SVarible.Command = "CD ..";

                SVarible = dirCD.RunDirective(SVarible);

                DeleteTree(path);
            }
            else if (commandsStringArray.Length == 2)
            {
                DeleteTree(commandsStringArray[1]);
            }
        }
    }
}
