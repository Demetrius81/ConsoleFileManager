using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.ConsoleUI
{
    internal class PrintConsoleCLS : IPrintConsole
    {
        public string Name => "CLS";


        public void StartPrint()
        {
            ClearConsoleCommandExecuter();
        }


        /// <summary>
        /// Метод очищает консоль
        /// </summary>
        public static void ClearConsoleCommandExecuter()
        {
            Console.Clear();
        }

    }
}
