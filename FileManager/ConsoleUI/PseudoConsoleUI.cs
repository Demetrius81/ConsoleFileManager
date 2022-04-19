using System;

namespace FileManager
{
    /// <summary>
    /// Класс, который содержит методы вывода информации на консоль
    /// </summary>
    public class PseudoConsoleUI
    {
        /// <summary>
        /// Константа запроса на ввод информации
        /// </summary>
        public const string INPUT_REQUEST = @">";

        /// <summary>
        /// Наименование окна
        /// </summary>
        public const string TILDE = "Проект \"Файловый менеджер\"";

        /// <summary>
        /// Длина строки для вывода списка процессов
        /// </summary>
        public const int LENGTH_LINE = 75;

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

        #region For delete

        ///// <summary>
        ///// Метод выводит на экран скопированные файлы
        ///// </summary>
        //public static void ShowCopyCommand(List<string> files)
        //{
        //    Console.SetCursorPosition(0, Console.BufferHeight - 1);

        //    Console.WriteLine();

        //    Console.SetCursorPosition(0, Console.BufferHeight - 1);

        //    Console.WriteLine($"Sucsessfully copied {files.Count / 2} files:");

        //    for (int i = 0; i < files.Count; i += 2)
        //    {
        //        Console.SetCursorPosition(0, Console.BufferHeight - 1);

        //        Console.WriteLine($"Copy {files[i]} to {files[i + 1]} is done.");
        //    }
        //    Console.WriteLine();
        //}

        #endregion

        #region For delete


        ///// <summary>
        ///// Метод выводит на экран состояние текущей директории
        ///// </summary>
        ///// <param name="dirFiles">DrivesAndDirectories актуальное состояние программы</param>
        //public static void PrintDirectoryProrerties(CurrentDrivesAndDirs dirFiles)
        //{
        //    Console.SetCursorPosition(0, Console.BufferHeight - 1);

        //    Console.WriteLine();

        //    Console.SetCursorPosition(0, Console.BufferHeight - 1);

        //    Console.ForegroundColor = ConsoleColor.DarkGray;

        //    Console.Write($"Текущая директория: ");

        //    Console.ForegroundColor = ConsoleColor.Magenta;

        //    Console.Write($"{dirFiles.CuttentDirectory.FullName}");

        //    Console.ForegroundColor = ConsoleColor.DarkGray;

        //    Console.Write($" содержит: ");

        //    Console.ForegroundColor = ConsoleColor.Magenta;

        //    Console.Write($"{dirFiles.CuttentDirectory.GetFiles().Length}");

        //    Console.ForegroundColor = ConsoleColor.DarkGray;

        //    Console.Write($" файлов,");

        //    Console.ForegroundColor = ConsoleColor.Magenta;

        //    Console.WriteLine();

        //    Console.SetCursorPosition(0, Console.BufferHeight - 1);

        //    Console.ForegroundColor = ConsoleColor.DarkGray;

        //    Console.Write($"имеет атрибуты: ");

        //    Console.ForegroundColor = ConsoleColor.Magenta;

        //    Console.Write($"{dirFiles.CuttentDirectory.Attributes}");

        //    Console.ForegroundColor = ConsoleColor.DarkGray;

        //    Console.Write($", Время создания: ");

        //    Console.ForegroundColor = ConsoleColor.Magenta;

        //    Console.Write($"{dirFiles.CuttentDirectory.CreationTime:dd-MM-yyyy HH-mm-ss}");

        //    Console.ForegroundColor = ConsoleColor.White;

        //    Console.SetCursorPosition(0, Console.BufferHeight - 1);

        //    Console.WriteLine();
        //}

        #endregion

        #region For delete

        ///// <summary>
        ///// Метод выводит на экран Help - лист
        ///// </summary>
        //public static void WriteHelp(List<string> list)
        //{
        //    Console.WriteLine();

        //    foreach (string row in list)
        //    {
        //        Console.SetCursorPosition(0, Console.BufferHeight - 1);

        //        Console.WriteLine(row);
        //    }
        //    Console.WriteLine();

        //}

        #endregion

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
        public static void SetCursorPosition(CurrentDrivesAndDirs temp)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.Write(temp.CuttentDirectory + INPUT_REQUEST);
        }
        
        /// <summary>
        /// Метод запрашивает сведения о процессе
        /// </summary>
        public static void RequestToEnterProcess(string proc)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine(proc);

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine(@"для выхода введите пустую строку");

            SetCursorPositionForProcesses();
        }
        
        /// <summary>
        /// Метод перещает курсор на указанную позицию для работы с процессами
        /// </summary>
        private static void SetCursorPositionForProcesses()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.Write(PseudoConsoleUI.INPUT_REQUEST);
        }
    }
}
