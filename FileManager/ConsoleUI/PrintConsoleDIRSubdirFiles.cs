using System;
using System.IO;

namespace FileManager.ConsoleUI
{
    internal class PrintConsoleDIRSubdirFiles : PrintConsole, IPrintConsole
    {
        public string Name => "DIRSDF";

        public Varibles StartPrint(Varibles varibles)
        {
            SysVaribles = varibles;

            ShowAllSubdirectoriesAndFilesLogic();

            return SysVaribles;
        }

        /// <summary>
        /// Метод содержит в себе логику постраничного вывода на экран списка каталогов и файлов
        /// </summary>
        private static void ShowAllSubdirectoriesAndFilesLogic()
        {
            FileInfo[] files = SysVaribles.DrivesAndDirs.CuttentDirectory.GetFiles();

            DirectoryInfo[] subdirectories = SysVaribles.DrivesAndDirs.CuttentDirectory.GetDirectories();

            int dirStart = 0;

            int dirStop = 0;

            int fileStart = 0;

            int fileStop = 0;

            int allLinesDir = SysVaribles.DrivesAndDirs.CuttentDirectory.GetDirectories().Length;

            int allLinesFile = SysVaribles.DrivesAndDirs.CuttentDirectory.GetFiles().Length;

            int allLines = allLinesDir + allLinesFile;

            if (SysVaribles.UserPage == -1)
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

                if (SysVaribles.UserPage < pageDir)
                {
                    dirStart = (SysVaribles.UserPage - 1) * PseudoConsoleUI.PAGE_LINES;

                    dirStop = SysVaribles.UserPage * PseudoConsoleUI.PAGE_LINES;
                }
                if (SysVaribles.UserPage == pageDir)
                {
                    if ((restDirLines + allLinesFile) / PseudoConsoleUI.PAGE_LINES == 0)
                    {
                        dirStart = (SysVaribles.UserPage - 1) * PseudoConsoleUI.PAGE_LINES;

                        dirStop = allLinesDir;

                        fileStop = allLinesFile;
                    }
                    if ((restDirLines + allLinesFile) / PseudoConsoleUI.PAGE_LINES > 0)
                    {
                        dirStart = (SysVaribles.UserPage - 1) * PseudoConsoleUI.PAGE_LINES;

                        dirStop = allLinesDir;

                        fileStop = linesOfFileAfterDir;
                    }
                }
                if (SysVaribles.UserPage > pageDir)
                {
                    if (SysVaribles.UserPage < (pageDir + filesdir))
                    {
                        fileStart = linesOfFileAfterDir + (SysVaribles.UserPage - pageDir - 1) * PseudoConsoleUI.PAGE_LINES;

                        fileStop = linesOfFileAfterDir + (SysVaribles.UserPage - pageDir) * PseudoConsoleUI.PAGE_LINES;
                    }
                    if (SysVaribles.UserPage >= (pageDir + filesdir))
                    {
                        fileStart = linesOfFileAfterDir + (SysVaribles.UserPage - pageDir - 1) * PseudoConsoleUI.PAGE_LINES;

                        fileStop = allLinesFile;
                    }
                }
            }
            PrintAllSubdirectoriesAndFilesByPages(dirStart, dirStop, fileStart, fileStop);

            PrintPageNumber(allLines);
        }

        /// <summary>
        /// Метод выводит на экран все подкаталоги и файлы текущего каталога
        /// </summary>
        /// <param name="dirFiles">DrivesAndDirectories актуальное состояние программы</param>
        /// <param name="dirStart">int первый каталог на странице</param>
        /// <param name="dirStop">int крайний каталог на странице</param>
        /// <param name="fileStart">int первый файл на странице</param>
        /// <param name="fileStop">int крайний файл на странице</param>
        private static void PrintAllSubdirectoriesAndFilesByPages(int dirStart, int dirStop, int fileStart, int fileStop)
        {
            FileInfo[] files = SysVaribles.DrivesAndDirs.CuttentDirectory.GetFiles();

            DirectoryInfo[] subdirectories = SysVaribles.DrivesAndDirs.CuttentDirectory.GetDirectories();

            Console.WriteLine();

            for (int i = dirStart; i < dirStop; i++)
            {
                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                Console.Write($"{subdirectories[i].Name}");

                Console.SetCursorPosition(20, Console.BufferHeight - 1);

                Console.ForegroundColor = ConsoleColor.DarkGray;

                Console.Write($"<DIR>");

                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(30, Console.BufferHeight - 1);

                Console.Write($"{subdirectories[i].CreationTime:dd-MM-yyyy}");

                Console.WriteLine();
            }
            for (int i = fileStart; i < fileStop; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                Console.Write($"{ Path.GetFileNameWithoutExtension(files[i].FullName)}");

                Console.SetCursorPosition(25, Console.BufferHeight - 1);

                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.Write($"{ Path.GetExtension(files[i].FullName)}");

                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(30, Console.BufferHeight - 1);

                Console.Write($"{files[i].Length} Bytes");

                Console.SetCursorPosition(70, Console.BufferHeight - 1);

                Console.Write($"{ files[i].CreationTime:HH-mm-ss dd-MM-yyyy}");

                Console.SetCursorPosition(90, Console.BufferHeight - 1);

                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.Write($"{ files[i].Attributes}");

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод выводит на экран текущий номер страницы
        /// </summary>
        /// <param name="allLines">int количество всех подкаталогов и файлов в каталоге</param>
        private static void PrintPageNumber(int allLines)
        {
            if (SysVaribles.UserPage != -1)
            {
                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                int p = SysVaribles.UserPage > (1 + allLines / PseudoConsoleUI.PAGE_LINES) ? (1 + allLines / PseudoConsoleUI.PAGE_LINES) : SysVaribles.UserPage;

                Console.Write($"Страница {p} из {(1 + allLines / PseudoConsoleUI.PAGE_LINES)}");
            }
        }
    }
}
