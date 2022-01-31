using System;


namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            PseudoConsoleUI.WindowSettings();

            RunConsole();
        }

        /// <summary>
        /// Основной метод, который запускает бесконечный цикл работы программы
        /// </summary>
        public static void RunConsole()
        {
            bool exit = false;

            Engine.CommandInt = -1;

            Engine.StartCommandExecuter();

            while (!exit)
            {
                PseudoConsoleUI.SetCursorPosition(Engine.drivesAndDirectories.CuttentDirectory.ToString().ToUpperInvariant());

                Engine.UserCommandReader();

                string[] commandsStringArray = Engine.Command.Split();

                if (Engine.CommandInt == -1)
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
                    case 1:
                        {
                            Engine.ChangeDirectoryCommandExecuter(commandsStringArray[1]);
                            
                            break;
                        }
                    case 2:
                        {
                            Engine.ClearConsoleCommandExecuter();

                            break;
                        }
                    case 3:
                        {
                            PseudoConsoleUI.ShowCopyCommand(Engine.CopyCommandExecuter());

                            break;
                        }
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
                            PseudoConsoleUI.WriteAllSubdirectoriesAndFiles(Engine.ShowAllSubdirectoriesAndFilesCommandExecuter());

                            break;
                        }
                    case 10:
                        {
                            PseudoConsoleUI.WriteHelp(Engine.HelpCommandExecuter());

                            break;
                        }
                    default:
                        {
                            break;
                        }

                }
                Engine.CommandInt = -1;
            }
        }
    }
}
