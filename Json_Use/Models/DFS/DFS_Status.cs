using System.Collections.Generic;
using Newtonsoft.Json;

namespace Json_Use.Models.DFS
{
    public class DFS_Status
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "Alex";
        public int status { get; set; } = 1;
        public IN_DATA1 refDS { get; set; }

        public DFS_Status()
        {
            //var jsonString = JsonConvert.SerializeObject(a, Formatting.Indented);
            IN_DATA1 in_data = new IN_DATA1();
            refDS = in_data;
        }
    }


}
