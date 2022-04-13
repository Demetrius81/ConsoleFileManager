using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FileManager
{
    public abstract class LateBinding
    {
        private List<IPrintConsole> _printConsole = new List<IPrintConsole>();

        internal List<IPrintConsole> PrintConsole { get => _printConsole; set => _printConsole = value; }

        private string _nameToSerch;

        public string NameToSerch { get => _nameToSerch; set => _nameToSerch = value; }

        /// <summary>
        /// Метод при помощи механизмов класса System.Reflection динамически подключает библиотеку классов
        /// </summary>
        protected void DirectivesConsole()
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

        protected void PrintDirectiveSelection()
        {
            foreach (IPrintConsole directive in PrintConsole)
            {
                if (directive.Name == NameToSerch)
                {
                    directive.StartPrint();
                }
            }                       
        }
    }
}
