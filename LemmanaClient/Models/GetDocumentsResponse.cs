namespace LemmanaClient.Models
{
    public class DocumentsResponse
    {
        public string statusCode { get; set; }
        public string responseStatus { get; set; }
        public string responseMessage { get; set; }
        public Docs docs { get; set; }
    }
}