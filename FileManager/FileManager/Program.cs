using System;
using System.Collections.Generic;
using System.Reflection;

namespace FileManager
{
    class Program
    {
        private static readonly List<IDirective> _directives = new List<IDirective>();



        static void Main(string[] args)
        {
            PseudoConsoleUI.WindowSettings();









            //RunConsole();
        }

        #region For delete

        ///// <summary>
        ///// Основной метод, который запускает бесконечный цикл работы программы
        ///// </summary>
        public static void RunConsole()
        {
            bool exit = false;

            UserCommands.CommandInt = -1;

            Engine.StartCommandExecuter();

            while (!exit)
            {
                PseudoConsoleUI.SetCursorPosition(UserCommands.DrivesAndDirs);

                Engine.UserCommandReader();

                string[] commandsStringArray = UserCommands.Command.Split();

                if (UserCommands.CommandInt == -1)
                {
                    continue;
                }
                switch (Engine.CommandInt)
                {
                    case 0:
                        {
                    exit = Engine.ExitCommandExecuter();

                    break;
                }
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
                case 4:
                    {
                    Engine.DeleteCommandExecuter();

                    break;
                }
                case 5:
                    {
                    Engine.DeleteTreeCommandExecuter();

                    break;
                }
                case 6:
                    {
                    Engine.MoveCommandExecuter(commandsStringArray[1], commandsStringArray[2]);

                    break;
                }
                case 7:
                    {
                    Engine.MakingDirectoryCommandExecuter();

                    break;
                }
                case 8:
                    {
                    Engine.RemoveDirectoryCommandExecuter(commandsStringArray[1], commandsStringArray[2]);

                    break;
                }
                case 9:
                    {
                    Engine.ShowAllSubdirectoriesAndFilesByPages();

                    PseudoConsoleUI.PrintDirectoryProrerties(Engine.drivesAndDirectories);

                    break;
                }
                case 10:
                    {
                    PseudoConsoleUI.WriteHelp(Engine.HelpCommandExecuter());

                    break;
                }
                case 11:
                    {
                    Engine.FilePropertiesCommandExecuter();

                    break;
                }
                case 12:
                    {
                    Engine.ProcessCommandExecuter();

                    break;
                }
                default:
                    {
                    break;
                }

            }
            UserCommands.CommandInt = -1;
            }
        }

            #endregion

        //    public static void RunConsole()
        //{
        //}


        

        /// <summary>
        /// Метод при помощи механизмов класса System.Reflection динамически подключает библиотеку классов
        /// </summary>
        private static void Tasks()
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            Type[] types = asm.GetTypes();

            foreach (Type type in types)
            {
                FieldInfo field = type.GetField("_directiveName");

                if (field != null)
                {
                    object obj = Activator.CreateInstance(type);

                    _directives.Add(obj as IDirective);
                }
            }
        }

        /// <summary>
        /// Метод запускает цикл по выбору и выполнению задачи
        /// </summary>
        private static void TaskSelection()
        {
            string userChoice = "";

            Tasks();

            while (userChoice != "0")
            {
                Console.Clear();

                Console.WriteLine($"Список практических работ по дисциплине \"Алгоритмы и структуры данных\"");

                foreach (IDirective directive in _directives)
                {
                    Console.WriteLine(directive.DirectiveName);
                }
                Console.WriteLine($"Введите номер задачи или 0 для выхода");

                userChoice = Console.ReadLine();

                foreach (IDirective directive in _directives)
                {
                    if (directive.DirectiveName == userChoice.ToUpperInvariant())
                    {
                        directive.RunDirective();

                        PressToExit();
                    }
                }
            }
        }

        /// <summary>
        /// Метод запрашивает нажатия любой кнопки
        /// </summary>
        private static void PressToExit()
        {
            Console.WriteLine($"Press any key to exit...");

            Console.ReadKey();
        }

    }
}
