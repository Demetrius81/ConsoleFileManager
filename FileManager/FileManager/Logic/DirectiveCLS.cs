using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    internal class DirectiveCLS : IDirective
    {
        private const string _directiveName = "CLS";
        public string DirectiveName { get => _directiveName; }

        void IDirective.RunDirective(params string[] args)
        {
            throw new NotImplementedException();
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
