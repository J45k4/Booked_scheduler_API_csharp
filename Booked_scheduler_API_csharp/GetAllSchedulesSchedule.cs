using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booked_scheduler_API_csharp
{
    public class GetAllSchedulesSchedule
    {
        public int daysVisible { get; set; }
        public int id { get; set; }
        public string isDefault { get; set; }
        public string name { get; set; }
        public string timezone { get; set; }
        public int weekdayStart { get; set; }
        public List<Link> links { get; set; }
        public string message { get; set; }
    }
}
