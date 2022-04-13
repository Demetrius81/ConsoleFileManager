using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    internal static class SystemVaribles
    {
        /// <summary>
        /// Поле для хранения текущей команды пользователя
        /// </summary>
        private static string _command;

        /// <summary>
        /// Свойство для доступа к полю для хранения текущей команды пользователя
        /// </summary>
        public static string Command { get => _command.ToUpperInvariant(); set => _command = value; }
                
        /// <summary>
        /// Объект для хранения текущего состояния системы
        /// </summary>
        private static CurrentDrivesAndDirs _drivesAndDirs = new CurrentDrivesAndDirs();

        public static CurrentDrivesAndDirs DrivesAndDirs { get => _drivesAndDirs; set => _drivesAndDirs = value; }


        private static DrivesDirectoriesFilesArray _drivesDirFilesArray = new DrivesDirectoriesFilesArray();

        public static DrivesDirectoriesFilesArray DrivesDirFilesArray { get => _drivesDirFilesArray; set => _drivesDirFilesArray = value; }

        private static List<string> _files = new List<string>();

        public static List<string> Files { get => _files; set => _files = value; }

        private static bool _exit;

        public static bool Exit { get => _exit; set => _exit = value; }
    }
}
