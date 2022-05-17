using System.Collections.Generic;

namespace LemmanaClient.Models
{
    public class Classification
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<Entity> entities { get; set; }
        public double probability = 0;
    }
}
