using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace FileManager
{
    public static class Core
    {
        private static List<IDirective> _directives = new List<IDirective>();

        private static Varibles _varibles = new Varibles();

        internal static Varibles Varibles { get => _varibles; set => _varibles = value; }

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
            Varibles.Exit = false;

            Varibles = Start.StartCommandExecuter(Varibles);

            Directives();
            


            PseudoConsoleUI.WindowSettings();////????????????????????????????????

            while (!Varibles.Exit)
            {
                Varibles.Command = "";

                PseudoConsoleUI.SetCursorPosition(Varibles.DrivesAndDirs);/////????????????????????

                Varibles.Command = Console.ReadLine();////??????????????????????????????????????????

                if (Varibles.Command.Contains(".EXE") ||
                    Varibles.Command.Contains(".COM") ||
                    Varibles.Command.Contains(".BAT"))
                {
                    Varibles.Command = String.Format(Varibles.DrivesAndDirs.CuttentDirectory.ToString()
                        + Varibles.Command);

                    ProcessStartInfo startInfo = new ProcessStartInfo(Varibles.Command);

                    Process process = new Process();

                    process.StartInfo = startInfo;

                    try
                    {
                        process.Start();
                    }
                    catch (Exception ex)
                    {
                        Exeptions.ShowException(ex);//???????????????????????????

                        Exeptions.ExceptionInFile(ex);//?????????????????????????????
                    }
                    continue;
                }
                string[] commandsStringArray = Varibles.Command.Split();

                foreach (IDirective directive in _directives)
                {
                    if (directive.DirectiveName == commandsStringArray[0].ToUpperInvariant())
                    {
                        Varibles = directive.RunDirective(Varibles);
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
                PropertyInfo field = type.GetProperty("DirectiveName");

                if (!(field is null) && !type.IsInterface)
                {
                    object obj = Activator.CreateInstance(type);

                    _directives.Add(obj as IDirective);
                }
            }
        }
    }
}
