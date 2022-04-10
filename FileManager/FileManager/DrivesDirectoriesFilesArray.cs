using System.IO;

namespace FileManager
{
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
