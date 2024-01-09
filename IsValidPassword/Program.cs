using Exercise.Lib;
using Microsoft.Win32;

namespace IsValidPassword
{
    public class Program
    {
        static void  Main(string[] args)
        {
            Task task = DownloadFileFromInternet.DownloadFile(args);
            Console.ReadKey();
        }
    }
}


