using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    internal class DirectiveEXIT : Directive, IDirective
    {
        private const string _directiveName = "EXIT";

        public string DirectiveName { get => _directiveName; }

        public Varibles RunDirective(Varibles varibles)
        {
            Varibles = varibles;

            Varibles.Exit = ExitCommandExecuter(varibles);

            return Varibles;
        }


        /// <summary>
        /// Метод завершает работу консоли и сохраняет параметры программы в файл.
        /// </summary>
        /// <returns>Значение типа bool своего рода выключатель программы</returns>
        /// 
        public static bool ExitCommandExecuter(Varibles varibles)
        {
            string temp = $"{varibles.DrivesAndDirs.CurrentDrive.Name}|W|{varibles.DrivesAndDirs.CuttentDirectory.ToString()}";

            temp = JsonConvert.SerializeObject(temp);

            File.WriteAllText("path.json", temp);

            return true;
        }
    }
}
