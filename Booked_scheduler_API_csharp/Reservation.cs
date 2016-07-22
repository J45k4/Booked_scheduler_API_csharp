using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booked_scheduler_API_csharp
{
    public class Reservation
    {
        private BookedSchedulerAPi api;
        public ReservationModel Model { get; set; }

        public Reservation(BookedSchedulerAPi api)
        {
            this.api = api;
        }

        public bool update()
        {
            return api.UpdateReservation(Model);
        }
    }
}
