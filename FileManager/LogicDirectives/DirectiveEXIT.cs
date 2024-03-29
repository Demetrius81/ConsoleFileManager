﻿using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileManager
{
    /// <summary>
    /// Класс директивы выхода
    /// </summary>
    internal class DirectiveEXIT : Directive, IDirective
    {
        private const string _directiveName = "EXIT";

        public string DirectiveName { get => _directiveName; }

        public Varibles RunDirective(Varibles varibles)
        {
            SVarible = varibles;

            SVarible.Exit = ExitCommandExecuter(varibles);

            return SVarible;
        }


        /// <summary>
        /// Метод завершает работу консоли и сохраняет параметры программы в файл.
        /// </summary>
        /// <returns>Значение типа bool своего рода выключатель программы</returns>
        /// 
        private bool ExitCommandExecuter(Varibles varibles)
        {
            string temp = $"{varibles.DrivesAndDirs.CurrentDrive.Name}|W|{varibles.DrivesAndDirs.CuttentDirectory.ToString()}";

            temp = JsonConvert.SerializeObject(temp);

            File.WriteAllText("path.json", temp);

            return true;
        }
    }
}
