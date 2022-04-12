using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    internal class UserCommands
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
        /// Поле для хранения текущей команды управления циклом
        /// </summary>
        private static int _commandInt;

        /// <summary>
        /// Свойство для доступа к полю для хранения текущей команды управления циклом
        /// </summary>
        public static int CommandInt { get => _commandInt; set => _commandInt = value; }

        /// <summary>
        /// Объект для хранения текущего состояния системы
        /// </summary>
        private static DrivesAndDirectories _drivesAndDirs = new DrivesAndDirectories();

        public static DrivesAndDirectories DrivesAndDirs { get => _drivesAndDirs; set => _drivesAndDirs = value; }


        private static DrivesDirectoriesFilesArray _drivesDirFilesArray = new DrivesDirectoriesFilesArray();

        public static DrivesDirectoriesFilesArray DrivesDirFilesArray { get => _drivesDirFilesArray; set => _drivesDirFilesArray = value; }
    }
}
