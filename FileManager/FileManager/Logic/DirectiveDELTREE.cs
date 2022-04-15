using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    internal class DirectiveDELTREE : Directive, IDirective
    {

        private const string _directiveName = "DELTREE";
        public string DirectiveName { get => _directiveName; }

        public Varibles RunDirective(Varibles varibles)
        {
            Varibles = varibles;

            DeleteTreeCommandExecuter();

            return Varibles;
        }


        /// <summary>
        /// Метод рекурсивно удаляет каталог и все подкаталоги и файлы
        /// </summary>
        /// <param name="path">string Путь к удаляемому каталогу</param>
        public static void DeleteTree(string path)
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
        public static void DeleteTreeCommandExecuter()
        {
            string[] commandsStringArray = Varibles.Command.Split();

            if (commandsStringArray.Length == 1)
            {
                string path = Varibles.DrivesAndDirs.CuttentDirectory.ToString();

                DirectiveCD dirCD = new DirectiveCD();

                Varibles.Command = "CD ..";

                Varibles = dirCD.RunDirective(Varibles);

                DeleteTree(path);
            }
            else if (commandsStringArray.Length == 2)
            {
                DeleteTree(commandsStringArray[1]);
            }
        }


    }
}
