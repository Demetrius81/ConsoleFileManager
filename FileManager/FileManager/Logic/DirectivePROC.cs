using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    internal class DirectivePROC : IDirective
    {
        private const string _directiveName = "PROC";

        public string DirectiveName { get => _directiveName; }

        public void RunDirective(params string[] args)
        {
            //StartDirective(args[0]);
        }
















        /// <summary>
        /// Метод распознает команду управления процессами
        /// </summary>
        public static void ProcessCommandExecuter()
        {
            string[] commands = SystemVaribles.Command.Split();

            if (commands.Length == 2)
            {
                if (commands[1] == "-DEL")
                {
                    PseudoConsoleUI.DeleteProcess();
                }
                if (commands[1] == "-CRT")
                {
                    PseudoConsoleUI.CreateProcess();
                }
            }
            if (commands.Length == 1)
            {
                PseudoConsoleUI.PrintProcesses(BasicLogic.GetAllProcesses());
            }
        }











    }
}
