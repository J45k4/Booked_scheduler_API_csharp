using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booked_scheduler_API_csharp
{
    public class AuthenticationResponse
    {
        public string sessionToken { get; set; }
        public DateTime sessionExpires { get; set; }
        public int userId { get; set; }
        public bool isAuthenticated { get; set; }
    }
}
