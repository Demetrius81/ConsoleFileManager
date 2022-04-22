using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    internal class DirectiveFIND : Directive, IDirective
    {
        private string _directiveName = "FIND";

        public string DirectiveName { get => _directiveName; }

        public Varibles RunDirective(Varibles varibles)
        {
            SVarible = varibles;

            





            NameToSerch = DirectiveName;

            DirectivesConsole();

            PrintDirectiveSelection();

            return varibles;
        }


        /// <summary>
        /// Метод меняет местоположение текущей директории
        /// </summary>
        /// <param name="path">Принимает string значение управляющая команда</param>
        private void FindCommandExecuter()
        {
            string[] commands = SVarible.Command.Split();

            string path = commands[1];

            if (commands.Length == 2 && commands[1].Contains('.'))
            {
                GetFiles(SVarible.DrivesAndDirs.CuttentDirectory.ToString(), commands[1], SearchOption.TopDirectoryOnly);
            }
            if (commands.Length == 3 && commands[2].ToUpperInvariant() == "-A")
            {
                GetFiles(SVarible.DrivesAndDirs.CuttentDirectory.ToString(), commands[1], SearchOption.AllDirectories);
            }
            if (commands.Length == 2 && !commands[1].Contains('.'))
            {
                GetDirs(SVarible.DrivesAndDirs.CuttentDirectory.ToString(), commands[1], SearchOption.TopDirectoryOnly);
            }
            if (commands.Length == 3 && commands[2].ToUpperInvariant() == "-A")
            {
                GetDirs(SVarible.DrivesAndDirs.CuttentDirectory.ToString(), commands[1], SearchOption.AllDirectories);
            }
        }













        /// <summary>
        /// Метод получает список файлов
        /// </summary>
        void GetFiles(string path, string searchPattern, SearchOption searchOption)
        {

            DirectoryInfo directory = new DirectoryInfo(path);

            SVarible.DrivesDirFilesArray.Files = directory.GetFiles(searchPattern, searchOption);



            //string[] files = Directory.GetFiles(@"C:\", "*.txt");
        }

        /// <summary>
        /// Метод получает получть список каталогов
        /// </summary>
        void GetDirs(string path, string searchPattern, SearchOption searchOption)
        {
            DirectoryInfo directory = new DirectoryInfo(path);

            SVarible.DrivesDirFilesArray.Directories = directory.GetDirectories(searchPattern, searchOption);

            //string[] dirs = Directory.GetDirectories(@"C:\", "d*");
        }



    }
}
