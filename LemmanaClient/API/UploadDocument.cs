using RestSharp;
using System;
using LemmanaClient.Models;
using Newtonsoft.Json;

namespace LemmanaClient.API
{
    class UploadDocument
    {
        public static DocumentResponse uploadFile(URL url, string token, bool local, int timeOut, bool isTraining, bool findClassification, bool findEntities, string filePath)
        {
            var client = new RestClient(url.fullServerURL + "/documents?training=" + isTraining.ToString() + "&classification=" + findClassification.ToString() + "&entities=" + findEntities.ToString());
            client.Timeout = timeOut;

            // use certificate
            if(!local)
                client = Certificate.setCertificate(client);

            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("X-Auth-Token", token);
            if (filePath.EndsWith("pdf"))
                request.AddFile("file", filePath, "application/pdf");
            else if (filePath.EndsWith("jpg"))
                request.AddFile("file", filePath, "image/jpeg");
            else if (filePath.EndsWith("txt"))
                request.AddFile("file", filePath, "text/plain");
            else if (filePath.EndsWith("doc"))
                request.AddFile("file", filePath, "application/msword");
            else if (filePath.EndsWith("docx"))
                request.AddFile("file", filePath, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
			else if (filePath.EndsWith("tif"))
				request.AddFile("file", filePath, "image/tiff");
            
            try
            {
                Console.Out.WriteLine("sending " + filePath);
                IRestResponse response = client.Execute(request);
                DocumentResponse uploadResponse = new DocumentResponse();
                uploadResponse.statusCode = response.StatusCode.ToString();
                uploadResponse.responseStatus = response.ResponseStatus.ToString();
                Console.Out.WriteLine("response status code: " + response.StatusCode.ToString() + " response status: " + response.ResponseStatus.ToString() + " content: " + response.Content);
                uploadResponse.document = JsonConvert.DeserializeObject<Document>(response.Content); 
                var docId = uploadResponse.document.id;

                // document completed before server side timeout and the processed document has been returned
                if (response.StatusCode.ToString() == "Created")
                {
                    Console.WriteLine("document created: " + docId);
                }
                // the document has been accepted by the server and the status can be polled until complete
                else if (response.StatusCode.ToString() == "Accepted")
                {	
                    Console.Out.WriteLine("document accepted: " + docId);
                    System.Threading.Thread.Sleep(10000);
                    Console.WriteLine("checking status: " + uploadResponse.document.id);
                    client = new RestClient(url.fullServerURL + "/documents/" + docId);
                    client.Timeout = timeOut;
                    var complete = false;
                    while (!complete)
                    {
                        DocumentResponse documentResponse = GetDocument.getDocument(url, docId, local, token, timeOut);
                        if(documentResponse.statusCode == "Created")
                        {
                            complete = true;
                        }
                    }
				}
                else
                {
                    Console.Out.WriteLine("error status code: " + response.StatusCode.ToString() + " response status: " + response.ResponseStatus.ToString() + " content: " + response.Content);
                }
                response = null;
                client = null;
                return uploadResponse;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
            return null;
        }
    }
}
