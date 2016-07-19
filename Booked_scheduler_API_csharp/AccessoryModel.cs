using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booked_scheduler_API_csharp
{
    public class AccessoryModel
    {
        public int? id { get; set; }
        public string accessoryName { get; set; }
        public int? quantityAvailable { get; set; }
        public List<Link> links { get; set; }
        public string message { get; set; }
    }
}
