using System;

namespace FileManager
{
    internal class PrintConsoleCD : PrintConsole, IPrintConsole
    {
        public string Name => "CD";

        public Varibles StartPrint(Varibles varibles)
        {
            SysVaribles = varibles;

            PrintDirectoryProrerties();

            return SysVaribles;
        }


        /// <summary>
        /// Метод выводит на экран состояние текущей директории
        /// </summary>
        /// <param name="dirFiles">DrivesAndDirectories актуальное состояние программы</param>
        private static void PrintDirectoryProrerties()
        {
            CurrentDrivesAndDirs dirFiles = SysVaribles.DrivesAndDirs;

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
    }
}
