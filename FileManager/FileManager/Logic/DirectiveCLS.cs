using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    internal class DirectiveCLS : LateBinding, IDirective
    {
        private const string _directiveName = "CLS";
        public string DirectiveName { get => _directiveName; }

        public void RunDirective(params string[] args)
        {
            NameToSerch = DirectiveName;

            DirectivesConsole();

            PrintDirectiveSelection();
        }

        

    }
}
