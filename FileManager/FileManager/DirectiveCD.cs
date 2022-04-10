using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    internal class DirectiveCD : IDirective
    {
        private const string _directiveName = "CD";

        public string DirectiveName { get => _directiveName; }

        public void RunDirective(params string[] args)
        {
            StartDirective(args[0]);
        }

        /// <summary>
        /// Метод меняет местоположение текущей директории
        /// </summary>
        /// <param name="path">Принимает string значение управляющая команда</param>
        public void StartDirective(string path)
        {
            if (UserCommands.Command.Split().Length == 2)
            {
                if (path == null || path == "")
                {
                    return;
                }

                string temp = "";

                if (path == "..")
                {
                    DirectoryInfo tempDir = UserCommands.DrivesAndDirs.CuttentDirectory.Parent;
                    if (!(tempDir is null))
                    {
                        UserCommands.DrivesAndDirs.CuttentDirectory = tempDir;
                    }
                }
                if (!path.Contains(":\\") && !path.Contains(":/") && !path.Contains(".."))
                {
                    temp = $"{UserCommands.DrivesAndDirs.CuttentDirectory.ToString().ToUpperInvariant()}\\{path.ToUpperInvariant()}";

                    if (Directory.Exists(temp))
                    {
                        UserCommands.DrivesAndDirs.CuttentDirectory = new DirectoryInfo(temp);
                    }
                    UserCommands.Command = "";
                }
                else if ((path.Contains('\\') || path.Contains('/')) && (path.Contains(":\\") || path.Contains(":/")))
                {
                    temp = $"{path}";

                    if ((temp[1] == ':') && !temp.Contains(UserCommands.DrivesAndDirs.CurrentDrive.ToString().ToUpperInvariant()))
                    {
                        UserCommands.DrivesAndDirs.CurrentDrive = new DriveInfo(temp.Substring(0, 2).ToUpperInvariant());
                    }

                    if (Directory.Exists(temp))
                    {
                        UserCommands.DrivesAndDirs.CuttentDirectory = new DirectoryInfo(temp.ToUpperInvariant());
                    }
                    UserCommands.Command = "";
                }
            }
        }






        /// <summary>
        /// Метод выводит на экран состояние текущей директории
        /// </summary>
        /// <param name="dirFiles">DrivesAndDirectories актуальное состояние программы</param>
        public static void PrintDirectoryProrerties(DrivesAndDirectories dirFiles)
        {
            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine();

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($"Текущая директория: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{dirFiles.CuttentDirectory.FullName}");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($" содержит: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{dirFiles.CuttentDirectory.GetFiles().Length}");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($" файлов,");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine();

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($"имеет атрибуты: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{dirFiles.CuttentDirectory.Attributes}");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($", Время создания: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{dirFiles.CuttentDirectory.CreationTime:dd-MM-yyyy HH-mm-ss}");

            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine();
        }



    }
}
