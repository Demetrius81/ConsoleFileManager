using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    internal class DirectiveMOVE : IDirective
    {
        private const string _directiveName = "MOVE";
        public string DirectiveName { get => _directiveName; }

        public void RunDirective(params string[] args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод перемещает каталог со всем содержимым или файл
        /// </summary>
        /// <param name="pathFrom">string Путь откуда перемешать</param>
        /// <param name="pathTo">string Путь куда перемешать</param>
        public static void MoveCommandExecuter(string pathFrom, string pathTo)
        {
            if (UserCommands.Command.Split().Length == 3)
            {
                if ((pathFrom.Contains(":\\") || pathFrom.Contains(":/"))
                    && (pathTo.Contains(":\\") || pathTo.Contains(":/")))
                {
                    FileInfo file = new FileInfo(pathFrom);

                    DirectoryInfo directory = new DirectoryInfo(pathFrom);

                    try
                    {
                        if (directory.Exists)
                        {
                            directory.MoveTo(pathTo);
                        }
                        else if (file.Exists)
                        {
                            file.MoveTo(pathTo);
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
