namespace LemmanaClient.Models
{
    public class Document
    {
        public string id { get; set; }
        public string fileName { get; set; }
        public string training { get; set; }
        public Classification classification { get; set; }
    }
}
