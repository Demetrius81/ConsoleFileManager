using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    internal class DirectiveCD : LateBinding, IDirective 
    {
        private string _directiveName = "CD";

        public string DirectiveName { get => _directiveName; }

        

        public void RunDirective(params string[] args)
        {
            ChangeDirectoryCommandExecuter();

            NameToSerch = DirectiveName;

            DirectivesConsole();

            PrintDirectiveSelection();
        }

        /// <summary>
        /// Метод меняет местоположение текущей директории
        /// </summary>
        /// <param name="path">Принимает string значение управляющая команда</param>
        private void ChangeDirectoryCommandExecuter()
        {
            string[] commands = SystemVaribles.Command.Split();

            string path = commands[1];

            if (commands.Length == 2)
            {
                if (path == null || path == "")
                {
                    return;
                }

                string temp = "";

                if (path == "..")
                {
                    DirectoryInfo tempDir = SystemVaribles.DrivesAndDirs.CuttentDirectory.Parent;
                    if (!(tempDir is null))
                    {
                        SystemVaribles.DrivesAndDirs.CuttentDirectory = tempDir;
                    }
                }
                if (!path.Contains(":\\") && !path.Contains(":/") && !path.Contains(".."))
                {
                    temp = $"{SystemVaribles.DrivesAndDirs.CuttentDirectory.ToString().ToUpperInvariant()}\\{path.ToUpperInvariant()}";

                    if (Directory.Exists(temp))
                    {
                        SystemVaribles.DrivesAndDirs.CuttentDirectory = new DirectoryInfo(temp);
                    }
                    SystemVaribles.Command = "";
                }
                else if ((path.Contains('\\') || path.Contains('/')) && (path.Contains(":\\") || path.Contains(":/")))
                {
                    temp = $"{path}";

                    if ((temp[1] == ':') && !temp.Contains(SystemVaribles.DrivesAndDirs.CurrentDrive.ToString().ToUpperInvariant()))
                    {
                        SystemVaribles.DrivesAndDirs.CurrentDrive = new DriveInfo(temp.Substring(0, 2).ToUpperInvariant());
                    }

                    if (Directory.Exists(temp))
                    {
                        SystemVaribles.DrivesAndDirs.CuttentDirectory = new DirectoryInfo(temp.ToUpperInvariant());
                    }
                    SystemVaribles.Command = "";
                }
            }
        }       
    }
}
