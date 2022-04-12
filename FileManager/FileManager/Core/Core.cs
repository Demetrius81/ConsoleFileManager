using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace FileManager
{
    public static class Core
    {
        private static List<IDirective> _directives= new List<IDirective>();



        #region For delete

        /////// <summary>
        /////// Основной метод, который запускает бесконечный цикл работы программы
        /////// </summary>
        //public static void RunConsole()
        //{
        //    bool exit = false;

        //    UserCommands.CommandInt = -1;

        //    StartCommandExecuter();

        //    while (!exit)
        //    {
        //        PseudoConsoleUI.SetCursorPosition(UserCommands.DrivesAndDirs);

        //        UserCommandReader();

        //        string[] commandsStringArray = UserCommands.Command.Split();

        //        if (UserCommands.CommandInt == -1)
        //        {
        //            continue;
        //        }
        //        switch (Engine.CommandInt)
        //        {
        //            case 0:
        //                {
        //                    exit = Engine.ExitCommandExecuter();

        //                    break;
        //                }
        //case 1:
        //    {
        //    Engine.ChangeDirectoryCommandExecuter(commandsStringArray[1]);

        //    PseudoConsoleUI.PrintDirectoryProrerties(Engine.drivesAndDirectories);

        //    break;
        //}
        //case 2:
        //    {
        //    Engine.ClearConsoleCommandExecuter();

        //    break;
        //}
        //case 3:
        //    {
        //    PseudoConsoleUI.ShowCopyCommand(Engine.CopyCommandExecuter());

        //    break;
        //}
        //case 4:
        //    {
        //    Engine.DeleteCommandExecuter();

        //    break;
        //}
        //case 5:
        //    {
        //    Engine.DeleteTreeCommandExecuter();

        //    break;
        //}
        //case 6:
        //    {
        //    Engine.MoveCommandExecuter();

        //    break;
        //}
        //case 7:
        //    {
        //    Engine.MakingDirectoryCommandExecuter();

        //    break;
        //}
        //case 8:
        //    {
        //    Engine.RemoveDirectoryCommandExecuter();

        //    break;
        //}
        //case 9:
        //    {
        //    Engine.ShowAllSubdirectoriesAndFilesByPages();

        //    PseudoConsoleUI.PrintDirectoryProrerties(Engine.drivesAndDirectories);

        //    break;
        //}
        //case 10:
        //    {
        //    PseudoConsoleUI.WriteHelp(Engine.HelpCommandExecuter());

        //    break;
        //}
        //case 11:
        //    {
        //    Engine.FilePropertiesCommandExecuter();

        //    break;
        //}
        //case 12:
        //    {
        //    Engine.ProcessCommandExecuter();

        //    break;
        //}
        //            default:
        //                {
        //                    break;
        //                }

        //        }
        //        UserCommands.CommandInt = -1;
        //    }
        //}

        #endregion

        public static void RunConsole()
        {
            DirectiveSelection();
        }





        /// <summary>
        /// Метод запускает цикл по выбору и выполнению задачи
        /// </summary>
        private static void DirectiveSelection()
        {
            bool exit = false;

            StartCommandExecuter();

            Directives();

            while (exit)
            {
                PseudoConsoleUI.SetCursorPosition(UserCommands.DrivesAndDirs);

                UserCommands.Command = Console.ReadLine();

                if (UserCommands.Command.Contains(".EXE") || UserCommands.Command.Contains(".COM") || UserCommands.Command.Contains(".BAT"))
                {
                    UserCommands.Command = String.Format(UserCommands.DrivesAndDirs.CuttentDirectory.ToString() + UserCommands.Command);

                    BasicLogic.CreateProcess(UserCommands.Command);

                    continue;
                }
                string[] commandsStringArray = UserCommands.Command.Split();

                //if (UserCommands.CommandInt == -1)
                //{
                //    continue;
                //}
                
                //userChoice = Console.ReadLine();

                foreach (IDirective directive in _directives)
                {
                    if (directive.DirectiveName == commandsStringArray[0].ToUpperInvariant())
                    {
                        directive.RunDirective();
                    }
                }
            }
        }

        
        /// <summary>
        /// Метод при помощи механизмов класса System.Reflection динамически подключает библиотеку классов
        /// </summary>
        private static void Directives()
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            Type[] types = asm.GetTypes();

            foreach (Type type in types)
            {
                FieldInfo field = type.GetField("_directiveName");

                if (type.IsInterface && type.GetField("_directiveName")!=null)
                {
                    object obj = Activator.CreateInstance(type);

                    _directives.Add(obj as IDirective);
                }
            }
        }



        /// <summary>
        /// Метод запускает консоль, читает из файла сохраненный при прошлом корректном выходе статус.
        /// </summary>
        public static void StartCommandExecuter()
        {
            if (File.Exists("path.json"))
            {
                string temp = File.ReadAllText("path.json");

                string[] tempArr = JsonConvert.DeserializeObject<string>(temp).Split("|W|");

                UserCommands.DrivesAndDirs.CurrentDrive = new DriveInfo(tempArr[0]);

                UserCommands.DrivesAndDirs.CuttentDirectory = new DirectoryInfo(tempArr[1]);

                if (!UserCommands.DrivesAndDirs.CuttentDirectory.Exists)
                {
                    UserCommands.DrivesAndDirs = new DrivesAndDirectories();
                }
            }
            else
            {
                UserCommands.DrivesAndDirs = new DrivesAndDirectories();
            }
        }




        /// <summary>
        /// Метод считывает из консоли команды пользователя и сравнивает их со списком команд
        /// </summary>
        public static void UserCommandReader()
        {
            UserCommands.Command = Console.ReadLine();

            //string comm = UserCommands.Command != "" ? UserCommands.Command.Split()[0] : "";

            //for (int i = 0; i < commands.Count; i++)
            //{
            //    //if (commands[i] == comm)
                //{
                //    UserCommands.CommandInt = i;

                //    break;
                //}
                //else 
                //if (comm.Contains(".EXE") || comm.Contains(".COM") || comm.Contains(".BAT"))
                //{
                //    comm = String.Format(UserCommands.DrivesAndDirs.CuttentDirectory.ToString() + UserCommands.Command);

                //    BasicLogic.CreateProcess(comm);
                //}
            //}
        }








    }
}
