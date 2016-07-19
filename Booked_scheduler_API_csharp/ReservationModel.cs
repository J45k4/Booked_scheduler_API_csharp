using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booked_scheduler_API_csharp
{
    public class ReservationModel
    {
        public List<AccessoryModel> accessories { get; set; }
        public string description { get; set; }
        public DateTime endDateTime { get; set; }
        public List<int> invitees { get; set; }
        public List<int> participants { get; set; }
        public RecurrenceRuleModel recurrenceRule { get; set; }
        public int resourceId { get; set; }
        public List<int> resources { get; set; }
        public DateTime startDateTime { get; set; }
        public string title { get; set; }
        public int userId { get; set; }
        public ReminderModel startReminder { get; set; }
        public ReminderModel endReminder { get; set; }
        public bool? allowParticipation { get; set; }
    }
}
