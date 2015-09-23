using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class FullDirectoryTraversal
{
    static void Main()
    {
        string[] folders = Directory.GetDirectories(Directory.GetCurrentDirectory());
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        using (StreamWriter clearOrCreate = new StreamWriter(desktop + @"\" + "report.txt"))
        {
            clearOrCreate.Write(string.Empty);   
        }
        ListFilesInDirectoryToTxtFile(Directory.GetCurrentDirectory());
        foreach (var subfolder in folders)
        {
            ListFilesInDirectoryToTxtFile(subfolder);
        }
        Console.WriteLine("Done, please check your Desktop folder.");
    }
    static void ListFilesInDirectoryToTxtFile(string currentDir)
    {
        string[] files = Directory.GetFiles(currentDir);
        var dir = new Dictionary<string, Dictionary<string, double>>();
        // collect file info
        foreach (var file in files)
        {
            var info = new FileInfo(file);
            string extension = info.Extension;
            string name = info.Name;
            double size = info.Length;
            if (!dir.Keys.Contains(extension))
            {
                dir.Add(extension, new Dictionary<string, double>());
            }
            dir[extension].Add(name, size);
        }
        // sorting
        var sortedOutput = dir
            .OrderByDescending(filesCount => filesCount.Value.Keys.Count)
            .ThenBy(extension => extension.Key)
            .ThenBy(size => size.Value.Values); // sorting by filesize does not work properly
        // write to file
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        using (StreamWriter writer = new StreamWriter(desktop + @"\" + "report.txt", true))
        {
            writer.WriteLine(">>" + currentDir);
            foreach (var ext in sortedOutput)
            {
                writer.WriteLine(ext.Key);
                foreach (var file in ext.Value)
                {
                    writer.WriteLine("--{0} - {1:F3}kb", file.Key, file.Value / 1024);
                }
            }
        }
    }
}
