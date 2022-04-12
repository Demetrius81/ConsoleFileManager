using System;
using System.Collections.Generic;
using System.Reflection;

namespace FileManager
{
    class Program
    {
        private static readonly List<IDirective> _directives = new List<IDirective>();



        static void Main(string[] args)
        {
            PseudoConsoleUI.WindowSettings();

            Core.RunConsole();
        }


    }
}
