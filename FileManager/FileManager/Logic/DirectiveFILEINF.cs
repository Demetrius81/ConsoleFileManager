using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
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



        private static void PrintFilePropertiesRun()
        {
            DirectivesConsole();

            PrintDirectiveSelection();
        }






    }
}
