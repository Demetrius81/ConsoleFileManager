using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    internal class DirectiveRD : IDirective
    {
        private const string _directiveName = "MOVE";
        public string DirectiveName { get => _directiveName; }

        public void RunDirective(params string[] args)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Метод перемещает директорию
        /// </summary>
        /// <param name="pathFrom">string Путь откуда перемещать</param>
        /// <param name="pathTo">string Путь куда перемещать</param>
        public static void RemoveDirectoryCommandExecuter(string pathFrom, string pathTo)
        {
            if (UserCommands.Command.Split().Length == 3)
            {
                if ((pathFrom.Contains(":\\") || pathFrom.Contains(":/")) && !pathFrom.Contains('.')
                    && !pathTo.Contains('.') && (pathTo.Contains(":\\") || pathTo.Contains(":/")))
                {
                    DirectoryInfo directory = new DirectoryInfo(pathFrom);

                    try
                    {
                        if (directory.Exists)
                        {
                            directory.MoveTo(pathTo);
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








    }
}
