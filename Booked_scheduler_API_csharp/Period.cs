using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booked_scheduler_API_csharp
{
    public class Period
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string label { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public bool isReservable { get; set; }
    }
}
