using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    internal class DirectiveMOVE : Directive, IDirective
    {
        private const string _directiveName = "MOVE";

        public string DirectiveName { get => _directiveName; }

        public Varibles RunDirective(Varibles varibles)
        {
            SVarible = varibles;

            MoveCommandExecuter();

            return varibles;
        }

        /// <summary>
        /// Метод перемещает каталог со всем содержимым или файл
        /// </summary>
        /// <param name="pathFrom">string Путь откуда перемешать</param>
        /// <param name="pathTo">string Путь куда перемешать</param>
        public static void MoveCommandExecuter()
        {


            if (SVarible.Command.Split().Length == 3)
            {
                string pathFrom = SVarible.Command.Split()[1];

                string pathTo = SVarible.Command.Split()[2];

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
