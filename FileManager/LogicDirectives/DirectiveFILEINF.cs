using System;
using System.IO;

namespace FileManager
{
    /// <summary>
    /// Класс директивы информации о файле
    /// </summary>
    internal class DirectiveFILEINF : Directive, IDirective
    {
        private const string _directiveName = "FILEINF";

        public string DirectiveName { get => _directiveName; }

        public Varibles RunDirective(Varibles varibles)
        {
            NameToSerch = DirectiveName;

            SVarible = varibles;

            PrintFilePropertiesRun();

            return SVarible;
        }

        /// <summary>
        /// Метод выводит в консоль данные о выбранном файле
        /// </summary>
        public static void FilePropertiesCommandExecuter()
        {
            string[] commands = SVarible.Command.Split();

            if (commands.Length == 2)
            {
                if ((commands[1].Contains(":\\") || commands[1].Contains(":/")) && commands[1].Contains('.'))
                {
                    SVarible.VarFile = new FileInfo(commands[1]);

                    try
                    {
                        if (SVarible.VarFile.Exists)
                        {
                            PrintFilePropertiesRun();
                        }
                    }
                    catch (Exception ex)
                    {
                        Exeptions.ShowException(ex);

                        Exeptions.ExceptionInFile(ex);

                        return;
                    }
                }
                if (!commands[1].Contains(":\\") && !commands[1].Contains(":/") && !commands[1].Contains("/") && !commands[1].Contains("\\") && commands[1].Contains('.'))
                {
                    SVarible.VarFile = new FileInfo($"{SVarible.DrivesAndDirs.CuttentDirectory}\\{commands[1]}");

                    try
                    {
                        if (SVarible.VarFile.Exists)
                        {
                            PrintFilePropertiesRun();
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

        /// <summary>
        /// Метод запускает процесс вывода в консоль свойств файла
        /// </summary>
        private static void PrintFilePropertiesRun()
        {
            DirectivesConsole();

            PrintDirectiveSelection();
        }
    }
}
