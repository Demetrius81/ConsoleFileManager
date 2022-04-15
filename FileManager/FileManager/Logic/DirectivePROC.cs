using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    internal class DirectivePROC : Directive, IDirective
    {
        private const string _directiveName = "PROC";

        public string DirectiveName { get => _directiveName; }

        public Varibles RunDirective(Varibles varibles)
        {
            SVarible = varibles;

            SVarible.TaskManager = new BasicLogic();

            NameToSerch = DirectiveName;

            DirectivesConsole();

            PrintDirectiveSelection();

            return varibles;
        }
















        /// <summary>
        /// Метод распознает команду управления процессами
        /// </summary>
        public static void ProcessCommandExecuter()
        {
            string[] commands = SVarible.Command.Split();

            if (commands.Length == 2)
            {
                if (commands[1] == "-DEL")
                {
                    DeleteProcessCall();
                }
                if (commands[1] == "-CRT")
                {
                    CreateProcessCall();
                }
            }
            if (commands.Length == 1)
            {
                PrintProcessesCall();
            }
        }



        private static void PrintProcessesCall()
        {
            NameToSerch = "PROCPRINTALL";

            DirectivesConsole();

            PrintDirectiveSelection();
        }



        private static void DeleteProcessCall()
        {
            NameToSerch = "PROCDELETE";

            DirectivesConsole();

            PrintDirectiveSelection();
        }

        private static void CreateProcessCall()
        {
            NameToSerch = "PROCCREATE";

            DirectivesConsole();

            PrintDirectiveSelection();
        }

    }
}
