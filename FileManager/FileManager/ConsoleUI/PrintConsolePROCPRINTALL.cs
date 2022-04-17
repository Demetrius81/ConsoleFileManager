using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FileManager.ConsoleUI
{
    internal class PrintConsoleProcPrintAll : PrintConsole, IPrintConsole
    {
        public string Name => "PROCPRINTALL";

        public Varibles StartPrint(Varibles varibles)
        {
            SysVaribles = varibles;

            PrintProcesses();

            return SysVaribles;
        }


        /// <summary>
        /// Метод выводит в консоль все процессы
        /// </summary>
        /// <param name="process"></param>
        public static void PrintProcesses()
        {
            Process[] process = SysVaribles.TaskManager.GetAllProcesses();

            Console.Clear();

            int pgNum = 1;

            for (int i = 0; i < process.Length; i++)
            {
                string str = "";

                int stringLength = process[i].ProcessName.Length + Convert.ToString(process[i].Id).Length;

                if (stringLength < PseudoConsoleUI.LENGTH_LINE)
                {
                    for (int j = 0; j < PseudoConsoleUI.LENGTH_LINE - stringLength; j++)
                    {
                        str = str + ".";
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                Console.WriteLine($" {String.Format("{0:d4}", i)} {process[i].ProcessName}{str}{process[i].Id}");

                if (i == pgNum * (PseudoConsoleUI.PAGE_LINES - 1))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;

                    Console.SetCursorPosition(0, Console.BufferHeight - 1);

                    Console.WriteLine($"Страница {pgNum}. Для продолжения нажмите любую клавишу...");

                    Console.ReadKey();

                    Console.ForegroundColor = ConsoleColor.White;

                    pgNum++;
                }
            }
        }

























    }
}
