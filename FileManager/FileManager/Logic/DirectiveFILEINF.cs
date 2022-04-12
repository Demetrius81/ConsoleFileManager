using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    internal class DirectiveFILEINF : IDirective
    {
        private const string _directiveName = "FILEINF";

        public string DirectiveName { get => _directiveName; }

        public void RunDirective(params string[] args)
        {
            StartDirective(args[0]);
        }


        /// <summary>
        /// Метод выводит в консоль данные о выбранном файле
        /// </summary>
        public static void FilePropertiesCommandExecuter()
        {
            FileInfo file;

            string[] commands = UserCommands.Command.Split();

            if (commands.Length == 2)
            {
                if ((commands[1].Contains(":\\") || commands[1].Contains(":/")) && commands[1].Contains('.'))
                {
                    file = new FileInfo(commands[1]);

                    try
                    {
                        if (file.Exists)
                        {
                            PseudoConsoleUI.PrintFileProperties(file);
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
                    file = new FileInfo($"{UserCommands.DrivesAndDirs.CuttentDirectory}\\{commands[1]}");

                    try
                    {
                        if (file.Exists)
                        {
                            PseudoConsoleUI.PrintFileProperties(file);
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
