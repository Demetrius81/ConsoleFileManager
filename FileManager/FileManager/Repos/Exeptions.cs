using System;
using System.IO;

namespace FileManager
{
    public class Exeptions
    {

        /// <summary>
        /// Метод выводит на экран сообщения о возникающих ошибках
        /// </summary>
        /// <param name="ex">Exception Объект, содержащий в себе данные об ошибке</param>
        public static void ShowException(Exception ex)
        {
            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine(ex.ToString());

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();

            Console.ReadKey();
        }

        /// <summary>
        /// Метод записывает их в файл Exceptions.log сообщения о возникающих ошибках
        /// </summary>
        /// <param name="ex">Exception Объект, содержащий в себе данные об ошибке</param>
        public static void ExceptionInFile(Exception ex)
        {
            File.AppendAllText("Exceptions.log", $"Time:\n{DateTime.Now}\nException\n{ex}");
        }

    }
}
