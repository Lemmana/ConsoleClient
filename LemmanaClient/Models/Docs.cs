using System.Collections.Generic;

namespace LemmanaClient.Models
{
    public class Docs
    {
		public int count { get; set; }

        public List<Document> documents { get; set; }

        public Docs()
        {
            
        }
    }
}
