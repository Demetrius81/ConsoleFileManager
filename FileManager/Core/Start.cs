using Newtonsoft.Json;
using System.IO;

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
            if (File.Exists("path.json"))
            {
                string temp = File.ReadAllText("path.json");

                string[] tempArr = JsonConvert.DeserializeObject<string>(temp).Split("|W|");

                if (tempArr.Length == 2)
                {
                    varibles.DrivesAndDirs.CurrentDrive = new DriveInfo(tempArr[0]);

                    varibles.DrivesAndDirs.CuttentDirectory = new DirectoryInfo(tempArr[1]);
                }
                if (varibles.DrivesAndDirs is null || !varibles.DrivesAndDirs.CuttentDirectory.Exists)
                {
                    varibles.DrivesAndDirs = new CurrentDrivesAndDirs();
                }
            }
            return varibles;
        }
    }
}
