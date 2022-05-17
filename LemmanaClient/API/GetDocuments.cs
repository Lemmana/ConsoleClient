using RestSharp;
using System;
using LemmanaClient.Models;
using Newtonsoft.Json;

namespace LemmanaClient.API
{
    class GetDocuments
    {
        public static DocumentsResponse getDocuments(URL url, bool local, string token, int timeOut)
        {
            Console.Out.WriteLine("Starting getting Document list");

            var client = new RestClient(url.fullServerURL + "/documents?pagesize=100&pageindex=0&training=false");
            client.Timeout = timeOut;

            // use certificate
            if(local)
                client = Certificate.setCertificate(client);

            var request = new RestRequest(Method.GET);
            request.AddHeader("x-auth-token", token);
            request.AddHeader("host", url.serverAddress + ":" + url.port);

            IRestResponse response = client.Execute(request);
            DocumentsResponse documentsResponse = new DocumentsResponse();

            try
            {
                if (response.StatusCode.ToString() != "OK")
                    return documentsResponse;
                documentsResponse.statusCode = response.StatusCode.ToString();
                documentsResponse.responseStatus = response.ResponseStatus.ToString();

                if (response.StatusCode.ToString() == "OK")
                {
                    documentsResponse.docs = JsonConvert.DeserializeObject<Docs>(response.Content);
                }
            }catch(Exception e)
            {
                Console.Out.WriteLine(e);
            }
			response = null;
			client = null;
            return documentsResponse;
        }
    }
}
