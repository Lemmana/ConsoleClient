using RestSharp;
using System;
using LemmanaClient.Models;
using Newtonsoft.Json;

namespace LemmanaClient.API
{
    class GetDocument
    {
        public static DocumentResponse getDocument(URL url, String docId, bool local, string token, int timeOut)
        {
            Console.Out.WriteLine("Starting getting Document list");
            var client = new RestClient(url.fullServerURL + "/documents/" + docId);
            client.Timeout = timeOut;
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("X-Auth-Token", token);
            IRestResponse response = client.Execute(request);
            DocumentResponse getDocumentResponse = new DocumentResponse();
            getDocumentResponse.statusCode = response.StatusCode.ToString();
            getDocumentResponse.responseStatus = response.ResponseStatus.ToString();
            Console.Out.WriteLine("response status code: " + response.StatusCode.ToString() + " response status: " + response.ResponseStatus.ToString() + " content: " + response.Content);
            getDocumentResponse.document = JsonConvert.DeserializeObject<Document>(response.Content);
            
            if (response.StatusCode.ToString() == "OK")
            {
                getDocumentResponse.statusCode = "Created";
            }
            else if( response.StatusCode.ToString() == "Accepted")
            {
                getDocumentResponse.statusCode = "Accepted";
            }

            return getDocumentResponse;
        }
    }
}
