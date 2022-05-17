using System;
using LemmanaClient.API;
using LemmanaClient.Models;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;

/*
 * Lemmana API Sample Code - NOT FOR PRODUCTION USE
 * This program is intended to assist in the development process for working with the Lemmana REST service
 * It is up to the program developer to test any implementation they use in production.
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
 * documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
 * the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, 
 * and to permit persons to whom the Software is furnished to do so, subject to the following conditions: 
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
 * TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
 * THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
 * CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS 
 * IN THE SOFTWARE.
 * 
 * Makes use of NewtonSoft for JSON De-Serialization : License details - https://github.com/JamesNK/Newtonsoft.Json/blob/master/LICENSE.md
 * Makes use of RestSharp for HTTP Client : License details - https://github.com/restsharp/RestSharp/blob/master/LICENSE.txt
 * Use of PostMan is recommended for building and testing the API endpoints : https://www.getpostman.com/
 * 
 * Please ensure you/your company have the legal rights to use NewtonSoft, RestSharp and Postman in your software builds. 
 * This is not the responsibility of Lemmana.
 */

namespace LemmanaClient
{
    static class Program
    {
        const bool local = true; // set to false to specify a remote server that requires a certificate. name the certificate Lemmana.crt and place in the Certificate directory
        static URL urlLocal = new URL("https://192.168.0.149:8082");
        static URL urlRemote = new URL("https://api.lemmana.com");
        const string tokenLocal = ""; // set to your account token
        const string tokenRemote = ""; // set to your account token

        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            String[] files = { "Test.pdf" }; // comma separated list of files to upload from the TestFiles directory
			Parallel.ForEach(files, s => ProcessFile(s));
			stopWatch.Stop();
            long duration = stopWatch.ElapsedMilliseconds;
            Console.Out.WriteLine("completed in " + (duration / 1000).ToString() + " seconds");
        }

        public static void ProcessFile(String fileName) {
            Run(fileName);
        }

        public static void Run(String file)
        {
            try
            {
                string token = local ? tokenLocal : tokenRemote;
                URL url = local ? urlLocal : urlRemote;

                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                // upload document
                DocumentResponse uploadResponse = UploadDocument.uploadFile(url, token, local, 1000000, false, true, false, "./TestFiles/" + file);

                // get uploaded document
                DocumentResponse documentResponse = GetDocument.getDocument(url, uploadResponse.document.id, local, token, 1000000);

                if (documentResponse.statusCode == "Created")
                {
                    if (documentResponse.document.classification != null)
                    {
                        Console.Out.WriteLine("classification id: " + documentResponse.document.classification.id);
                        Console.Out.WriteLine("classification name: " + documentResponse.document.classification.name);
                        Console.Out.WriteLine("classification probability: " + documentResponse.document.classification.probability);
                    }
                    // delete document
                    //DeleteDocument.deleteDocument(url, token, local, documentResponse.document.id, 50000);
                }
                else
                {
                    throw new Exception("Error uploading or deleting.");
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e);
            }
            
        }
    }
}
