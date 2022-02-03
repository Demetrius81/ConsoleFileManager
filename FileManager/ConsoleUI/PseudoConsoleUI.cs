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
        /// <param name="dirFiles">DrivesAndDirectories актуальное состояние программы</param>
        /// <param name="dirStart">int первый каталог на странице</param>
        /// <param name="dirStop">int крайний каталог на странице</param>
        /// <param name="fileStart">int первый файл на странице</param>
        /// <param name="fileStop">int крайний файл на странице</param>
        public static void WriteAllSubdirectoriesAndFilesByPages(DrivesDirectoriesFilesArray dirFiles, int dirStart, int dirStop, int fileStart, int fileStop)
        {
            FileInfo[] files = dirFiles.Files;

            DirectoryInfo[] subdirectories = dirFiles.Directories;

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
        /// <param name="userPage">int страница</param>
        public static void PrintPageNumber(int allLines, int userPage)
        {
            if (userPage != -1)
            {
                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                int p = userPage > (1 + allLines / PAGE_LINES) ? (1 + allLines / PAGE_LINES) : userPage;

                Console.Write($"Страница {p} из {(1 + allLines / PAGE_LINES)}");
            }
        }

        /// <summary>
        /// Метод выводит в консоль параметры полученного файла
        /// </summary>
        /// <param name="file">FileInfo файл, параметры которого нужно изучить</param>
        public static void PrintFileProperties(FileInfo file)
        {
            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine();

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($"Информация по файлу: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{file.FullName}");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($" размер: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{file.Length} Байт");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine();

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($"имеет атрибуты: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{file.Attributes}");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($", Время создания: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{file.CreationTime:dd-MM-yyyy HH-mm-ss}");

            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine();
        }



        /// <summary>
        /// Метод выводит на экран состояние текущей директории
        /// </summary>
        /// <param name="dirFiles">DrivesAndDirectories актуальное состояние программы</param>
        public static void PrintDirectoryProrerties(DrivesAndDirectories dirFiles)
        {
            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine();

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($"Текущая директория: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{dirFiles.CuttentDirectory.FullName}");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($" содержит: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{dirFiles.CuttentDirectory.GetFiles().Length}");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($" файлов,");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine();

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($"имеет атрибуты: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{dirFiles.CuttentDirectory.Attributes}");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($", Время создания: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{dirFiles.CuttentDirectory.CreationTime:dd-MM-yyyy HH-mm-ss}");

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
