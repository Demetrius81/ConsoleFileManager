using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    internal class DirectiveCLS : Directive, IDirective
    {
        private const string _directiveName = "CLS";
        public string DirectiveName { get => _directiveName; }
        
        public Varibles RunDirective(Varibles varibles)
        {
            NameToSerch = DirectiveName;

            SVarible = varibles;

            DirectivesConsole();

            PrintDirectiveSelection();

            return SVarible;
        }
    }
}
