using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    internal class DirectiveHELP : Directive, IDirective
    {
        private const string _directiveName = "HELP";

        public string DirectiveName { get => _directiveName; }

        public Varibles RunDirective(Varibles varibles)
        {
            SVarible = varibles;

            HelpCommandExecuter();

            NameToSerch = DirectiveName;

            DirectivesConsole();

            PrintDirectiveSelection();

            return varibles;
        }

        

        /// <summary>
        /// Метод воспроизводит из файла Help - лист
        /// </summary>
        /// <returns>List<string> Help - лист</returns>
        private static void HelpCommandExecuter()
        {
            SVarible.Files = new List<string>();

            if (File.Exists(@"Help.txt"))
            {
                foreach (string strings in File.ReadAllLines(@"Help.txt"))
                {
                    SVarible.Files.Add(strings);
                }
            }            
        }






    }
}
