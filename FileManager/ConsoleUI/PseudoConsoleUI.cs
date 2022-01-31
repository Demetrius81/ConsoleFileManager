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
        public const int BUFFER_HEIGTH = 300;

        /// <summary>
        /// Ширина окна
        /// </summary>
        public const int WINDOW_WIDTH = 160;

        /// <summary>
        /// Высота окна
        /// </summary>
        public const int WINDOW_HEIGTH = 50;

        /// <summary>
        /// Стандартный цвет текста консоли
        /// </summary>
        public static ConsoleColor coloFontDefault = ConsoleColor.White;

        /// <summary>
        /// Цвет текста консоли для предупреждений о отчета об ошибках
        /// </summary>
        public static ConsoleColor colorWarning = ConsoleColor.DarkRed;
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
        public static void WriteAllSubdirectoriesAndFiles(DrivesAndDirectories.DrivesDirectoriesFilesArray dirFiles)
        {

            FileInfo[] files = dirFiles.Files;

            DirectoryInfo[] subdirectories = dirFiles.Directories;

            Console.WriteLine();

            foreach (DirectoryInfo subdir in subdirectories)
            {
                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                Console.Write($"{subdir.FullName}");

                Console.SetCursorPosition(70, Console.BufferHeight - 1);

                Console.Write($"{subdir.CreationTime}");

                Console.WriteLine();
            }
            foreach (FileInfo file in files)
            {
                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                Console.Write($"{ Path.GetFileNameWithoutExtension(file.FullName)}");

                Console.SetCursorPosition(25, Console.BufferHeight - 1);

                Console.Write($"{ Path.GetExtension(file.FullName)}");

                Console.SetCursorPosition(30, Console.BufferHeight - 1);

                Console.Write($"{file.Length} Bytes");

                Console.SetCursorPosition(70, Console.BufferHeight - 1);

                Console.Write($"{ file.CreationTime}");

                Console.SetCursorPosition(90, Console.BufferHeight - 1);

                Console.Write($"{ file.Attributes}");

                Console.WriteLine();
            }

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
        public static void SetCursorPosition(string temp)
        {
            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.Write(temp + INPUT_REQUEST);
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
