
namespace FileManager
{
    /// <summary>
    /// Класс директивы вызова диспетчера процессов
    /// </summary>
    internal class DirectivePROC : Directive, IDirective
    {
        private const string _directiveName = "PROC";

        public string DirectiveName { get => _directiveName; }

        public Varibles RunDirective(Varibles varibles)
        {
            SVarible = varibles;

            SVarible.TaskManager = new BasicLogic();

            NameToSerch = DirectiveName;

            DirectivesConsole();

            PrintDirectiveSelection();

            return varibles;
        }

        /// <summary>
        /// Метод распознает команду управления процессами
        /// </summary>
        public static void ProcessCommandExecuter()
        {
            string[] commands = SVarible.Command.Split();

            if (commands.Length == 2)
            {
                if (commands[1] == "-DEL")
                {
                    DeleteProcessCall();
                }
                if (commands[1] == "-CRT")
                {
                    CreateProcessCall();
                }
            }
            if (commands.Length == 1)
            {
                PrintProcessesCall();
            }
        }

        /// <summary>
        /// Метод вызывает логику вывода в консоль всех активных процессов
        /// </summary>
        private static void PrintProcessesCall()
        {
            NameToSerch = "PROCPRINTALL";

            DirectivesConsole();

            PrintDirectiveSelection();
        }

        /// <summary>
        /// Метод вызывает логику удаления процесса
        /// </summary>
        private static void DeleteProcessCall()
        {
            NameToSerch = "PROCDELETE";

            DirectivesConsole();

            PrintDirectiveSelection();
        }

        /// <summary>
        /// Метод вызывает логику создания процесса
        /// </summary>
        private static void CreateProcessCall()
        {
            NameToSerch = "PROCCREATE";

            DirectivesConsole();

            PrintDirectiveSelection();
        }
    }
}
