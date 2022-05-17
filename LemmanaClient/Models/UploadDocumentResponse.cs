namespace LemmanaClient.Models
{
    class DocumentResponse
    {
        public string statusCode { get; set; }
        public string responseStatus { get; set; }
        public string responseMessage { get; set; }
        public Document document { get; set; }
    }
}
