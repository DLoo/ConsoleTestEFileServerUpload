using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ames.Component.EFileServer;
using Ames.Entities;

namespace ConsoleTestEFileServerUpload
{
    public class Program
    {

        static void Main(string[] args) {
            string baseUrl = "http://localhost:54017/";
            string serviceUrl = "api/efile";
            string postFileName = @"C:\Users\donaldloo\Desktop\E-Book\DSR_JS_2014-06-10.xls";
            string postFileNameYN = @"C:\Users\donaldloo\Desktop\E-Book\DSR_YN_2014-06-10.xls";
            Console.WriteLine("Ready. Press any key to continue.");
            Console.ReadLine();

            HttpUploadEFile eFile = new HttpUploadEFile();
            var eFile1 = eFile.UploadEFile(baseUrl, serviceUrl, 2014, 06, "SG", "JS", "Outlet", "DSR", "ConsoleTestEFileServerUpload", 30, postFileName);
            var eFile2 = eFile.UploadEFile(baseUrl, serviceUrl, 2014, 06, "SG", "YN", "Outlet", "DSR", "ConsoleTestEFileServerUpload", 20, postFileNameYN);
            Console.WriteLine("Completed. Press any key to Exit.");
            Console.ReadLine();
        }
    }
}
