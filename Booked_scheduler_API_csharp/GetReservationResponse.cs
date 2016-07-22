using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booked_scheduler_API_csharp
{
    public class GetReservationResponse
    {
        public List<ReservationModel> reservations { get; set; }
        public DateTime startDateTime { get; set; }
        public DateTime endDateTime { get; set; }
        public List<Link> links { get; set; }
        public string message { get; set; }
    }
}
