using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    internal interface IDirective
    {
        void RunDirective(string path);
    }
}
