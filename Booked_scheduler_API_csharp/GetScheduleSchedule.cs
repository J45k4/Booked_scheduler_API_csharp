using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booked_scheduler_API_csharp
{
    public class GetScheduleSchedule
    {
        public int daysVisible { get; set; }
        public int id { get; set; }
        public bool isDefault { get; set; }
        public string name { get; set; }
        public string timezone { get; set; }
        public int weekdayStart { get; set; }
        public string icsUrl { get; set; }
        public List<Period> periods { get; set; }
        public List<Link> links { get; set; }
        public string message { get; set; }
    }
}
