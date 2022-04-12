using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    internal class DirectiveMD : IDirective
    {
        private const string _directiveName = "MD";
        public string DirectiveName { get => _directiveName; }

        public void RunDirective(params string[] args)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// Метод создает директорию по указанному пути или в текущем каталоге
        /// </summary>
        public static void MakingDirectoryCommandExecuter()
        {
            string[] commands = UserCommands.Command.Split();

            UserCommands.Command = "";

            if (commands.Length > 1 && !commands[1].Contains('\\') && !commands[1].Contains('/'))
            {
                Directory.SetCurrentDirectory(UserCommands.DrivesAndDirs.CuttentDirectory.ToString());

                Directory.CreateDirectory(commands[1]);
            }
            if (commands.Length > 1 && (commands[1].Contains(":\\") || commands[1].Contains(":/"))
                && (commands[1].Contains('\\') || commands[1].Contains('/')))
            {
                Directory.CreateDirectory(commands[1]);
            }
        }













    }
}
