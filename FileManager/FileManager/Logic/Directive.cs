using System;
using System.Collections.Generic;
using System.Reflection;

namespace FileManager
{
    /// <summary>
    /// Базовый класс логики директивы
    /// </summary>
    public class Directive
    {
        private static List<IPrintConsole> _printConsole = new List<IPrintConsole>();

        /// <summary>
        /// Свойство для доступа к списку классов для вывода в консоль
        /// </summary>
        internal static List<IPrintConsole> PrintConsole { get => _printConsole; set => _printConsole = value; }

        private static string _nameToSerch;

        /// <summary>
        /// Свойство для доступа к наименованию вызываемого процесса для вывода в консоль
        /// </summary>
        public static string NameToSerch { get => _nameToSerch; set => _nameToSerch = value; }

        private static Varibles _sVarible;

        /// <summary>
        /// Свойство доступа к хранилищу глобальных переменных в процессе выполнения логики метода
        /// </summary>
        internal static Varibles SVarible { get => _sVarible; set => _sVarible = value; }

        /// <summary>
        /// Метод при помощи механизмов класса System.Reflection создает список классов для вывода в консоль
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

        /// <summary>
        /// Метод при помощи механизмов класса System.Reflection динамически подключает библиотеку классов
        /// </summary>
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
