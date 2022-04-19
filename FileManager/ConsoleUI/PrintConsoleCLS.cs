using System;

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
        private static void ClearConsoleCommandExecuter()
        {
            Console.Clear();
        }

    }
}
