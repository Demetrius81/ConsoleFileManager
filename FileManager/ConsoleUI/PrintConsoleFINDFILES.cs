using System;

namespace FileManager
{
    internal class PrintConsoleFINDFILES : PrintConsole, IPrintConsole
    {
        public string Name => "FINDFILES";

        public Varibles StartPrint(Varibles varibles)
        {
            SysVaribles = varibles;

            PrintAllFindedFiles();

            return SysVaribles;
        }

        /// <summary>
        /// Метод выводит в консоль список всех найденых файлов
        /// </summary>
        private static void PrintAllFindedFiles()
        {
            string r;

            Console.WriteLine();

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine(@"Список найденых файлов:");

            Console.WriteLine();

            for (int i = 0; i < SysVaribles.DrivesDirFilesArray.Files.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                Console.Write($"{ SysVaribles.DrivesDirFilesArray.Files[i].FullName}");

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                Console.Write($"{SysVaribles.DrivesDirFilesArray.Files[i].Length} Bytes");

                Console.SetCursorPosition(30, Console.BufferHeight - 1);

                Console.Write($"{ SysVaribles.DrivesDirFilesArray.Files[i].CreationTime:HH-mm-ss dd-MM-yyyy}");

                Console.SetCursorPosition(50, Console.BufferHeight - 1);

                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.Write($"{ SysVaribles.DrivesDirFilesArray.Files[i].Attributes}");

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine();
            }
        }
    }
}
