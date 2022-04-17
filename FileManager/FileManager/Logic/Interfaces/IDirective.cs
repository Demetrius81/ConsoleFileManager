using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    /// <summary>
    /// Интерфейс директивы
    /// </summary>
    internal interface IDirective
    {
        /// <summary>
        /// Наименование директивы
        /// </summary>
        public string DirectiveName { get; }

        /// <summary>
        /// Метод запускает логику директивы
        /// </summary>
        /// <param name="varibles">Varibles текущее состояние программы</param>
        /// <returns>Varibles состояние программы после выполнения логики директивы</returns>
        Varibles RunDirective(Varibles varibles);

    }
}
