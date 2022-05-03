using System.IO;

namespace FileManager
{
    /// <summary>
    /// Класс директивы создания директории
    /// </summary>
    internal class DirectiveMD : Directive, IDirective
    {
        private const string _directiveName = "MD";

        public string DirectiveName { get => _directiveName; }

        public Varibles RunDirective(Varibles varibles)
        {
            SVarible = varibles;

            MakingDirectoryCommandExecuter();            

            return varibles;
        }

        /// <summary>
        /// Метод создает директорию по указанному пути или в текущем каталоге
        /// </summary>
        public static void MakingDirectoryCommandExecuter()
        {
            string[] commands = SVarible.Command.Split();

            SVarible.Command = "";

            if (commands.Length > 1 && !commands[1].Contains('\\') && !commands[1].Contains('/'))
            {
                Directory.SetCurrentDirectory(SVarible.DrivesAndDirs.CuttentDirectory.ToString());

                Directory.CreateDirectory(commands[1]);
            }
            if (commands.Length > 1 && (commands[1].Contains(":\\") || commands[1].Contains(":/"))
                && (commands[1].Contains('\\') || commands[1].Contains('/')))
            {
                Directory.CreateDirectory(commands[1]);
            }
        }
    }
}
