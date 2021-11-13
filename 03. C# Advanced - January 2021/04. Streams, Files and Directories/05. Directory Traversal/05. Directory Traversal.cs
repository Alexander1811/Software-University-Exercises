using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P05_DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDirectory = Console.ReadLine();

            string[] files = Directory.GetFiles(inputDirectory);

            Dictionary<string, Dictionary<string, double>> filesData = new Dictionary<string, Dictionary<string, double>>();

            GetFilesData(files, filesData);

            filesData = filesData
                .OrderByDescending(kvp => kvp.Value.Count)
                .ThenBy(kvp => kvp.Key)
                .ToDictionary(a => a.Key, b => b.Value);
            List<string> orderedData = OrderData(filesData);

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "report.txt");

            File.WriteAllLines(path, orderedData);
        }

        private static List<string> OrderData(Dictionary<string, Dictionary<string, double>> filesData)
        {
            List<string> orderedData = new List<string>();

            foreach (KeyValuePair<string, Dictionary<string, double>> extensionType in filesData)
            {
                orderedData.Add(extensionType.Key);
                foreach (KeyValuePair<string, double> data in extensionType.Value.OrderBy(KeyValuePair => KeyValuePair.Value))
                {
                    string name = data.Key;
                    double size = data.Value;
                    orderedData.Add($"--{name} - {size}kb");
                }
            }

            return orderedData;
        }

        private static void GetFilesData(string[] files, Dictionary<string, Dictionary<string, double>> filesData)
        {
            foreach (string filePath in files)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                string fileName = fileInfo.Name;
                string extension = fileInfo.Extension;
                long size = fileInfo.Length;
                double kbSize = Math.Round(size / 1024.0, 3);

                if (!filesData.ContainsKey(extension))
                {
                    filesData.Add(extension, new Dictionary<string, double>());
                }

                filesData[extension].Add(fileName, kbSize);
            }
        }
    }
}
