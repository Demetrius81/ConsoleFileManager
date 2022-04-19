using System;

namespace FileManager.ConsoleUI
{
    internal class PrintConsoleProcCreate : PrintConsole, IPrintConsole
    {
        public string Name => "PROCCREATE";

        public Varibles StartPrint(Varibles varibles)
        {
            SysVaribles = varibles;

            CreateProcess();

            return SysVaribles;
        }

        /// <summary>
        /// Метод запускает процесс
        /// </summary>
        private static void CreateProcess()
        {
            SysVaribles.TaskManager = new BasicLogic();

            bool isItId;

            PseudoConsoleUI.RequestToEnterProcess(@"Введите имя файла или URL для запуска процесса,");

            string userData = Console.ReadLine();

            if (userData != "")
            {
                isItId = SysVaribles.TaskManager.CreateNewProcess(userData);

                if (!isItId)
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.SetCursorPosition(0, Console.BufferHeight - 1);

                    Console.WriteLine($"The file {userData} is not exist. Press any key");

                    Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.SetCursorPosition(0, Console.BufferHeight - 1);

                    Console.WriteLine($"Process {userData} is launched. Press any key");

                    Console.ReadKey();
                }
            }
        }
    }
}
