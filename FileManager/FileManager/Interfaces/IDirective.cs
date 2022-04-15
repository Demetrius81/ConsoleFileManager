using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    internal interface IDirective
    {
        public string DirectiveName { get; }

        Varibles RunDirective(Varibles varibles);

    }
}
