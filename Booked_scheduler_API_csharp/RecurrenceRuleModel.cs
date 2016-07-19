using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booked_scheduler_API_csharp
{
    public class RecurrenceRuleModel
    {
        public string type { get; set; }
        public int interval { get; set; }
        public string monthlyType { get; set; }
        public List<int> weekdays { get; set; }
        public DateTime repeatTerminationDate { get; set; }
    }
}
