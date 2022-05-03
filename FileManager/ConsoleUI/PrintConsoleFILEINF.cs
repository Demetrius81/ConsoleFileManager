using System;

namespace FileManager.ConsoleUI
{
    internal class PrintConsoleFILEINF : PrintConsole, IPrintConsole
    {
        public string Name => "FILEINF";

        public Varibles StartPrint(Varibles varibles)
        {
            SysVaribles = varibles;

            PrintFileProperties();

            return SysVaribles;
        }

        /// <summary>
        /// Метод выводит в консоль параметры полученного файла
        /// </summary>        
        private static void PrintFileProperties()
        {
            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine();

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($"Информация по файлу: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{SysVaribles.VarFile.FullName}");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($" размер: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{SysVaribles.VarFile.Length} Байт");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine();

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($"имеет атрибуты: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{SysVaribles.VarFile.Attributes}");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($", Время создания: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{SysVaribles.VarFile.CreationTime:dd-MM-yyyy HH-mm-ss}");

            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine();
        }
    }
}
