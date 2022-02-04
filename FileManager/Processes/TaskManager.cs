using System;
using System.Diagnostics;

namespace FileManager
{
    public class BasicLogic
    {
        /// <summary>
        /// Метод создает список процессов
        /// </summary>
        /// <returns></returns>
        public static Process[] GetAllProcesses()
        {
            return Process.GetProcesses();
        }

        /// <summary>
        /// Метод убивает процесс с заданным Id
        /// </summary>
        /// <param name="processId">int Id процесса</param>
        /// <returns></returns>
        public bool KillProcess(int processId)
        {
            foreach (Process process in GetAllProcesses())
            {
                if (processId == process.Id)
                {
                    process.Kill();

                    process.WaitForExit();

                    return true;
                }

            }
            return false;
        }

        /// <summary>
        /// Метод убивает процесс (процессы) с заданным именем
        /// </summary>
        /// <param name="processName">string имя процесса</param>
        /// <returns></returns>
        public bool KillProcess(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);

            foreach (Process process in processes)
            {
                if (processName == process.ToString())
                {
                    process.Kill();

                    process.WaitForExit();

                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Метод запускает процесс по имени или URL
        /// </summary>
        /// <param name="programmName"></param>
        /// <returns></returns>
        public bool CreateNewProcess(string programmName)
        {
            ProcessStartInfo startInfo;
            if (programmName.Contains(@"http://"))
            {
                startInfo = new ProcessStartInfo()
                {
                    FileName = programmName,

                    UseShellExecute = true
                };

            }
            else
            {
                startInfo = new ProcessStartInfo(programmName);
            }
            Process process = new Process();

            process.StartInfo = startInfo;

            try
            {
                process.Start();

                return true;
            }
            catch (Exception ex)
            {
                Exeptions.ShowException(ex);

                Exeptions.ExceptionInFile(ex);

                return false;
            }
        }

        /// <summary>
        /// Метод запускает программу по указанному пути
        /// </summary>
        /// <param name="programmName">string Путь к программе</param>
        public static void CreateProcess(string programmName)
        {
            try
            {
                Process process = new Process();

                process.StartInfo = new ProcessStartInfo(programmName);

                process.Start();
            }
            catch (Exception ex)
            {
                Exeptions.ShowException(ex);

                Exeptions.ExceptionInFile(ex);

                return;
            }
        }
    }
}
