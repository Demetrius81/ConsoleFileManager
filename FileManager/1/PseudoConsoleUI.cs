using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace FileManager
{
    /// <summary>
    /// Класс, который содержит методы вывода информации на консоль
    /// </summary>
    public class PseudoConsoleUI
    {
        #region Fields and properties

        /// <summary>
        /// Константа запроса на ввод информации
        /// </summary>
        public const string INPUT_REQUEST = @">";

        /// <summary>
        /// Наименование окна
        /// </summary>
        public const string TILDE = "Проект \"Файловый менеджер\"";

        /// <summary>
        /// Длина строки для вывода списка процессов
        /// </summary>
        public const int LENGTH_LINE = 75;

        /// <summary>
        /// Ширина Буфера
        /// </summary>
        public const int BUFFER_WIDTH = 160;

        /// <summary>
        /// Высота буфера
        /// </summary>
        public const int BUFFER_HEIGTH = 50;

        /// <summary>
        /// Ширина окна
        /// </summary>
        public const int WINDOW_WIDTH = 160;

        /// <summary>
        /// Высота окна
        /// </summary>
        public const int WINDOW_HEIGTH = 50;

        /// <summary>
        /// Количество строк в странице
        /// </summary>
        public const int PAGE_LINES = 40;

        #endregion

        /// <summary>
        /// Метод выводит на экран скопированные файлы
        /// </summary>
        public static void ShowCopyCommand(List<string> files)
        {
            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine();

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine($"Sucsessfully copied {files.Count / 2} files:");

            for (int i = 0; i < files.Count; i += 2)
            {
                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                Console.WriteLine($"Copy {files[i]} to {files[i + 1]} is done.");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод выводит на экран все подкаталоги и файлы текущего каталога
        /// </summary>
        /// <param name="dirFiles">DrivesAndDirectories актуальное состояние программы</param>
        /// <param name="dirStart">int первый каталог на странице</param>
        /// <param name="dirStop">int крайний каталог на странице</param>
        /// <param name="fileStart">int первый файл на странице</param>
        /// <param name="fileStop">int крайний файл на странице</param>
        public static void PrintAllSubdirectoriesAndFilesByPages(DrivesDirectoriesFilesArray dirFiles, int dirStart, int dirStop, int fileStart, int fileStop)
        {
            FileInfo[] files = dirFiles.Files;

            DirectoryInfo[] subdirectories = dirFiles.Directories;

            Console.WriteLine();

            for (int i = dirStart; i < dirStop; i++)
            {
                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                Console.Write($"{subdirectories[i].Name}");

                Console.SetCursorPosition(20, Console.BufferHeight - 1);

                Console.ForegroundColor = ConsoleColor.DarkGray;

                Console.Write($"<DIR>");

                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(30, Console.BufferHeight - 1);

                Console.Write($"{subdirectories[i].CreationTime:dd-MM-yyyy}");

                Console.WriteLine();
            }
            for (int i = fileStart; i < fileStop; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                Console.Write($"{ Path.GetFileNameWithoutExtension(files[i].FullName)}");

                Console.SetCursorPosition(25, Console.BufferHeight - 1);

                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.Write($"{ Path.GetExtension(files[i].FullName)}");

                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(30, Console.BufferHeight - 1);

                Console.Write($"{files[i].Length} Bytes");

                Console.SetCursorPosition(70, Console.BufferHeight - 1);

                Console.Write($"{ files[i].CreationTime:HH-mm-ss dd-MM-yyyy}");

                Console.SetCursorPosition(90, Console.BufferHeight - 1);

                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.Write($"{ files[i].Attributes}");

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод выводит в консоль все логические диски
        /// </summary>
        /// <param name="drives">DriveInfo[] массив логических дисков</param>
        public static void PrintAllDrives(DriveInfo[] drives)
        {
            string r;

            Console.WriteLine();

            for (int i = 0; i < drives.Length; i++)
            {
                r = drives[i].IsReady ? "READY" : "NOT READY";

                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                Console.Write($"{drives[i].Name}");

                Console.SetCursorPosition(4, Console.BufferHeight - 1);

                Console.Write($"{r}");

                Console.SetCursorPosition(10, Console.BufferHeight - 1);

                Console.Write($"{drives[i].DriveType}");

                Console.SetCursorPosition(20, Console.BufferHeight - 1);

                Console.Write($"{drives[i].DriveFormat}");

                Console.SetCursorPosition(27, Console.BufferHeight - 1);

                Console.Write($"Доступно {((drives[i].TotalFreeSpace / 1024) / 1024)} Мбайт");

                Console.SetCursorPosition(60, Console.BufferHeight - 1);

                Console.Write($"из {((drives[i].TotalSize / 1024) / 1024)} Мбайт");

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод выводит на экран текущий номер страницы
        /// </summary>
        /// <param name="allLines">int количество всех подкаталогов и файлов в каталоге</param>
        /// <param name="userPage">int страница</param>
        public static void PrintPageNumber(int allLines, int userPage)
        {
            if (userPage != -1)
            {
                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                int p = userPage > (1 + allLines / PAGE_LINES) ? (1 + allLines / PAGE_LINES) : userPage;

                Console.Write($"Страница {p} из {(1 + allLines / PAGE_LINES)}");
            }
        }

        /// <summary>
        /// Метод выводит в консоль параметры полученного файла
        /// </summary>
        /// <param name="file">FileInfo файл, параметры которого нужно изучить</param>
        public static void PrintFileProperties(FileInfo file)
        {
            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine();

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($"Информация по файлу: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{file.FullName}");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($" размер: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{file.Length} Байт");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine();

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($"имеет атрибуты: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{file.Attributes}");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($", Время создания: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{file.CreationTime:dd-MM-yyyy HH-mm-ss}");

            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine();
        }

        /// <summary>
        /// Метод выводит на экран состояние текущей директории
        /// </summary>
        /// <param name="dirFiles">DrivesAndDirectories актуальное состояние программы</param>
        public static void PrintDirectoryProrerties(DrivesAndDirectories dirFiles)
        {
            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine();

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($"Текущая директория: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{dirFiles.CuttentDirectory.FullName}");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($" содержит: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{dirFiles.CuttentDirectory.GetFiles().Length}");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($" файлов,");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine();

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($"имеет атрибуты: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{dirFiles.CuttentDirectory.Attributes}");

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write($", Время создания: ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{dirFiles.CuttentDirectory.CreationTime:dd-MM-yyyy HH-mm-ss}");

            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine();
        }

        /// <summary>
        /// Метод выводит на экран Help - лист
        /// </summary>
        public static void WriteHelp(List<string> list)
        {
            Console.WriteLine();

            foreach (string row in list)
            {
                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                Console.WriteLine(row);
            }
            Console.WriteLine();

        }

        /// <summary>
        /// Метод задает размеры окна и буфера консоли
        /// </summary>
        public static void WindowSettings()
        {
            Console.Title = TILDE;

            Console.SetBufferSize(BUFFER_WIDTH, BUFFER_HEIGTH);

            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGTH);
        }

        /// <summary>
        /// метод перемещает курсор на указанную позицию
        /// </summary>
        /// /// <param name="dir">DrivesAndDirectories актуальное состояние программы</param>
        public static void SetCursorPosition(DrivesAndDirectories temp)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.Write(temp.CuttentDirectory + INPUT_REQUEST);
        }

        /// <summary>
        /// Метод перещает курсор на указанную позицию для работы с процессами
        /// </summary>
        private static void SetCursorPositionForProcesses()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.Write(INPUT_REQUEST);
        }

        /// <summary>
        /// Метод запрашивает сведения о процессе
        /// </summary>
        private static void RequestToEnterProcess(string proc)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine(proc);

            Console.SetCursorPosition(0, Console.BufferHeight - 1);

            Console.WriteLine(@"для выхода введите пустую строку");

            SetCursorPositionForProcesses();
        }

        /// <summary>
        /// Метод удаляет процесс
        /// </summary>
        public static void DeleteProcess()
        {
            BasicLogic logic = new BasicLogic();

            int userDataInt = 0;

            bool isItId;

            RequestToEnterProcess(@"Введите имя процесса или его ID,");

            string userData = Console.ReadLine();

            if (userData != "")
            {
                try
                {
                    userDataInt = Convert.ToInt32(userData);

                    isItId = true;
                }
                catch (Exception)
                {
                    isItId = false;
                }

                if (isItId)
                {
                    isItId = logic.KillProcess(userDataInt);
                }
                else
                {
                    isItId = logic.KillProcess(userData);
                }
                if (isItId)
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.SetCursorPosition(0, Console.BufferHeight - 1);

                    Console.WriteLine("Process is sussessfally terminated...Press any key");

                    Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.SetCursorPosition(0, Console.BufferHeight - 1);

                    Console.WriteLine("Process not found...Press any key");

                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Метод запускает процесс
        /// </summary>
        public static void CreateProcess()
        {
            BasicLogic logic = new BasicLogic();

            bool isItId;

            RequestToEnterProcess(@"Введите имя файла или URL для запуска процесса,");

            string userData = Console.ReadLine();

            if (userData != "")
            {
                isItId = logic.CreateNewProcess(userData);

                if (!isItId)
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.SetCursorPosition(0, Console.BufferHeight - 1);

                    Console.WriteLine($"The file {userData} is not exist. Press any key");

                    Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.SetCursorPosition(0, Console.BufferHeight - 1);

                    Console.WriteLine($"Process {userData} is launched. Press any key");

                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Метод выводит в консоль все процессы
        /// </summary>
        /// <param name="process"></param>
        public static void PrintProcesses(Process[] process)
        {
            Console.Clear();

            int pgNum = 1;

            for (int i = 0; i < process.Length; i++)
            {
                string str = "";

                int stringLength = process[i].ProcessName.Length + Convert.ToString(process[i].Id).Length;

                if (stringLength < LENGTH_LINE)
                {
                    for (int j = 0; j < LENGTH_LINE - stringLength; j++)
                    {
                        str = str + ".";
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(0, Console.BufferHeight - 1);

                Console.WriteLine($" {String.Format("{0:d4}", i)} {process[i].ProcessName}{str}{process[i].Id}");

                if (i == pgNum * (PAGE_LINES - 1))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;

                    Console.SetCursorPosition(0, Console.BufferHeight - 1);

                    Console.WriteLine($"Страница {pgNum}. Для продолжения нажмите любую клавишу...");

                    Console.ReadKey();

                    Console.ForegroundColor = ConsoleColor.White;

                    pgNum++;
                }
            }
        }

























    }
}
