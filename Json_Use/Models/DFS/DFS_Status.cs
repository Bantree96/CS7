using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json_Use.Models.DFS
{
    class DFS_Status
    { 
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "Alex";
        public int status { get; set; } = 1;
        public List<string> refDS { get; set; }
        
    }
}
