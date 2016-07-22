using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Booked_scheduler_API_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://zeeta.tietotoimi.fi/booked/Web/Services/index.php/Authentication/Authenticate");

            BookedSchedulerAPi api = new BookedSchedulerAPi("http://zeeta.tietotoimi.fi/booked/Web/Services/index.php", "admin", "password");
            //api.CreateResource(new ResourceRequest()
            //{
            //    name = "resursssi",
            //    location = "asd",
            //    scheduleId = 1,
            //    notes = "uiluli",
            //    contact = "asd"
            //    //minLength = "1d0h0m",
            //    //maxLength = 3600,
            //    //requiresApproval = true,
            //    //allowMultiday = false,
            //    //maxParticipants = 100,
            //    //minNotice = 86400,
            //    //maxNotice = "0d12h30m",
            //    //description = "uiluli",
            //    //autoAssignPermissions = true,
            //    //sortOrder = 1,
            //    //statusId = 1,
            //    //statusReasonId = 2,
            //    //resourceTypeId = 1,
            //    //customAttributes = new List<Attribute>()
            //});
            //api.CreateResource(new CreateResourceRequest()
            //{
            //    name = "Uusi resurssi",
            //    scheduleId = 1,
            //    allowMultiday = 0
            //});

            //api.UpdateResource(new UpdateResourceRequest()
            //{
            //    resourceId = 1,
            //    name = "uusi nimi",
            //    allowMultiday = 0,
            //    scheduleId = 1
            //});

            //api.DeleteResource(new DeleteResourceRequest()
            //{
            //    resourceId = 1
            //});

            DateTime start = new DateTime();
            DateTime end = new DateTime();
            start.AddYears(2016);
            end.AddYears(2016);

            start.AddMonths(7);
            end.AddMonths(7);

            start.AddDays(21);
            end.AddDays(21);

            start.AddDays(10);
            end.AddDays(11);

            api.CreateReservation(new CreateReservationRequest()
            {
                accessories = null,
                allowParticipation = null,
                description = "",
                //endDateTime = DateTime.Now.AddHours(13),
                startDate = DateTime.Now.AddHours(1).AddMinutes(2),
                endReminder = null,
                invitees = new List<int>(),
                participants = new List<int>(),
                recurrenceRule = null,
                resourceId = 5,
                resources = null,
                //startDateTime = DateTime.Now.AddHours(12),
                endDate = DateTime.Now.AddHours(2).AddMinutes(2),
                startReminder = null,
                title = "",
                userId = 2
            });

            // startDateTime = "2016-07-21T12:31:08.7034739+03:00",
            //startDateTime = "2016-07-20T14:00:07+0300",

            //List<Reservation> reservations = api.GetReservations(new GetReservationsRequest());
            //reservations[1].Model.startDate = DateTime.Now.AddHours(1);
            //reservations[1].Model.endDate = DateTime.Now.AddHours(2);
            //reservations[1].update();

            //api.GetAllResources();
            //api.GetAllSchedules();
            //api.UpdateResource(1, new ResourceModel()
            //{
            //    name ="testipaivitus",
            //    scheduleId = 1,
            //    allowMultiday = 0
            //});
            Console.ReadKey();
        }

    }
}
