using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    internal static class StartStop
    {

        /// <summary>
        /// Метод запускает консоль, читает из файла сохраненный при прошлом корректном выходе статус.
        /// </summary>
        public static void StartCommandExecuter()
        {
            if (File.Exists("path.json"))
            {
                string temp = File.ReadAllText("path.json");

                string[] tempArr = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(temp).Split("|W|");

                SystemVaribles.DrivesAndDirs.CurrentDrive = new DriveInfo(tempArr[0]);

                SystemVaribles.DrivesAndDirs.CuttentDirectory = new DirectoryInfo(tempArr[1]);

                if (!SystemVaribles.DrivesAndDirs.CuttentDirectory.Exists)
                {
                    SystemVaribles.DrivesAndDirs = new CurrentDrivesAndDirs();
                }
            }
            else
            {
                SystemVaribles.DrivesAndDirs = new CurrentDrivesAndDirs();
            }
        }

        /// <summary>
        /// Метод завершает работу консоли и сохраняет параметры программы в файл.
        /// </summary>
        /// <returns>Значение типа bool своего рода выключатель программы</returns>
        /// 
        public static bool ExitCommandExecuter()
        {
            string temp = $"{SystemVaribles.DrivesAndDirs.CurrentDrive.Name}|W|{SystemVaribles.DrivesAndDirs.CuttentDirectory.ToString()}";

            temp = JsonConvert.SerializeObject(temp);

            File.WriteAllText("path.json", temp);

            return true;
        }

    }
}
