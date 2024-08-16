using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;

namespace FolderPDFOCR_2
{
    public static class OCR
    {
        private static bool applyingOCR = false;
        private static List<Process> activeProcesses = new List<Process>();

        private static int processedFiles = 0;

        public static void Folder(string[] files, string output, int threads, Action onProgressUpdate)
        {
            applyingOCR = true;

            processedFiles = threads - 1;
            for(int i = 0; i < threads; i++)
            {
                FolderRecursive(files, i, output, onProgressUpdate);
            }
        }

        private static void FolderRecursive(string[] files, int index, string output, Action onProgressUpdate)
        {
            if (!applyingOCR)
                return;

            if(index >= files.Length)
                return;

            var destination = MultipleOCR.Utils.GetFileDestination(files[index], output);
            SingleFile(files[index], destination, () =>
            {
                onProgressUpdate.Invoke();
                FolderRecursive(files, ++processedFiles, output, onProgressUpdate);
            });
        }

        private static void SingleFile(string input, string output, Action callback)
        {
            Logger.Log($"Applying OCR to {Path.GetFileName(input)}", LogType.Info);

            string exePath = Path.Combine(Directory.GetCurrentDirectory(), "ocr", "ocr.exe");

            Process process = new Process();
            process.StartInfo.FileName = exePath;
            process.StartInfo.Arguments = $"\"{input}\" \"{output}\"";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.EnableRaisingEvents = true;

            if (!process.StartInfo.EnvironmentVariables.ContainsKey("Path"))
                process.StartInfo.EnvironmentVariables["Path"] = "";

            string tesseractPath = Path.Combine(Directory.GetCurrentDirectory(), "tesseract");
            process.StartInfo.EnvironmentVariables["Path"] += ";" + tesseractPath;

            string gsPath = Path.Combine(Directory.GetCurrentDirectory(), "gs");
            process.StartInfo.EnvironmentVariables["Path"] += ";" + gsPath;

            try
            {
                process.Start();
                activeProcesses.Add(process);

                process.Exited += (sender, e) =>
                {
                    if (!applyingOCR)
                        return;

                    string error = process.StandardError.ReadToEnd();

                    if (string.IsNullOrEmpty(error))
                        Logger.Log($"OCR Applied succesfully to {Path.GetFileName(input)}", LogType.Info);
                    else Logger.Log($"Error while applying OCR to {Path.GetFileName(input)}:\n${error}", LogType.Error);

                    activeProcesses.Remove(process);
                    callback.Invoke();
                };
            }
            catch (Exception ex)
            {
                Logger.Log($"Error starting process: {ex.Message}", LogType.Error);
            }
        }

        public static void Cancel()
        {
            applyingOCR = false;

            foreach(var process in activeProcesses)
            {
                foreach(var child in process.GetChildProcesses())
                {
                    if(child.HasExited) continue;

                    child.Kill();
                }

                if (process.HasExited) continue;

                process.Kill();
            }

            activeProcesses.Clear();
        }

        public static IEnumerable<Process> GetChildProcesses(this Process process)
        {
            List<Process> children = new List<Process>();
            ManagementObjectSearcher mos = new ManagementObjectSearcher(String.Format("Select * From Win32_Process Where ParentProcessID={0}", process.Id));

            foreach (ManagementObject mo in mos.Get())
            {
                children.Add(Process.GetProcessById(Convert.ToInt32(mo["ProcessID"])));
            }

            return children;
        }
    }
}
