using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    internal class DirectiveCD : IDirective
    {



        /// <summary>
        /// Метод меняет местоположение текущей директории
        /// </summary>
        /// <param name="path">Принимает string значение управляющая команда</param>
        public void RunDirective(string path)
        {
            if (Command.Split().Length == 2)
            {
                if (path == null || path == "")
                {
                    return;
                }

                string temp = "";

                if (path == "..")
                {
                    DirectoryInfo tempDir = drivesAndDirectories.CuttentDirectory.Parent;
                    if (!(tempDir is null))
                    {
                        drivesAndDirectories.CuttentDirectory = tempDir;
                    }
                }
                if (!path.Contains(":\\") && !path.Contains(":/") && !path.Contains(".."))
                {
                    temp = $"{drivesAndDirectories.CuttentDirectory.ToString().ToUpperInvariant()}\\{path.ToUpperInvariant()}";

                    if (Directory.Exists(temp))
                    {
                        drivesAndDirectories.CuttentDirectory = new DirectoryInfo(temp);
                    }
                    Command = "";
                }
                else if ((path.Contains('\\') || path.Contains('/')) && (path.Contains(":\\") || path.Contains(":/")))
                {
                    temp = $"{path}";

                    if ((temp[1] == ':') && !temp.Contains(drivesAndDirectories.CurrentDrive.ToString().ToUpperInvariant()))
                    {
                        drivesAndDirectories.CurrentDrive = new DriveInfo(temp.Substring(0, 2).ToUpperInvariant());
                    }

                    if (Directory.Exists(temp))
                    {
                        drivesAndDirectories.CuttentDirectory = new DirectoryInfo(temp.ToUpperInvariant());
                    }
                    Command = "";
                }
            }
        }
    }
}
