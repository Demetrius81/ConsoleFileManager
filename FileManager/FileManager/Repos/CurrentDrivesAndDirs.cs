using System;
using System.IO;

namespace FileManager
{
    /// <summary>
    /// Класс для хранения текущего состояния программы
    /// </summary>
    [Serializable]
    public class CurrentDrivesAndDirs
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
        public CurrentDrivesAndDirs()
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
}
