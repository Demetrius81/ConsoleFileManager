using System;
using System.IO;

namespace FileManager
{
    /// <summary>
    /// Класс директивы перемещения директории
    /// </summary>
    internal class DirectiveRD : Directive, IDirective
    {
        private string _directiveName = "RD";

        public string DirectiveName { get => _directiveName; }

        public Varibles RunDirective(Varibles varibles)
        {
            SVarible = varibles;

            RemoveDirectoryCommandExecuter();

            return varibles;
        }

        /// <summary>
        /// Метод перемещает директорию
        /// </summary>
        /// <param name="pathFrom">string Путь откуда перемещать</param>
        /// <param name="pathTo">string Путь куда перемещать</param>
        public static void RemoveDirectoryCommandExecuter()
        {
            if (SVarible.Command.Split().Length == 3)
            {
                string pathFrom = SVarible.Command.Split()[1];

                string pathTo = SVarible.Command.Split()[2];

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
