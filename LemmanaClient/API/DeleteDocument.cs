using RestSharp;
using System;

namespace LemmanaClient.API
{
    class DeleteDocument
    {

        public static bool deleteDocument(URL url, string token, bool local, string docId, int timeOut)
        {
            var client = new RestClient(url.fullServerURL + "/documents/" + docId);
            client.Timeout = timeOut;

            // use certificate
            if(!local)
                client = Certificate.setCertificate(client);
            
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("x-auth-token", token);
            request.AddHeader("host", url.serverAddress + ":" + url.port);
            try {
            IRestResponse response = client.Execute(request);

            if (response.StatusCode.ToString() == "OK")
            {
                return true;
            }
			else
			{
                Console.Out.WriteLine("delete unexpected status: " + response.StatusCode.ToString());
				return false; 
			}
		    }catch(Exception e)
            {
                Console.Out.WriteLine("exception deleting: " + docId);
                Console.Out.WriteLine(e);
            }
            return false;
        }
    }
}
