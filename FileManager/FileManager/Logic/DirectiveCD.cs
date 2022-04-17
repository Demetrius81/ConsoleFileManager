using System.IO;

namespace FileManager
{
    /// <summary>
    /// Класс директивы смены директории
    /// </summary>
    internal class DirectiveCD : Directive, IDirective
    {
        private string _directiveName = "CD";

        public string DirectiveName { get => _directiveName; }

        public Varibles RunDirective(Varibles varibles)
        {
            SVarible = varibles;

            ChangeDirectoryCommandExecuter();

            NameToSerch = DirectiveName;

            DirectivesConsole();

            PrintDirectiveSelection();

            return varibles;
        }

        /// <summary>
        /// Метод меняет местоположение текущей директории
        /// </summary>
        /// <param name="path">Принимает string значение управляющая команда</param>
        private void ChangeDirectoryCommandExecuter()
        {
            string[] commands = SVarible.Command.Split();

            string path = commands[1];

            if (commands.Length == 2)
            {
                if (path == null || path == "")
                {
                    return;
                }
                string temp = "";

                if (path == "..")
                {
                    DirectoryInfo tempDir = SVarible.DrivesAndDirs.CuttentDirectory.Parent;

                    if (!(tempDir is null))
                    {
                        SVarible.DrivesAndDirs.CuttentDirectory = tempDir;
                    }
                }
                if (!path.Contains(":\\") && !path.Contains(":/") && !path.Contains(".."))
                {
                    temp = $"{SVarible.DrivesAndDirs.CuttentDirectory.ToString().ToUpperInvariant()}\\{path.ToUpperInvariant()}";

                    if (Directory.Exists(temp))
                    {
                        SVarible.DrivesAndDirs.CuttentDirectory = new DirectoryInfo(temp);
                    }
                    SVarible.Command = "";
                }
                else if ((path.Contains('\\') || path.Contains('/')) && (path.Contains(":\\") || path.Contains(":/")))
                {
                    temp = $"{path}";

                    if ((temp[1] == ':') && !temp.Contains(SVarible.DrivesAndDirs.CurrentDrive.ToString().ToUpperInvariant()))
                    {
                        SVarible.DrivesAndDirs.CurrentDrive = new DriveInfo(temp.Substring(0, 2).ToUpperInvariant());
                    }
                    if (Directory.Exists(temp))
                    {
                        SVarible.DrivesAndDirs.CuttentDirectory = new DirectoryInfo(temp.ToUpperInvariant());
                    }
                }
            }
        }
    }
}
