using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

                Console.Write($"{ Path.GetFileNameWithoutExtension(SysVaribles.DrivesDirFilesArray.Files[i].FullName)}");

                Console.SetCursorPosition(25, Console.BufferHeight - 1);

                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.Write($"{ Path.GetExtension(SysVaribles.DrivesDirFilesArray.Files[i].FullName)}");

                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(30, Console.BufferHeight - 1);

                Console.Write($"{SysVaribles.DrivesDirFilesArray.Files[i].Length} Bytes");

                Console.SetCursorPosition(70, Console.BufferHeight - 1);

                Console.Write($"{ SysVaribles.DrivesDirFilesArray.Files[i].CreationTime:HH-mm-ss dd-MM-yyyy}");

                Console.SetCursorPosition(90, Console.BufferHeight - 1);

                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.Write($"{ SysVaribles.DrivesDirFilesArray.Files[i].Attributes}");

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine();
            }
        }
    }
}
