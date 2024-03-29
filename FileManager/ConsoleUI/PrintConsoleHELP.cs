﻿using System;

namespace FileManager
{
    internal class PrintConsoleHELP : PrintConsole, IPrintConsole
    {
        public string Name => "HELP";

        public Varibles StartPrint(Varibles varibles)
        {
            SysVaribles = varibles;

            PrintHelp();

            return SysVaribles;
        }

        /// <summary>
        /// Метод выводит на экран Help - лист
        /// </summary>
        private static void PrintHelp()
        {
            Console.WriteLine();

            foreach (string row in SysVaribles.Files)
            {
                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                Console.WriteLine(row);
            }
            Console.WriteLine();
        }
    }
}
