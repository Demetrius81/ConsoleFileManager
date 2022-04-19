using System;
using System.IO;

namespace FileManager
{
    /// <summary>
    /// Класс для хранения текущего состояния программы
    /// </summary>
    public class DrivesAndDirectories
    {
        /// <summary>
        /// Поле, где храниться текущий диск
        /// </summary>
        /// 
        private DriveInfo _currentDrive;

        /// <summary>
        /// Свойство для доступа к полю, где храниться текущий диск
        /// </summary>
        public DriveInfo CurrentDrive { get => _currentDrive; set => _currentDrive = value; }

        /// <summary>
        /// Поле, где храниться текущая директория
        /// </summary>
        private DirectoryInfo _currentDirectory;

        /// <summary>
        /// Свойство для доступа к полю, где храниться текущая директория
        /// </summary>
        public DirectoryInfo CuttentDirectory { get => _currentDirectory; set => _currentDirectory = value; }

        /// <summary>
        /// Конструктор класса. Инициализирует переменные класса
        /// </summary>
        public DrivesAndDirectories()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    CurrentDrive = drive;

                    CuttentDirectory = drive.RootDirectory;

                    break;
                }

            }
        }
    }

    /// <summary>
    /// Класс для временного хранения информации о файловой системе
    /// </summary>
    public class DrivesDirectoriesFilesArray
    {
        /// <summary>
        /// Поле, где храняться данные о дисках
        /// </summary>
        private DriveInfo[] _drives;

        /// <summary>
        /// Свойство для доступа к полю, где храняться данные о дисках
        /// </summary>
        public DriveInfo[] Drives { get => _drives; set => _drives = value; }

        /// <summary>
        /// Поле, где храняться данные о директориях
        /// </summary>
        private DirectoryInfo[] _directories;

        /// <summary>
        /// Свойство для доступа к полю, где храняться данные о директориях
        /// </summary>
        public DirectoryInfo[] Directories { get => _directories; set => _directories = value; }

        /// <summary>
        /// Поле, где храняться данные о файлах
        /// </summary>
        private FileInfo[] _files;

        /// <summary>
        /// Свойство для доступа к полю, где храняться данные о файлах
        /// </summary>
        public FileInfo[] Files { get => _files; set => _files = value; }
    }
}
