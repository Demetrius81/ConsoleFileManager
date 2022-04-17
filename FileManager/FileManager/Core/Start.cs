using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileManager
{
    /// <summary>
    /// Класс устанавливает точку начала работы файлового менеджера
    /// </summary>
    internal static class Start
    {
        /// <summary>
        /// Метод запускает консоль, читает из файла сохраненный при прошлом корректном выходе статус.
        /// </summary>
        public static Varibles StartCommandExecuter(Varibles varibles)
        {
            if (File.Exists("system.bin"))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                using (FileStream fileStream = new FileStream("system.bin", FileMode.OpenOrCreate))
                {
                    varibles.DrivesAndDirs = binaryFormatter.Deserialize(fileStream) as CurrentDrivesAndDirs;
                }
                if (varibles.DrivesAndDirs is null || !varibles.DrivesAndDirs.CuttentDirectory.Exists)
                {
                    varibles.DrivesAndDirs = new CurrentDrivesAndDirs();
                }
            }
            else
            {
                varibles.DrivesAndDirs = new CurrentDrivesAndDirs();
            }
            return varibles;
        }

    }
}
