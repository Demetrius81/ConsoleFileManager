using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    /// <summary>
    /// Базовый класс вывода в консоль
    /// </summary>
    public class PrintConsole
    {
        /// <summary>
        /// Свойство доступа к хранилищу глобальных переменных в процессе выполнения логики метода
        /// </summary>
        public static Varibles SysVaribles { get; set; }
    }
}
