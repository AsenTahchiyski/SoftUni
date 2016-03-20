namespace TraverseDir
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        private const string folderPath = @"D:\Dropbox\SoftUni\4. Data Structures\2016\2016.02.25 - Trees and Tree-Like Structures\Homework\02.TraverseDir";

        static void Main()
        {
            Console.SetBufferSize(80, 1500);

            Folder[] mainDirectoryTree = GetFoldersInDir(folderPath);
            PrintDirectoryTree(mainDirectoryTree);
        }

        private static File[] GetFilesInDir(string path)
        {
            var filesInfo = new DirectoryInfo(path).GetFiles();
            List<TraverseDir.File> files = new List<File>();
            foreach (var fileInfo in filesInfo)
            {
                File currentFile = new File(fileInfo.Name, fileInfo.Length);
                files.Add(currentFile);
            }

            return files.ToArray();
        }

        private static Folder[] GetFoldersInDir(string path)
        {
            var directoryInfo = new DirectoryInfo(path).GetDirectories();
            List<Folder> folders = new List<Folder>();
            foreach (var dir in directoryInfo)
            {
                string subFolderPath = path + "\\" + dir.Name;
                var currentDirInfo = new DirectoryInfo(subFolderPath);
                Folder currentFolder = new Folder(currentDirInfo.Name, GetFilesInDir(subFolderPath), GetFoldersInDir(subFolderPath));
                folders.Add(currentFolder);
            }

            return folders.ToArray();
        }

        static void PrintDirectoryTree(Folder[] tree)
        {
            foreach (var folder in tree)
            {
                Console.WriteLine("> " + folder.Name + " [" + GetFolderSize(folder)/1000 + "kb]");

                foreach (var file in folder.Files)
                {
                    Console.WriteLine("--- {0} - {1} kb", file.Name, file.Size / 1000);
                }

                foreach (Folder subfolder in folder.ChildFolders)
                {
                    Folder[] tempFolder = {subfolder};
                    PrintDirectoryTree(tempFolder);
                }
            }
        }

        static long GetFolderSize(Folder folder)
        {
            var currentDirFilesSize = folder.Files.Sum(f => f.Size);
            long folderSize = currentDirFilesSize;
            foreach (var childFolder in folder.ChildFolders)
            {
                folderSize += GetFolderSize(childFolder);
            }

            return folderSize;
        }
    }
}
