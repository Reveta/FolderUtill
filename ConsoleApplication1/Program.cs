using System;
using System.IO;

namespace ConsoleApplication1
{
    internal class Program
    {
        static void Main()
        {
            //First path - get all size
            FolderEngine fEngine = new FolderEngine("C:\\sourceFolder\\soft");
            Console.WriteLine(fEngine.FolderSizeMb);


//          Second path - use for % method
            long sizeOfArchivedData = 0;
            foreach (string path in fEngine.AllFilesPaths)
            {
                FileInfo file = new FileInfo(path);
                sizeOfArchivedData += file.Length;
                
                
                //Повертає відсоток завантажених файлів, помісти в форму
                long prosent = getProsentOf(sizeOfArchivedData, fEngine.FolderSizeByte); 
                
                //!!!!!!!!!!!!!!!!!!!!//
                //Встав сюди код для архівування.
                //!!!!!!!!!!!!!!!!!!!!//
            }
        }

        static long getProsentOf(long actual, long fullNumber)
        {
            long result = actual / (fullNumber / 100);
            return result;
        }
    }
}