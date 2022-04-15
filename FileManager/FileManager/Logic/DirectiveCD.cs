using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    internal class DirectiveCD : Directive, IDirective 
    {
        private string _directiveName = "CD";

        public string DirectiveName { get => _directiveName; }
        
        public Varibles RunDirective(Varibles varibles)
        {
            Varibles = varibles;

            ChangeDirectoryCommandExecuter();

            NameToSerch = DirectiveName;

            DirectivesConsole();

            PrintDirectiveSelection();

            return varibles;
        }

        /// <summary>
        /// Метод меняет местоположение текущей директории
        /// </summary>
        /// <param name="path">Принимает string значение управляющая команда</param>
        private void ChangeDirectoryCommandExecuter()
        {
            string[] commands = Varibles.Command.Split();

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
                    DirectoryInfo tempDir = Varibles.DrivesAndDirs.CuttentDirectory.Parent;
                    if (!(tempDir is null))
                    {
                        Varibles.DrivesAndDirs.CuttentDirectory = tempDir;
                    }
                }
                if (!path.Contains(":\\") && !path.Contains(":/") && !path.Contains(".."))
                {
                    temp = $"{Varibles.DrivesAndDirs.CuttentDirectory.ToString().ToUpperInvariant()}\\{path.ToUpperInvariant()}";

                    if (Directory.Exists(temp))
                    {
                        Varibles.DrivesAndDirs.CuttentDirectory = new DirectoryInfo(temp);
                    }
                    Varibles.Command = "";
                }
                else if ((path.Contains('\\') || path.Contains('/')) && (path.Contains(":\\") || path.Contains(":/")))
                {
                    temp = $"{path}";

                    if ((temp[1] == ':') && !temp.Contains(Varibles.DrivesAndDirs.CurrentDrive.ToString().ToUpperInvariant()))
                    {
                        Varibles.DrivesAndDirs.CurrentDrive = new DriveInfo(temp.Substring(0, 2).ToUpperInvariant());
                    }

                    if (Directory.Exists(temp))
                    {
                        Varibles.DrivesAndDirs.CuttentDirectory = new DirectoryInfo(temp.ToUpperInvariant());
                    }                    
                }
            }
        }       
    }
}
