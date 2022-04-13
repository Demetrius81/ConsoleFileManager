﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    internal class DirectiveDIR : IDirective
    {
        private const string _directiveName = "DIR";
        public string DirectiveName { get => _directiveName; }

        public void RunDirective(params string[] args)
        {
            throw new NotImplementedException();
        }







        public static void ShowAllSubdirectoriesAndFilesByPages()
        {
            DrivesDirectoriesFilesArray dirFiles = ShowAllSubdirectoriesAndFilesCommandExecuter();

            string[] commands = SystemVaribles.Command.Split();

            bool isOk = false;

            int page = -1;

            if (commands.Length == 3)
            {
                isOk = int.TryParse(commands[2], out page);
            }
            if (commands.Length == 3 && isOk && commands[1] == "-P" && page > 0)
            {
                ShowAllSubdirectoriesAndFilesLogic(dirFiles, page);
            }
            if (commands.Length == 2 && (commands[1] == "\\\\" || commands[1] == "//"))
            {
                ShowAllDrivesLogic();
            }
            if (commands.Length == 1)
            {
                ShowAllSubdirectoriesAndFilesLogic(dirFiles, page);
            }

        }


        /// <summary>
        /// Метод выводит в консоль все подкаталоги и файлы текущего каталога
        /// </summary>
        /// <returns>DrivesDirectoriesFilesArray Объект, в котором находятся данные о подкаталогах и файлах текущего каталога</returns>
        public static DrivesDirectoriesFilesArray ShowAllSubdirectoriesAndFilesCommandExecuter()
        {
            DrivesDirectoriesFilesArray dirFiles = new DrivesDirectoriesFilesArray();

            DirectoryInfo ddd = SystemVaribles.DrivesAndDirs.CuttentDirectory;

            dirFiles.Directories = ddd.GetDirectories();

            dirFiles.Files = ddd.GetFiles();

            return (dirFiles);
        }


        /// <summary>
        /// Метод содержит в себе логику постраничного вывода на экран списка каталогов и файлов
        /// </summary>
        /// <param name="dirFiles">DrivesAndDirectories актуальное состояние программы</param>
        /// <param name="userPage">int Номер страницы</param>
        public static void ShowAllSubdirectoriesAndFilesLogic(DrivesDirectoriesFilesArray dirFiles, int userPage)
        {
            FileInfo[] files = dirFiles.Files;

            DirectoryInfo[] subdirectories = dirFiles.Directories;

            int dirStart = 0;

            int dirStop = 0;

            int fileStart = 0;

            int fileStop = 0;

            int allLinesDir = subdirectories.Length;

            int allLinesFile = files.Length;

            int allLines = allLinesDir + allLinesFile;

            if (userPage == -1)
            {
                dirStart = 0;

                dirStop = allLinesDir;

                fileStart = 0;

                fileStop = allLinesFile;
            }
            else
            {
                int pageDir = 1 + allLinesDir / PseudoConsoleUI.PAGE_LINES;

                int restDirLines = allLinesDir % PseudoConsoleUI.PAGE_LINES;

                int linesOfFileAfterDir = PseudoConsoleUI.PAGE_LINES - restDirLines;

                int filesdir = (allLinesFile - linesOfFileAfterDir) / PseudoConsoleUI.PAGE_LINES + 1;

                if (userPage < pageDir)
                {
                    dirStart = (userPage - 1) * PseudoConsoleUI.PAGE_LINES;

                    dirStop = userPage * PseudoConsoleUI.PAGE_LINES;
                }
                if (userPage == pageDir)
                {
                    if ((restDirLines + allLinesFile) / PseudoConsoleUI.PAGE_LINES == 0)
                    {
                        dirStart = (userPage - 1) * PseudoConsoleUI.PAGE_LINES;

                        dirStop = allLinesDir;

                        fileStop = allLinesFile;
                    }
                    if ((restDirLines + allLinesFile) / PseudoConsoleUI.PAGE_LINES > 0)
                    {
                        dirStart = (userPage - 1) * PseudoConsoleUI.PAGE_LINES;

                        dirStop = allLinesDir;

                        fileStop = linesOfFileAfterDir;
                    }
                }
                if (userPage > pageDir)
                {
                    if (userPage < (pageDir + filesdir))
                    {
                        fileStart = linesOfFileAfterDir + (userPage - pageDir - 1) * PseudoConsoleUI.PAGE_LINES;

                        fileStop = linesOfFileAfterDir + (userPage - pageDir) * PseudoConsoleUI.PAGE_LINES;
                    }
                    if (userPage >= (pageDir + filesdir))
                    {
                        fileStart = linesOfFileAfterDir + (userPage - pageDir - 1) * PseudoConsoleUI.PAGE_LINES;

                        fileStop = allLinesFile;
                    }
                }
            }
            PseudoConsoleUI.PrintAllSubdirectoriesAndFilesByPages(dirFiles, dirStart, dirStop, fileStart, fileStop);

            PseudoConsoleUI.PrintPageNumber(allLines, userPage);
        }






        /// <summary>
        /// Метод создает массив логических дисков
        /// </summary>
        public static void ShowAllDrivesLogic()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            PseudoConsoleUI.PrintAllDrives(drives);
        }














    }
}
