using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    internal interface IPrintConsole
    {
        public string Name { get; }

        

        public Varibles StartPrint(Varibles varibles);
    }
}
