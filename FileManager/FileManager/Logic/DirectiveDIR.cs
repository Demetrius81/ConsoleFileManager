
namespace FileManager
{
    /// <summary>
    /// Класс директивы логики вывода списка подкаталогов
    /// </summary>
    internal class DirectiveDIR : Directive, IDirective
    {
        private const string _directiveName = "DIR";

        public string DirectiveName { get => _directiveName; }

        public Varibles RunDirective(Varibles varibles)
        {

            SVarible = varibles;

            NameToSerch = DirectiveName;

            ShowAllSubdirectoriesAndFilesByPages();

            return SVarible;
        }

        /// <summary>
        /// Метод распознает команды консоли и запускает соответствующую логику
        /// </summary>
        private void ShowAllSubdirectoriesAndFilesByPages()
        {
            string[] commands = SVarible.Command.Split();

            bool isOk = false;

            SVarible.UserPage = -1;

            if (commands.Length == 3)
            {
                isOk = int.TryParse(commands[2], out int page);

                page = SVarible.UserPage;
            }
            if ((commands.Length == 3 && isOk && commands[1] == "-P" && SVarible.UserPage > 0) || (commands.Length == 1))
            {
                SVarible = ShowAllSubdirsAndFiles();
            }
            if (commands.Length == 2 && (commands[1] == "\\\\" || commands[1] == "//"))
            {
                SVarible = ShowAllDrives();
            }
        }

        /// <summary>
        /// Метод запускает вывод в консоль всех подкаталогов и файлов
        /// </summary>
        /// <returns></returns>
        private Varibles ShowAllSubdirsAndFiles()
        {
            NameToSerch = "DIRSDF";

            DirectivesConsole();

            PrintDirectiveSelection();

            return SVarible;
        }

        /// <summary>
        /// Метод запускает вывод в консоль всех логических дисков
        /// </summary>
        /// <returns></returns>
        private Varibles ShowAllDrives()
        {
            NameToSerch = "DIRD";

            DirectivesConsole();

            PrintDirectiveSelection();

            return SVarible;
        }
    }
}
