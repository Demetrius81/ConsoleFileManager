using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    internal class DirectiveEXIT : IDirective
    {
        private const string _directiveName = "EXIT";

        public string DirectiveName { get => _directiveName; }

        public void RunDirective(params string[] args)
        {
            SystemVaribles.Exit = StartStop.ExitCommandExecuter();
        }


       






    }
}
