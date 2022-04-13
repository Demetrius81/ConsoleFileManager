using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.ConsoleUI
{
    internal class PrintConsoleCOPY
    {
        /// <summary>
        /// Метод выводит на экран скопированные файлы
        /// </summary>
        public static void ShowCopyCommand()
        {
            List<string> files = new List<string>();

            files.AddRange(SystemVaribles.Files);

            SystemVaribles.Files.Clear();

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
