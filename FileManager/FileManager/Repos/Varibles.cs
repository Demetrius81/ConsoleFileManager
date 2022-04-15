using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    public class Varibles
    {
        /// <summary>
        /// Поле для хранения текущей команды пользователя
        /// </summary>
        private string _command;

        /// <summary>
        /// Свойство для доступа к полю для хранения текущей команды пользователя
        /// </summary>
        public string Command { get => _command.ToUpperInvariant(); set => _command = value; }
                
        /// <summary>
        /// Объект для хранения текущего состояния системы
        /// </summary>
        private CurrentDrivesAndDirs _drivesAndDirs = new CurrentDrivesAndDirs();

        public CurrentDrivesAndDirs DrivesAndDirs { get => _drivesAndDirs; set => _drivesAndDirs = value; }


        private DrivesDirsFilesArray _drivesDirFilesArray = new DrivesDirsFilesArray();

        public DrivesDirsFilesArray DrivesDirFilesArray { get => _drivesDirFilesArray; set => _drivesDirFilesArray = value; }

        private List<string> _files = new List<string>();

        public List<string> Files { get => _files; set => _files = value; }

        private bool _exit;

        public bool Exit { get => _exit; set => _exit = value; }

        private int _userPage;

        public int UserPage { get => _userPage; set => _userPage = value; }

        private FileInfo _varFile;

        public FileInfo VarFile { get => _varFile; set => _varFile = value; }


        private BasicLogic _taskManager;

        public BasicLogic TaskManager { get => _taskManager; set => _taskManager = value; }
    }
}
