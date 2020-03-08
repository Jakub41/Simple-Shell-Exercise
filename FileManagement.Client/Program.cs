using FileManagement.BLL;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace FileManagementSystem
{
    class Program
    {
        [DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);
        private static string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
        
        static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to File Management Program using System.IO!");
            _filePath += @"\AllFiles";
            while (true)
            {

                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "dir" || userInput.ToLower() == "is")
                {
                    CommonBLL.ShowCurrentDirectoryContent();
                }
                else if (userInput.ToLower() == "cd" || userInput.ToLower() == "pwd")
                {
                    string currentdirectory = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
                    Console.WriteLine(currentdirectory);
                }
                else if (userInput.ToLower() == "cd..")
                {
                    string upTwoDir = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"..\"));
                    Console.WriteLine(upTwoDir);
                }
                else if (userInput.Length > 1 && userInput.Contains("cd"))
                {
                    CommonBLL.GetCurrentDirectory(userInput);
                }
                else if (userInput.Length > 1 && userInput.Contains("del"))
                {
                    string currentdirectory = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
                    string filename = userInput.Replace("del", "").Trim();
                    CommonBLL.Delete(currentdirectory, filename);
                }
                else if (userInput.Length > 1 && userInput.Contains("mv"))
                {
                    string currentdirectory = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
                    string filedirectory = userInput.Replace("mv", "").Trim();
                    string[] filename = filedirectory.Split(' ');
                    CommonBLL.DirectoryCopy(currentdirectory, filename[0], filename[1]);
                }
                else if (userInput.ToLower() == "quit" || userInput.ToLower() == "exit")
                {

                    Environment.Exit(0);
                    System.Threading.Thread.Sleep(300); 
                    //AppDomain.CurrentDomain.ProcessExit += (s, ev) =>
                    //{
                    //    Console.WriteLine("process exit");
                    //    Console.ReadLine();
                    //};
                }
            }
        }
       
    }
}
