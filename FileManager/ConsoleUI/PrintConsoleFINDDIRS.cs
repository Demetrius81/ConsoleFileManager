using System;

namespace FileManager
{
    internal class PrintConsoleFINDDIRS : PrintConsole, IPrintConsole    
    {
        public string Name => "FINDDIRS";

        public Varibles StartPrint(Varibles varibles)
        {
            SysVaribles = varibles;

            PrintAllFindedDirs();

            return SysVaribles;
        }

        /// <summary>
        /// Метод выводит в консоль список всех найденых директорий
        /// </summary>        
        private static void PrintAllFindedDirs()
        {
            string r;

            Console.WriteLine();

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine(@"Список найденых директорий:");

            Console.WriteLine();

            for (int i = 0; i < SysVaribles.DrivesDirFilesArray.Directories.Length; i++)
            {
                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                Console.Write($"{SysVaribles.DrivesDirFilesArray.Directories[i].FullName}");

                Console.SetCursorPosition(40, Console.BufferHeight - 1);

                Console.ForegroundColor = ConsoleColor.DarkGray;

                Console.Write($"<DIR>");

                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(50, Console.BufferHeight - 1);

                Console.Write($"{SysVaribles.DrivesDirFilesArray.Directories[i].CreationTime:dd-MM-yyyy}");

                Console.WriteLine();
            }
        }























    }
}
