using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    internal class PrintConsoleDIRDrives:PrintConsole, IPrintConsole
    {

        public string Name => "DIRSD";

        public Varibles StartPrint(Varibles varibles)
        {
            SysVaribles = varibles;

            

            return SysVaribles;
        }











    }
}
