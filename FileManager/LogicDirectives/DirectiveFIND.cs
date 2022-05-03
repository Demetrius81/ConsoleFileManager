using System.IO;

namespace FileManager
{
    internal class DirectiveFIND : Directive, IDirective
    {
        private string _directiveName = "FIND";

        public string DirectiveName { get => _directiveName; }

        public Varibles RunDirective(Varibles varibles)
        {
            SVarible = varibles;

            FindCommandExecuter();

            return varibles;
        }

        /// <summary>
        /// Метод меняет местоположение текущей директории
        /// </summary>
        /// <param name="path">Принимает string значение управляющая команда</param>
        private void FindCommandExecuter()
        {
            string[] commands = SVarible.Command.Split();

            string path = commands[1];

            if (commands.Length == 2 && commands[1].Contains('.'))
            {
                GetFiles(SVarible.DrivesAndDirs.CuttentDirectory.ToString(), commands[1], SearchOption.TopDirectoryOnly);
            }
            if (commands.Length == 3 && commands[2].ToUpperInvariant() == "-A")
            {
                GetFiles(SVarible.DrivesAndDirs.CuttentDirectory.ToString(), commands[1], SearchOption.AllDirectories);
            }
            if (commands.Length == 2 && !commands[1].Contains('.'))
            {
                GetDirs(SVarible.DrivesAndDirs.CuttentDirectory.ToString(), commands[1], SearchOption.TopDirectoryOnly);
            }
            if (commands.Length == 3 && commands[2].ToUpperInvariant() == "-A")
            {
                GetDirs(SVarible.DrivesAndDirs.CuttentDirectory.ToString(), commands[1], SearchOption.AllDirectories);
            }
        }

        /// <summary>
        /// Метод получает список файлов
        /// </summary>
        private void GetFiles(string path, string searchPattern, SearchOption searchOption)
        {

            DirectoryInfo directory = new DirectoryInfo(path);

            SVarible.DrivesDirFilesArray.Files = directory.GetFiles(searchPattern, searchOption);

            SVarible = StartPrintFiles();
        }

        /// <summary>
        /// Метод получает получть список каталогов
        /// </summary>
        private void GetDirs(string path, string searchPattern, SearchOption searchOption)
        {
            DirectoryInfo directory = new DirectoryInfo(path);

            SVarible.DrivesDirFilesArray.Directories = directory.GetDirectories(searchPattern, searchOption);

            SVarible = StartPrintDirs();
        }

        /// <summary>
        /// Метод запускает вывод в консоль список всех найденых файлов
        /// </summary>
        /// <returns></returns>
        private Varibles StartPrintFiles()
        {
            NameToSerch = "FINDFILES";

            DirectivesConsole();

            PrintDirectiveSelection();

            return SVarible;
        }

        /// <summary>
        /// Метод запускает вывод в консоль список всех найденых директорий
        /// </summary>
        /// <returns></returns>
        private Varibles StartPrintDirs()
        {
            NameToSerch = "FINDDIRS";

            DirectivesConsole();

            PrintDirectiveSelection();

            return SVarible;
        }
    }
}
