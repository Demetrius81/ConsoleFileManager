using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    internal class PrintConsoleCOPY : PrintConsole, IPrintConsole
    {
        public string Name => "COPY";


        public Varibles StartPrint(Varibles varibles)
        {
            SysVaribles = varibles;

            ShowCopyCommand();

            return SysVaribles;
        }





        /// <summary>
        /// Метод выводит на экран скопированные файлы
        /// </summary>
        public static void ShowCopyCommand()
        {
            List<string> files = new List<string>();

            files.AddRange(SysVaribles.Files);

            SysVaribles.Files.Clear();

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

    }
}
