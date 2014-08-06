using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Globalization;
using System.Threading.Tasks;
using Ames.Entities;

namespace Ames.Component.Web {

    
    
    class HttpPostMultiPart {

        public EFileInfo UploadFile1(string address, WebApiParameters webParams) {
            EFileInfo eFile = null;

            HttpClient client = new HttpClient();
            Uri webAddress = new Uri(address);
            client.BaseAddress = new Uri("http://" + webAddress.Authority + "/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            

            string serviceUrl = "api/efile";
            HttpResponseMessage response = client.PostAsJsonAsync(serviceUrl, webParams).Result;
            if (response.IsSuccessStatusCode) {
                // Parse the response body. Blocking!
                eFile = response.Content.ReadAsAsync<EFileInfo>().Result;
              
            }
            return eFile;
        }
        /*
        public void UploadFile(string address, IEnumerable<UploadFileInfo> files, Dictionary<string,string> values) {
            var request = WebRequest.Create(address);
            request.Method = "POST";
            var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x", NumberFormatInfo.InvariantInfo);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            boundary = "--" + boundary;

            using (var requestStream = request.GetRequestStream()) {
                // Write the values
                foreach (string name in values.Keys) {
                    var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
                    requestStream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.ASCII.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"{1}{1}", name, Environment.NewLine));
                    requestStream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.UTF8.GetBytes(values[name] + Environment.NewLine);
                    requestStream.Write(buffer, 0, buffer.Length);
                }

                // Write the files
                foreach (var file in files) {
                    var fileBuffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
                    requestStream.Write(fileBuffer, 0, fileBuffer.Length);
                    fileBuffer = Encoding.UTF8.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"{2}", 
                        file.Name, file.Filename, Environment.NewLine));
                    requestStream.Write(fileBuffer, 0, fileBuffer.Length);
                    fileBuffer = Encoding.ASCII.GetBytes(string.Format("Content-Type: {0}{1}{1}", file.ContentType, Environment.NewLine));
                    requestStream.Write(fileBuffer, 0, fileBuffer.Length);
                    file.Stream.CopyTo(requestStream);
                    fileBuffer = Encoding.ASCII.GetBytes(Environment.NewLine);
                    requestStream.Write(fileBuffer, 0, fileBuffer.Length);
                }

                var boundaryBuffer = Encoding.ASCII.GetBytes(boundary + "--");
                requestStream.Write(boundaryBuffer, 0, boundaryBuffer.Length);
            }

            using (var response = request.GetResponse())
            using (var responseStream = response.GetResponseStream())
            using (var stream = new MemoryStream()) {
                responseStream.CopyTo(stream);
                Console.WriteLine( stream.ToArray());
            }
            return;
        }
         * */
    }
}
