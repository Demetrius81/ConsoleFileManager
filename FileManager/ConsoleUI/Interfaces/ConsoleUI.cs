using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    /// <summary>
    /// Интерфейс вывода в консоль
    /// </summary>
    public interface IPrintConsole
    {
        /// <summary>
        /// Наименование процесса вывода
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Метод завускает процесс вывода информации в консоль
        /// </summary>
        /// <param name="varibles">Varibles текущее состояние программы</param>
        /// <returns>Varibles состояние программы после выполнения логики директивы</returns>
        public Varibles StartPrint(Varibles varibles);
    }
}
