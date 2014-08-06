using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Ames.Component.Web;
using Ames.Entities;

namespace Ames.Component.EFileServer {
    public class HttpUploadEFile {


        public EFileInfo UploadEFile1(int year, int month, string location, string brand, string department, string type,
            string generateFrom, int expiryDuration, string PostActionURL, string fileName) {

            EFileInfo eFile = null;
            Dictionary<string, string> dictParam = new Dictionary<string, string> {
                {"year", year.ToString()},
                {"month", month.ToString()},
                {"location", location},
                {"brand", brand},
                {"department", department},
                {"type", type},
                {"generateFrom", generateFrom},
                {"expiryDuration", expiryDuration.ToString()}
            };

            HttpPostMultiPart webClient = new HttpPostMultiPart();

            List<UploadFileInfo> fileInfos = new List<UploadFileInfo> { 
                new UploadFileInfo {
                Name = "media",
                FileName = Path.GetFileName(fileName),
                //Stream = File.ReadAllBytes(fileName)
                ByteArray = File.ReadAllBytes(fileName)

            }
            };
            //fileInfos.First<UploadFileInfo>().Stream.LoadIntoBufferAsync().Wait();
            WebApiParameters webApiParams = new WebApiParameters {
                Parameters = dictParam,
                UploadFiles = fileInfos
            };

            eFile = webClient.UploadFile1(PostActionURL, webApiParams);

            return eFile;
        }
        /*
        public void UploadEFile(int year, int month, string location, string brand, string department, string type,
            string generateFrom, int expiryDuration, string PostActionURL, string fileName) {
            //EFileInfo eFile = null;
            Dictionary<string, string> dictParam = new Dictionary<string, string> {
                {"year", year.ToString()},
                {"month", month.ToString()},
                {"location", location},
                {"brand", brand},
                {"department", department},
                {"type", type},
                {"generateFrom", generateFrom},
                {"expiryDuration", expiryDuration.ToString()}
            };

            HttpPostMultiPart webClient = new HttpPostMultiPart();
            List<UploadFileInfo> fileInfos = new List<UploadFileInfo> { 
                new UploadFileInfo
                {
                    Name = "media",
                    Filename = Path.GetFileName(fileName),
                    Stream = File.Open(fileName, FileMode.Open)
                }
            };
            webClient.UploadFile(PostActionURL, fileInfos, dictParam);
            //return eFile;
            return;
        }
        */
    }
}
