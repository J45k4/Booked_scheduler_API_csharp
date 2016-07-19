using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booked_scheduler_API_csharp
{
    public class ResourceRequest
    {
        public string name { get; set; }
        public string location { get; set; }
        public string contact { get; set; }
        public string notes { get; set; }
        public int maxLength { get; set; }
        public string minLength { get; set; }
        public bool requiresApproval { get; set; }
        public bool allowMultiday { get; set; }
        public int maxParticipants { get; set; }
        public int minNotice { get; set; }
        public string maxNotice { get; set; }
        public string description { get; set; }
        public int scheduleId { get; set; }
        public bool autoAssignPermissions { get; set; }
        public List<Attribute> customAttributes { get; set; }
        public int sortOrder { get; set; }
        public int statusId { get; set; }
        public int statusReasonId { get; set; }
        public int resourceTypeId { get; set; }
    }
}
