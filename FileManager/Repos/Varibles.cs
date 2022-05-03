using System.Collections.Generic;
using System.IO;

namespace FileManager
{
    /// <summary>
    /// Класс глобальных переменных
    /// </summary>
    public class Varibles
    {

        private string _command;

        /// <summary>
        /// Свойство для хранения текущей команды пользователя
        /// </summary>
        public string Command { get => _command.ToUpperInvariant(); set => _command = value; }

        private CurrentDrivesAndDirs _drivesAndDirs;

        /// <summary>
        /// Свойство доступа к логическим дискам и директориям
        /// </summary>
        public CurrentDrivesAndDirs DrivesAndDirs { get => _drivesAndDirs; set => _drivesAndDirs = value; }

        private DrivesDirsFilesArray _drivesDirFilesArray;

        /// <summary>
        /// Свойство для доступа к массивам с логическими дисками, директориями и файлами
        /// </summary>
        public DrivesDirsFilesArray DrivesDirFilesArray { get => _drivesDirFilesArray; set => _drivesDirFilesArray = value; }

        private List<string> _files;

        /// <summary>
        /// Свойство для доступа к переменной списку строк
        /// </summary>
        public List<string> Files { get => _files; set => _files = value; }

        private bool _exit;

        /// <summary>
        /// Свойство для доступа к логической переменной-триггера для выхода из бесконечного цикла
        /// </summary>
        public bool Exit { get => _exit; set => _exit = value; }

        private int _userPage;

        /// <summary>
        /// Свойство для доступа к целочисленной переменной
        /// </summary>
        public int UserPage { get => _userPage; set => _userPage = value; }

        private FileInfo _varFile;

        /// <summary>
        /// Свойство для доступа к переменной типа FileInfo
        /// </summary>
        public FileInfo VarFile { get => _varFile; set => _varFile = value; }

        private BasicLogic _taskManager;

        /// <summary>
        /// Свойство для доступа к переменной с логикой диспетчера процессов
        /// </summary>
        public BasicLogic TaskManager { get => _taskManager; set => _taskManager = value; }

        public Varibles()
        {
            _command = "";

            _drivesAndDirs = new CurrentDrivesAndDirs();

            _drivesDirFilesArray = new DrivesDirsFilesArray();

            _files = new List<string>();

            _exit = false;

            _userPage = -1;
        }
    }
}
