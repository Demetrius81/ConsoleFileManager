using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FileManager.ConsoleUI
{
    internal class PrintConsolePROCDELETE : PrintConsole, IPrintConsole
    {
        public string Name => "PROCDELETE";

        public Varibles StartPrint(Varibles varibles)
        {
            SysVaribles = varibles;

            DeleteProcess();

            return SysVaribles;
        }





        /// <summary>
        /// Метод удаляет процесс
        /// </summary>
        private static void DeleteProcess()
        {
            SysVaribles.TaskManager = new BasicLogic();

            int userDataInt = 0;

            bool isItId;

            PseudoConsoleUI.RequestToEnterProcess(@"Введите имя процесса или его ID,");

            string userData = Console.ReadLine();

            if (userData != "")
            {
                isItId = int.TryParse(userData, out userDataInt);

                if (isItId)
                {
                    isItId = SysVaribles.TaskManager.KillProcess(userDataInt);
                }
                else
                {
                    isItId = SysVaribles.TaskManager.KillProcess(userData);
                }
                if (isItId)
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.SetCursorPosition(0, Console.BufferHeight - 1);

                    Console.WriteLine("Process is sussessfally terminated...Press any key");

                    Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.SetCursorPosition(0, Console.BufferHeight - 1);

                    Console.WriteLine("Process not found...Press any key");

                    Console.ReadKey();
                }
            }
        }





















    }
}
