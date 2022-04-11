using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    internal class DirectiveDEL : IDirective
    {
        private const string _directiveName = "DEL";
        public string DirectiveName { get => _directiveName; }

        public void RunDirective(params string[] args)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// Метод удаляет каталог с файлами, если там нет подкаталога или файл
        /// </summary>
        public static void DeleteCommandExecuter()
        {
            string[] pathArr = UserCommands.Command.Split();

            if ((pathArr[1].Contains(":\\") || pathArr[1].Contains(":/")) && pathArr[1].Split('\\', '/').Length == 1)
            {
                return;
            }

            FileInfo file = new FileInfo(pathArr[1]);

            DirectoryInfo directory = new DirectoryInfo(pathArr[1]);

            try
            {
                if (directory.Exists)
                {
                    DirectoryInfo[] directories = directory.GetDirectories();

                    if (directories.Length == 0)
                    {
                        directory.Delete(true);
                    }
                }
                else if (file.Exists)
                {
                    file.Delete();
                }
            }
            catch (Exception ex)
            {
                Exeptions.ShowException(ex);

                Exeptions.ExceptionInFile(ex);

                return;
            }
        }


    }
}
