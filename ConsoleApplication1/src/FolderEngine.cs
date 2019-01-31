using System;
using System.IO;

namespace ConsoleApplication1
{
    public class FolderEngine
    {
        private readonly string pathToFolder;
        private readonly long folderSizeByte;
        private readonly long folderSizeMB;

        private readonly string[] allFilesPaths;
        private readonly int countOfFiles;

        public FolderEngine(string pathToFolder)
        {
            this.pathToFolder = pathToFolder;
            // Get array of all file names.

            try
            {
                allFilesPaths = Directory.GetFiles(this.pathToFolder, "*.*", SearchOption.AllDirectories);
            }
            catch (Exception e)
            {
                Console.WriteLine("Some problem with files: " + e.Message);
                throw;
            }
            countOfFiles = allFilesPaths.Length;

            folderSizeByte = GetDirectorySize(); //Generate info about folder size(at all subfolders too)
            folderSizeMB = folderSizeByte / 1024 / 1024; //Cast folder size to megabyte(more comfortable) 
        }

        private long GetDirectorySize()
        {
            long filesSizeSum = 0;
            // Calculate total bytes of all files in a loop.
            foreach (string name in allFilesPaths)
            {
                FileInfo info = new FileInfo(name);
                filesSizeSum += info.Length;
            }

            return filesSizeSum;
        }


        public string[] AllFilesPaths
        {
            get { return allFilesPaths; }
        }

        public int CountOfFiles
        {
            get { return countOfFiles; }
        }

        public string PathToFolder
        {
            get { return pathToFolder; }
        }

        public long FolderSizeByte
        {
            get { return folderSizeByte; }
        }

        public long FolderSizeMb
        {
            get { return folderSizeMB; }
        }
    }
}