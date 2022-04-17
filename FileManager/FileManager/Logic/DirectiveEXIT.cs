using Newtonsoft.Json;
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
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            using (FileStream fileStream = new FileStream("system.bin", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fileStream, varibles.DrivesAndDirs);
            }
            return true;
        }
    }
}
