using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace FileManagement.BLL
{
   public static class CommonBLL
    {
        public static int ReadAnIntegerInputFromTheUser()
        {
            int result;
            while (true)
            {
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out result))
                    return result;

                Console.WriteLine("Please enter a valid integer number:");
            }
        }
        public static void ShowCurrentDirectoryContent()
        {
            // Get the subdirectories for the specified directory.
            string currentdirectory = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            DirectoryInfo dir = new DirectoryInfo(currentdirectory);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + currentdirectory);
            }



            // Get the files in the directory and copy them to the new location.

            Console.WriteLine("Total Folders:" + dirs.Length);
            foreach (DirectoryInfo diri in dirs)
            {
                Console.WriteLine("Folder Name :" + diri.Name);

            }
            Console.WriteLine("===================================================\n");
            foreach (DirectoryInfo diri in dirs)
            {
                Console.WriteLine("Folder Name :" + diri.Name);
                FileInfo[] files = diri.GetFiles();

                Console.WriteLine("Total Files:" + files.Length);
                foreach (FileInfo file in files)
                {
                    Console.WriteLine("File Name :" + file.Name);
                }
                Console.WriteLine("===================================================\n");
            }

        }

        public static void ShowDirectoryContent(string sourceDirName)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }



            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            Console.WriteLine("Total Files:" + files.Length);
            foreach (FileInfo file in files)
            {
                Console.WriteLine(file.FullName);
            }

        }

        public static void DirectoryCopy(string sourceDirName, string destDirName, string filename)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.

            foreach (DirectoryInfo diri in dirs)
            {
                FileInfo[] files = diri.GetFiles();

                foreach (FileInfo file in files)
                {
                    if (file.Name == filename)
                    {
                        string temppath = Path.Combine(destDirName, filename);
                        file.MoveTo(temppath, false);
                        Console.WriteLine("File moved to " + destDirName);
                    }
                }
            }
            //
            // If copying subdirectories, copy them and their contents to new location.
            //if (copySubDirs)
            //{
            //    foreach (DirectoryInfo subdir in dirs)
            //    {
            //        string temppath = Path.Combine(destDirName, subdir.Name);
            //        DirectoryCopy(subdir.FullName, temppath, copySubDirs);
            //    }
            //}
        }
        public static void Delete(string sourceDirName, string filename)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();
            int deletecount = 0;
            try
            {
                // Check if file exists with its full path    
                foreach (DirectoryInfo diri in dirs)
                {

                    if (File.Exists(Path.Combine(diri.FullName, filename)))
                    {
                        // If file found, delete it    
                        File.Delete(Path.Combine(diri.FullName, filename));
                        Console.WriteLine("File deleted.");
                        deletecount++;
                    }


                }
                if (deletecount == 0)
                {
                    Console.WriteLine("File not found");
                }
            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
            }

            Console.ReadKey();

        }
        public static void GetCurrentDirectory(string userInput)
        {
            string currentdirectory = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            string foldername = userInput.Replace("cd", "").Trim();
            currentdirectory += @"\" + foldername;
            DirectoryInfo dir = new DirectoryInfo(currentdirectory);
            if (!dir.Exists)
            {
                currentdirectory = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
                currentdirectory += @"\..\" + foldername;
            }
            FileInfo[] files = dir.GetFiles();
            Console.WriteLine("Total Files:" + files.Length);
            foreach (FileInfo file in files)
            {
                Console.WriteLine(file.FullName);
            }
        }
    }
}
