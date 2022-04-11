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
            StartDirective(args[0]);
        }


        /// <summary>
        /// Метод завершает работу консоли и сохраняет параметры программы в файл.
        /// </summary>
        /// <returns>Значение типа bool своего рода выключатель программы</returns>
        /// 
        public static bool ExitCommandExecuter()
        {
            string temp = $"{UserCommands.DrivesAndDirs.CurrentDrive.Name}|W|{UserCommands.DrivesAndDirs.CuttentDirectory.ToString()}";

            temp = JsonConvert.SerializeObject(temp);

            File.WriteAllText("path.json", temp);

            return true;
        }






    }
}
