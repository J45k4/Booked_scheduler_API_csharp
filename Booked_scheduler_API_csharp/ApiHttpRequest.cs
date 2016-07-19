using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Booked_scheduler_API_csharp
{
    public class ApiHttpRequest
    {

        private HttpWebRequest httpRequest;

        public ApiHttpRequest(string url, string sessionToken, int userId)
        {
            httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.ContentType = "application/json";
            httpRequest.Headers["X-Booked-SessionToken"] = sessionToken;
            httpRequest.Headers["X-Booked-UserId"] = userId.ToString();
        }

        public string Method {
            get
            {
                if (httpRequest != null)
                {
                    return httpRequest.Method;
                } else
                {
                    return null;
                }
            }
            set
            {
                if (httpRequest != null)
                {
                    httpRequest.Method = value;
                }
            }
        }


        public void Write(object o)
        {
            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(o);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }


        public T Read<T>()
        {
            try
            {
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    Console.WriteLine(result);
                    return JsonConvert.DeserializeObject<T>(result);
                }
            } catch (WebException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Status);
                return default(T);
            }
        }
    }
}
