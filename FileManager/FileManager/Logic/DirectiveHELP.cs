using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    internal class DirectiveHELP : IDirective
    {
        private const string _directiveName = "HELP";

        public string DirectiveName { get => _directiveName; }

        public void RunDirective(params string[] args)
        {
            StartDirective(args[0]);
        }

        /// <summary>
        /// Метод выводит на экран Help - лист
        /// </summary>
        public static void WriteHelp(List<string> list)
        {
            Console.WriteLine();

            foreach (string row in list)
            {
                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                Console.WriteLine(row);
            }
            Console.WriteLine();

        }

        /// <summary>
        /// Метод воспроизводит из файла Help - лист
        /// </summary>
        /// <returns>List<string> Help - лист</returns>
        public static List<string> HelpCommandExecuter()
        {
            List<string> list = new List<string>();

            if (File.Exists(@"Help.txt"))
            {

                foreach (string strings in File.ReadAllLines(@"Help.txt"))
                {
                    list.Add(strings);
                }
            }
            return list;
        }






    }
}
