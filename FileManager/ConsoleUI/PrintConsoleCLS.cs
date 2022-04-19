using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    internal class PrintConsoleCLS : PrintConsole, IPrintConsole
    {
        public string Name => "CLS";


        public Varibles StartPrint(Varibles varibles)
        {
            SysVaribles = varibles;

            ClearConsoleCommandExecuter();

            return SysVaribles;
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
