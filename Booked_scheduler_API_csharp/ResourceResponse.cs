using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booked_scheduler_API_csharp
{
    class ResourceResponse
    {
        public int resourceId { get; set; }
        public List<Link>links { get; set; }
        public string message { get; set; }
    }
}
