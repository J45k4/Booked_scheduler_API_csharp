using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booked_scheduler_API_csharp
{
    public class ReservationModel
    {
        private DateTime startdate;
        private DateTime enddate;

        public string referenceNumber { get; set; }
        public List<AccessoryModel> accessories { get; set; }
        public string description { get; set; }
        public DateTime endDate { get { return enddate; } set { enddate = value; } }
        //public DateTime endDateTime { get { return enddate; } set { enddate = value; } }
        public string endDateTime { get
            {
                return enddate.ToString("yyyy-MM-ddTHH:mm:ss+0300");
            }
        }
        public List<int> invitees { get; set; }
        public List<int> participants { get; set; }
        public RecurrenceRuleModel recurrenceRule { get; set; }
        public int resourceId { get; set; }
        public List<int> resources { get; set; }
        public DateTime startDate { get { return startdate; } set { startdate = value; } }
        //public DateTime startDateTime { get { return startdate; } set { startdate = value; } }
        public string startDateTime {
            get
            {
                return startdate.ToString("yyyy-MM-ddTHH:mm:ss+0300");
            }
        }
        public string title { get; set; }
        public int userId { get; set; }
        public ReminderModel startReminder { get; set; }
        public ReminderModel endReminder { get; set; }
        public bool? allowParticipation { get; set; }
    }
}
