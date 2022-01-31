﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace FileManager
{
    /// <summary>
    /// Класс, который содержит логику консоли
    /// </summary>
    public class Engine
    {
        #region Fields and properties
        /// <summary>
        /// Поле для хранения текущей команды пользователя
        /// </summary>
        private static string _command;

        /// <summary>
        /// Свойство для доступа к полю для хранения текущей команды пользователя
        /// </summary>
        public static string Command { get => _command.ToUpperInvariant(); set => _command = value; }

        /// <summary>
        /// Поле для хранения текущей команды управления циклом
        /// </summary>
        private static int _commandInt;

        /// <summary>
        /// Свойство для доступа к полю для хранения текущей команды управления циклом
        /// </summary>
        public static int CommandInt { get => _commandInt; set => _commandInt = value; }

        /// <summary>
        /// Список консольных команд
        /// </summary>
        public static readonly List<string> commands = new List<string>
            {
                "EXIT",
                "CD",
                "CLS",
                "COPY",
                "DEL",
                "DELTREE",
                "MOVE",
                "MD",
                "RD",
                "DIR",
                "HELP"
            };

        /// <summary>
        /// Объект для хранения текущего состояния системы
        /// </summary>
        public static DrivesAndDirectories drivesAndDirectories = new DrivesAndDirectories();
        #endregion

        /// <summary>
        /// Метод запускает консоль, читает из файла сохраненный при прошлом корректном выходе статус.
        /// </summary>
        public static void StartCommandExecuter()
        {
            if (File.Exists("path.json"))
            {
                string temp = File.ReadAllText("path.json");

                string[] tempArr = JsonConvert.DeserializeObject<string>(temp).Split("|W|");

                drivesAndDirectories.CurrentDrive = new DriveInfo(tempArr[0]);

                drivesAndDirectories.CuttentDirectory = new DirectoryInfo(tempArr[1]);

                if (!drivesAndDirectories.CuttentDirectory.Exists)
                {
                    drivesAndDirectories = new DrivesAndDirectories();
                }
            }
        }

        /// <summary>
        /// Метод завершает работу консоли и сохраняет параметры программы в файл.
        /// </summary>
        /// <returns>Значение типа bool своего рода выключатель программы</returns>
        public static bool ExitCommandExecuter()
        {
            string temp = $"{drivesAndDirectories.CurrentDrive.Name}|W|{drivesAndDirectories.CuttentDirectory.ToString()}";

            temp = JsonConvert.SerializeObject(temp);

            File.WriteAllText("path.json", temp);

            return true;
        }

        /// <summary>
        /// Метод меняет местоположение текущей директории
        /// </summary>
        /// <param name="path">Принимает string значение управляющая команда</param>
        public static void ChangeDirectoryCommandExecuter(string path)
        {
            if (Command.Split().Length == 2)
            {
                if (path == null || path == "")
                {
                    return;
                }

                string temp = "";

                if (path == "..")
                {
                    DirectoryInfo tempDir = drivesAndDirectories.CuttentDirectory.Parent;
                    if (!(tempDir is null))
                    {
                        drivesAndDirectories.CuttentDirectory = tempDir;
                    }
                }
                if (!path.Contains(":\\") && !path.Contains(":/") && !path.Contains(".."))
                {
                    temp = $"{drivesAndDirectories.CuttentDirectory.ToString().ToUpperInvariant()}\\{path.ToUpperInvariant()}";

                    if (Directory.Exists(temp))
                    {
                        drivesAndDirectories.CuttentDirectory = new DirectoryInfo(temp);
                    }
                    Command = "";
                }
                else if ((path.Contains('\\') || path.Contains('/')) && (path.Contains(":\\") || path.Contains(":/")))
                {
                    temp = $"{path}";

                    if ((temp[1] == ':') && !temp.Contains(drivesAndDirectories.CurrentDrive.ToString().ToUpperInvariant()))
                    {
                        drivesAndDirectories.CurrentDrive = new DriveInfo(temp.Substring(0, 2).ToUpperInvariant());
                    }

                    if (Directory.Exists(temp))
                    {
                        drivesAndDirectories.CuttentDirectory = new DirectoryInfo(temp.ToUpperInvariant());
                    }
                    Command = "";
                }                
            }
        }

        /// <summary>
        /// Метод очищает консоль
        /// </summary>
        public static void ClearConsoleCommandExecuter()
        {
            Console.Clear();
        }

        /// <summary>
        /// Метод копирует файлы или директории по указанному пути
        /// </summary>
        /// <returns>На выходе список скопированных файлов</returns>
        public static List<string> CopyCommandExecuter()
        {
            string[] commands = Command.Split();

            List<string> files = new List<string>();



            if (commands.Length > 3 && (commands[commands.Length - 1].Contains(":\\") || commands[commands.Length - 1].Contains(":/")))
            {
                for (int i = 1; i < commands.Length - 1; i++)
                {
                    if (File.Exists(commands[i]))
                    {
                        try
                        {
                            string[] path = commands[i].Split('\\', '/');

                            File.Copy(commands[i], $"{commands[commands.Length - 1]}\\{path[path.Length - 1]}", false);

                            files.Add(commands[i]);

                            files.Add($"{commands[commands.Length - 1]}\\{path[path.Length - 1]}");
                        }
                        catch (Exception ex)
                        {
                            PseudoConsoleUI.ShowException(ex);

                            ExceptionInFile(ex);
                        }
                    }
                }
            }
            return files;
        }

        /// <summary>
        /// Метод удаляет каталог с файлами, если там нет подкаталога или файл
        /// </summary>
        public static void DeleteCommandExecuter()
        {
            string[] pathArr = Command.Split();

            if ((pathArr[1].Contains(":\\") || pathArr[1].Contains(":/")) && pathArr[1].Split('\\', '/').Length == 1)
            {
                return;
            }

            FileInfo file = new FileInfo(pathArr[1]);

            DirectoryInfo directory = new DirectoryInfo(pathArr[1]);

            try
            {
                if (directory.Exists)
                {
                    DirectoryInfo[] directories = directory.GetDirectories();

                    if (directories.Length == 0)
                    {
                        directory.Delete(true);
                    }
                }
                else if (file.Exists)
                {
                    file.Delete();
                }
            }
            catch (Exception ex)
            {
                PseudoConsoleUI.ShowException(ex);

                ExceptionInFile(ex);

                return;
            }
        }

        /// <summary>
        /// Метод рекурсивно удаляет каталог и все подкаталоги и файлы
        /// </summary>
        /// <param name="path">string Путь к удаляемому каталогу</param>
        public static void DeleteTree(string path)
        {
            if ((path.Contains(":\\") || path.Contains(":/")) && path.Split('\\', '/').Length == 1)
            {
                return;
            }

            DirectoryInfo directory = new DirectoryInfo(path);
            try
            {
                if (directory.Exists)
                {
                    DirectoryInfo[] directories = directory.GetDirectories();

                    foreach (DirectoryInfo dir in directories)
                    {
                        FileInfo[] files = dir.GetFiles();
                        foreach (FileInfo file in files)
                        {
                            if (file.Exists)
                            {
                                file.Delete();
                            }
                        }
                        DeleteTree(dir.FullName);
                    }
                    directory.Delete(false);
                }
            }
            catch (Exception ex)
            {
                PseudoConsoleUI.ShowException(ex);

                ExceptionInFile(ex);

                return;
            }
        }

        /// <summary>
        /// Метод в зависимости от команды двумя разными способами рекурсивно
        /// удаляет каталог и все подкаталоги и файлы
        /// </summary>
        public static void DeleteTreeCommandExecuter()
        {
            string[] commandsStringArray = Command.Split();

            if (commandsStringArray.Length == 1)
            {
                string path = drivesAndDirectories.CuttentDirectory.ToString();

                ChangeDirectoryCommandExecuter("..");

                DeleteTree(commandsStringArray[1]);
            }
            else if (commandsStringArray.Length == 2)
            {
                DeleteTree(commandsStringArray[1]);
            }
        }

        /// <summary>
        /// Метод перемещает каталог со всем содержимым или файл
        /// </summary>
        /// <param name="pathFrom">string Путь откуда перемешать</param>
        /// <param name="pathTo">string Путь куда перемешать</param>
        public static void MoveCommandExecuter(string pathFrom, string pathTo)
        {
            if (Command.Split().Length == 3)
            {
                if ((pathFrom.Contains(":\\") || pathFrom.Contains(":/"))
                    && (pathTo.Contains(":\\") || pathTo.Contains(":/")))
                {
                    FileInfo file = new FileInfo(pathFrom);

                    DirectoryInfo directory = new DirectoryInfo(pathFrom);

                    try
                    {
                        if (directory.Exists)
                        {
                            directory.MoveTo(pathTo);
                        }
                        else if (file.Exists)
                        {
                            file.MoveTo(pathTo);
                        }
                    }
                    catch (Exception ex)
                    {
                        PseudoConsoleUI.ShowException(ex);

                        ExceptionInFile(ex);

                        return;
                    }
                }                
            }
        }

        /// <summary>
        /// Метод создает директорию по указанному пути или в текущем каталоге
        /// </summary>
        public static void MakingDirectoryCommandExecuter()
        {
            string[] commands = Command.Split();

            Command = "";

            if (commands.Length > 1 && !commands[1].Contains('\\') && !commands[1].Contains('/'))
            {
                Directory.SetCurrentDirectory(drivesAndDirectories.CuttentDirectory.ToString());

                Directory.CreateDirectory(commands[1]);
            }
            if (commands.Length > 1 && (commands[1].Contains(":\\") || commands[1].Contains(":/"))
                && (commands[1].Contains('\\') || commands[1].Contains('/')))
            {
                Directory.CreateDirectory(commands[1]);
            }
        }

        /// <summary>
        /// Метод перемещает директорию
        /// </summary>
        /// <param name="pathFrom">string Путь откуда перемещать</param>
        /// <param name="pathTo">string Путь куда перемещать</param>
        public static void RemoveDirectoryCommandExecuter(string pathFrom, string pathTo)
        {
            if (Command.Split().Length == 3)
            {
                if ((pathFrom.Contains(":\\") || pathFrom.Contains(":/")) && !pathFrom.Contains('.')
                    && !pathTo.Contains('.') && (pathTo.Contains(":\\") || pathTo.Contains(":/")))
                {
                    DirectoryInfo directory = new DirectoryInfo(pathFrom);

                    try
                    {
                        if (directory.Exists)
                        {
                            directory.MoveTo(pathTo);
                        }
                    }
                    catch (Exception ex)
                    {
                        PseudoConsoleUI.ShowException(ex);

                        ExceptionInFile(ex);

                        return;
                    }
                }               
            }
        }

        /// <summary>
        /// Метод выводит в консоль все подкаталоги и файлы текущего каталога
        /// </summary>
        /// <returns>DrivesDirectoriesFilesArray Объект, в котором находятся данные о подкаталогах и файлах текущего каталога</returns>
        public static FileManager.DrivesDirectoriesFilesArray ShowAllSubdirectoriesAndFilesCommandExecuter()
        {
            FileManager.DrivesDirectoriesFilesArray dirFiles = new FileManager.DrivesDirectoriesFilesArray();

            DirectoryInfo ddd = drivesAndDirectories.CuttentDirectory;

            dirFiles.Directories = ddd.GetDirectories();

            dirFiles.Files = ddd.GetFiles();

            return (dirFiles);
        }

        /// <summary>
        /// Метод воспроизводит из файла Help - лист
        /// </summary>
        /// <returns>List<string> Help - лист</returns>
        public static List<string> HelpCommandExecuter()
        {
            List<string> list = new List<string>();

            if (File.Exists(@"Help.txt"))
            {

                foreach (string strings in File.ReadAllLines(@"Help.txt"))
                {
                    list.Add(strings);
                }
            }
            return list;
        }

        /// <summary>
        /// Метод записывает их в файл Exceptions.log сообщения о возникающих ошибках
        /// </summary>
        /// <param name="ex">Exception Объект, содержащий в себе данные об ошибке</param>
        public static void ExceptionInFile(Exception ex)
        {
            File.AppendAllText("Exceptions.log", $"Time:\n{DateTime.Now}\nException\n{ex}");
        }

        /// <summary>
        /// Метод считывает из консоли команды пользователя и сравнивает их со списком команд
        /// </summary>
        public static void UserCommandReader()
        {
            Command = Console.ReadLine();

            string comm = Command != "" ? Command.Split()[0] : "";

            for (int i = 0; i < commands.Count; i++)
            {
                if (commands[i] == comm)
                {
                    CommandInt = i;

                    break;
                }
            }
        }
    }
}
