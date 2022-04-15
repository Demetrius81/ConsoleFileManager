using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FileManager
{
    public class Directive
    {
        private static List<IPrintConsole> _printConsole = new List<IPrintConsole>();

        internal static List<IPrintConsole> PrintConsole { get => _printConsole; set => _printConsole = value; }

        private static string _nameToSerch;

        public static string NameToSerch { get => _nameToSerch; set => _nameToSerch = value; }

        private static Varibles _sVarible;

        internal static Varibles SVarible { get => _sVarible; set => _sVarible = value; }

        /// <summary>
        /// Метод при помощи механизмов класса System.Reflection динамически подключает библиотеку классов
        /// </summary>
        internal static void DirectivesConsole()
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            Type[] types = asm.GetTypes();

            foreach (Type type in types)
            {
                PropertyInfo field = type.GetProperty("Name");

                if (!(field is null) && !type.IsInterface)
                {
                    object obj = Activator.CreateInstance(type);

                    PrintConsole.Add(obj as IPrintConsole);
                }
            }
        }

        internal static void PrintDirectiveSelection()
        {
            foreach (IPrintConsole directive in PrintConsole)
            {
                if (directive.Name == NameToSerch)
                {
                    SVarible = directive.StartPrint(SVarible);
                }
            }                       
        }
    }
}
