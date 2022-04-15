using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
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

                varibles.DrivesAndDirs.CurrentDrive = new DriveInfo(tempArr[0]);

                varibles.DrivesAndDirs.CuttentDirectory = new DirectoryInfo(tempArr[1]);

                if (!varibles.DrivesAndDirs.CuttentDirectory.Exists)
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
