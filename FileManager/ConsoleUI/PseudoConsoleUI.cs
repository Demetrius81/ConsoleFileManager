using System;
using System.Collections.Generic;
using System.IO;

namespace FileManager
{
    /// <summary>
    /// Класс, который содержит методы вывода информации на консоль
    /// </summary>
    public class PseudoConsoleUI
    {
        #region Fields and properties

        /// <summary>
        /// Константа запроса на ввод информации
        /// </summary>
        public const string INPUT_REQUEST = @">";

        /// <summary>
        /// Наименование окна
        /// </summary>
        public const string TILDE = "Проект \"Файловый менеджер\"";

        /// <summary>
        /// Ширина Буфера
        /// </summary>
        public const int BUFFER_WIDTH = 160;

        /// <summary>
        /// Высота буфера
        /// </summary>
        public const int BUFFER_HEIGTH = 50;

        /// <summary>
        /// Ширина окна
        /// </summary>
        public const int WINDOW_WIDTH = 160;

        /// <summary>
        /// Высота окна
        /// </summary>
        public const int WINDOW_HEIGTH = 50;

        /// <summary>
        /// Количество строк в странице
        /// </summary>
        public const int PAGE_LINES = 40;

        #endregion

        /// <summary>
        /// Метод выводит на экран скопированные файлы
        /// </summary>
        public static void ShowCopyCommand(List<string> files)
        {
            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine();

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine($"Sucsessfully copied {files.Count / 2} files:");

            for (int i = 0; i < files.Count; i += 2)
            {
                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                Console.WriteLine($"Copy {files[i]} to {files[i + 1]} is done.");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод выводит на экран все подкаталоги и файлы текущего каталога
        /// </summary>
        /// /// <param name="dir">DrivesAndDirectories актуальное состояние программы</param>
        public static void WriteAllSubdirectoriesAndFiles(DrivesDirectoriesFilesArray dirFiles)
        {

            FileInfo[] files = dirFiles.Files;

            DirectoryInfo[] subdirectories = dirFiles.Directories;

            Console.WriteLine();

            foreach (DirectoryInfo subdir in subdirectories)
            {
                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                Console.Write($"{subdir.Name}");

                Console.SetCursorPosition(20, Console.BufferHeight - 1);

                Console.ForegroundColor = ConsoleColor.DarkGray;

                Console.Write($"<DIR>");

                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(30, Console.BufferHeight - 1);

                Console.Write($"{subdir.CreationTime:dd-MM-yyyy}");

                Console.WriteLine();
            }
            foreach (FileInfo file in files)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                Console.Write($"{ Path.GetFileNameWithoutExtension(file.FullName)}");

                Console.SetCursorPosition(25, Console.BufferHeight - 1);

                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.Write($"{ Path.GetExtension(file.FullName)}");

                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(30, Console.BufferHeight - 1);

                Console.Write($"{file.Length} Bytes");

                Console.SetCursorPosition(70, Console.BufferHeight - 1);

                Console.Write($"{ file.CreationTime:HH-mm-ss dd-MM-yyyy}");

                Console.SetCursorPosition(90, Console.BufferHeight - 1);

                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.Write($"{ file.Attributes}");

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод выводит на экран все подкаталоги и файлы текущего каталога
        /// </summary>
        /// /// <param name="dir">DrivesAndDirectories актуальное состояние программы</param>
        /// <param name="page">int Номер страницы</param>
        public static void WriteAllSubdirectoriesAndFilesByPages(DrivesDirectoriesFilesArray dirFiles, int userPage)
        {
            FileInfo[] files = dirFiles.Files;

            DirectoryInfo[] subdirectories = dirFiles.Directories;

            int dirStart = 0;

            int dirStop = 0;

            int fileStart = 0;

            int fileStop = 0;

            int allLinesDir = subdirectories.Length;

            int allLinesFile = files.Length;

            if (userPage == -1)
            {
                dirStart = 0;

                dirStop = allLinesDir;

                fileStart = 0;

                fileStop = allLinesFile;
            }
            else
            {
                int pageDir = allLinesDir / PAGE_LINES;

                //int pageFiles = allLinesFile / PAGE_LINES;

                int restDirLines = allLinesDir % PAGE_LINES;

                int linesOfFileAfterDir = PAGE_LINES - restDirLines;

                int countPages = (allLinesDir + allLinesFile) % PAGE_LINES != 0 ?
                    (allLinesDir + allLinesFile) / PAGE_LINES + 1 : (allLinesDir + allLinesFile) / PAGE_LINES;

                int pageToPrint = userPage > countPages ? countPages : userPage;


                if ((userPage < pageDir) || (userPage == pageDir && (allLinesDir % PAGE_LINES == 0)))
                {
                    dirStart = (userPage - 1) * PAGE_LINES;

                    dirStop = userPage * PAGE_LINES;
                }
                if (userPage == pageDir && (allLinesDir % PAGE_LINES > 0))
                {
                    if ((restDirLines + allLinesFile) / PAGE_LINES == 0)
                    {
                        dirStart = (userPage - 1) * PAGE_LINES;

                        dirStop = (userPage) * PAGE_LINES;

                        fileStop = allLinesFile;
                    }
                    if ((restDirLines + allLinesFile) / PAGE_LINES > 0)
                    {
                        dirStart = (userPage - 1) * PAGE_LINES;

                        dirStop = (userPage) * PAGE_LINES;

                        fileStop = linesOfFileAfterDir;
                    }
                }
                if (userPage > pageDir && userPage < pageToPrint)
                {
                    fileStart = linesOfFileAfterDir + ((userPage - pageDir + 1) - 1) * PAGE_LINES;

                    fileStop = linesOfFileAfterDir + ((userPage - pageDir + 1)) * PAGE_LINES;
                }
                if (userPage > pageDir && userPage == pageToPrint)
                {
                    fileStart = linesOfFileAfterDir + ((userPage - pageDir + 1) - 1) * PAGE_LINES;

                    fileStop = allLinesFile;
                }
            }
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
        /// Метод выводит на экран состояние текущей директории
        /// </summary>
        /// <param name="dir">DrivesAndDirectories актуальное состояние программы</param>
        public static void PrintDirectoryProrerties(DrivesAndDirectories dir)
        {
            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine();

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($"Текущая директория: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{dir.CuttentDirectory.FullName}");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($" содержит: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{dir.CuttentDirectory.GetFiles().Length}");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($" файлов,");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine();

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($"имеет атрибуты: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{dir.CuttentDirectory.Attributes}");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($", Время создания: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{dir.CuttentDirectory.CreationTime:dd-MM-yyyy HH-mm-ss}");

            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine();
        }

        /// <summary>
        /// Метод выводит на экран Help - лист
        /// </summary>
        public static void WriteHelp(List<string> list)
        {
            Console.WriteLine();

            foreach (string row in list)
            {
                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                Console.WriteLine(row);
            }
            Console.WriteLine();

        }

        /// <summary>
        /// Метод задает размеры окна и буфера консоли
        /// </summary>
        public static void WindowSettings()
        {
            Console.Title = TILDE;

            Console.SetBufferSize(BUFFER_WIDTH, BUFFER_HEIGTH);

            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGTH);
        }

        /// <summary>
        /// метод перемещает курсор на указанную позицию
        /// </summary>
        /// /// <param name="dir">DrivesAndDirectories актуальное состояние программы</param>
        public static void SetCursorPosition(DrivesAndDirectories temp)
        {
            //PrintDirectoryProrerties(temp);

            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.Write(temp.CuttentDirectory + INPUT_REQUEST);
        }

        /// <summary>
        /// Метод выводит на экран сообщения о возникающих ошибках
        /// </summary>
        /// <param name="ex">Exception Объект, содержащий в себе данные об ошибке</param>
        public static void ShowException(Exception ex)
        {
            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine(ex.ToString());

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
