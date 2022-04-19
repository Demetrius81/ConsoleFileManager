using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    internal class PrintConsoleDIRDrives:PrintConsole, IPrintConsole
    {

        public string Name => "DIRD";

        public Varibles StartPrint(Varibles varibles)
        {
            SysVaribles = varibles;

            ShowAllDrivesLogic();

            return SysVaribles;
        }


        /// <summary>
        /// Метод создает массив логических дисков
        /// </summary>
        public static void ShowAllDrivesLogic()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            PrintAllDrives(drives);
        }

        /// <summary>
        /// Метод выводит в консоль все логические диски
        /// </summary>
        /// <param name="drives">DriveInfo[] массив логических дисков</param>
        public static void PrintAllDrives(DriveInfo[] drives)
        {
            string r;

            Console.WriteLine();

            for (int i = 0; i < drives.Length; i++)
            {
                r = drives[i].IsReady ? "READY" : "NOT READY";

                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                Console.Write($"{drives[i].Name}");

                Console.SetCursorPosition(4, Console.BufferHeight - 1);

                Console.Write($"{r}");

                Console.SetCursorPosition(10, Console.BufferHeight - 1);

                Console.Write($"{drives[i].DriveType}");

                Console.SetCursorPosition(20, Console.BufferHeight - 1);

                Console.Write($"{drives[i].DriveFormat}");

                Console.SetCursorPosition(27, Console.BufferHeight - 1);

                Console.Write($"Доступно {((drives[i].TotalFreeSpace / 1024) / 1024)} Мбайт");

                Console.SetCursorPosition(60, Console.BufferHeight - 1);

                Console.Write($"из {((drives[i].TotalSize / 1024) / 1024)} Мбайт");

                Console.WriteLine();
            }
        }






    }
}
