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

            api.DeleteResource(new DeleteResourceRequest()
            {
                resourceId = 1
            });

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
