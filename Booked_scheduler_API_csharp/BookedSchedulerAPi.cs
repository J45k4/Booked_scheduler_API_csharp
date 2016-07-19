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
    public class BookedSchedulerAPi
    {
        private AuthenticationResponse authRes;

        private string baseUrl;
        private string user;
        private string password;

        public BookedSchedulerAPi(string baseUrl, string user, string password)
        {
            this.user = user;
            this.password = password;
            this.baseUrl = baseUrl;
            Autheticate(baseUrl, user, password);
        }

        public bool Autheticate(string baseUrl, string user, string password)
        {
            string authUrl = this.baseUrl + "/Authentication/Authenticate";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(authUrl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                //string json = "{\"username\":\"user\"," +
                //                "\"password\":\"password\"}";
                string json = JsonConvert.SerializeObject(new AuthenticationRequest() { username = user, password = password });
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                authRes = JsonConvert.DeserializeObject<AuthenticationResponse>(result);
                return authRes.isAuthenticated;
            }
        }

        public bool CreateResource(CreateResourceRequest request)
        {
            if (request.scheduleId != null && request.name != "" && request.allowMultiday != null)
            {
                if (DateTime.Now > authRes.sessionExpires)
                {
                    Console.WriteLine("not autheticated");
                    if (!Autheticate(this.baseUrl, this.user, this.password)) return false;
                }
                string createResourceUrl = this.baseUrl + "/Resources/";
                ApiHttpRequest httpRequest = new ApiHttpRequest(createResourceUrl, authRes.sessionToken, authRes.userId);
                httpRequest.Method = "POST";

                httpRequest.Write(request);
                CreateResourceResponse response = httpRequest.Read<CreateResourceResponse>();
                return true;
            } else
            {
                return false;
            }
        }

        public bool UpdateResource(UpdateResourceRequest request)
        {
            if (request.scheduleId != null && request.name != "" && request.allowMultiday != null && request.resourceId != null)
            {
                if (DateTime.Now > authRes.sessionExpires)
                {
                    Console.WriteLine("not autheticated");
                    if (!Autheticate(this.baseUrl, this.user, this.password)) return false;
                }
                string updateResourceUrl = this.baseUrl + "/Resources/" + request.resourceId.ToString();
                ApiHttpRequest httpRequest = new ApiHttpRequest(updateResourceUrl, authRes.sessionToken, authRes.userId);
                httpRequest.Method = "POST";
                httpRequest.Write(request);
                UpdateResourceResponse response = httpRequest.Read<UpdateResourceResponse>();

                return true;
            } else
            {
                return false;
            }
        }

        public bool DeleteResource(DeleteResourceRequest request)
        {
            if (request.resourceId != null)
            {
                var deleteResourceUrl = this.baseUrl + "/Resources/" + request.resourceId.ToString();
                Console.WriteLine(deleteResourceUrl);
                ApiHttpRequest httpRequest = new ApiHttpRequest(deleteResourceUrl, authRes.sessionToken, authRes.userId);
                httpRequest.Method = "DELETE";
                DeleteResourceResponse response = httpRequest.Read<DeleteResourceResponse>();
                return true;
            } else
            {
                return false;
            }
            
        }

        public bool GetAllResources()
        {
            if (DateTime.Now > authRes.sessionExpires)
            {
                Console.WriteLine("not autheticated");
                if (!Autheticate(this.baseUrl, this.user, this.password)) return false;
            }
            string getAllResourcesUrl = this.baseUrl + "/Resources/";
            ApiHttpRequest request = new ApiHttpRequest(getAllResourcesUrl, authRes.sessionToken, authRes.userId);
            request.Method = "GET";
            GetAllResourcesRequest model = request.Read<GetAllResourcesRequest>();
            //Console.WriteLine(model.links[0].href);
            return true;
        }

        public bool GetStatuses()
        {
            return true;
        }

        public bool GetStatusReasons()
        {
            return true;
        }

        public bool GetResourceTypes()
        {
            return true;
        }

        public bool GetAvailability()
        {
            return true;
        }

        public bool GetResource()
        {
            return true;
        }

        public bool DeleteResource()
        {
            return true;
        }

        public bool GetAllAccessories()
        {
            if (DateTime.Now > authRes.sessionExpires)
            {
                if (!Autheticate(this.baseUrl, this.user, this.password)) return false;
            }

            string getAllAccessoriesUrl = this.baseUrl + "/Accessories/";

            var getAllAccessoriesHttpRequest = (HttpWebRequest)WebRequest.Create(getAllAccessoriesUrl);
            getAllAccessoriesHttpRequest.ContentType = "GET";
            getAllAccessoriesHttpRequest.Headers["X-Booked-SessionToken"] = authRes.sessionToken;
            getAllAccessoriesHttpRequest.Headers["X-Booked-UserId"] = authRes.userId.ToString();

            var httpResponse = (HttpWebResponse)getAllAccessoriesHttpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                GetAllSchedulesResponse response = JsonConvert.DeserializeObject<GetAllSchedulesResponse>(result);
                Console.WriteLine(result);
            }
            return true;
        }

        public bool GetAccessory(int id)
        {
            if (DateTime.Now > authRes.sessionExpires)
            {
                if (!Autheticate(this.baseUrl, this.user, this.password)) return false;
            }
            string getAccessoryUrl = this.baseUrl + "/Accessories";

            var getAccessoryHttpRequest = (HttpWebRequest)WebRequest.Create(getAccessoryUrl);
            getAccessoryHttpRequest.ContentType = "GET";
            getAccessoryHttpRequest.Headers["X-Booked-SessionToken"] = authRes.sessionToken;
            getAccessoryHttpRequest.Headers["X-Booked-UserId"] = authRes.userId.ToString();

            var httpResponse = (HttpWebResponse)getAccessoryHttpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                GetAllSchedulesResponse response = JsonConvert.DeserializeObject<GetAllSchedulesResponse>(result);
                Console.WriteLine(result);
            }
            return true;
        }

        public bool CreateCustomAttribute()
        {
            if (DateTime.Now > authRes.sessionExpires)
            {
                if (!Autheticate(this.baseUrl, this.user, this.password)) return false;
            }
            string createCustomAttributeUrl = this.baseUrl + "/Attributes/";

            var createCustomAttributeHttpRequest = (HttpWebRequest)WebRequest.Create(createCustomAttributeUrl);
            createCustomAttributeHttpRequest.ContentType = "POST";
            createCustomAttributeHttpRequest.Headers["X-Booked-SessionToken"] = authRes.sessionToken;
            createCustomAttributeHttpRequest.Headers["X-Booked-UserId"] = authRes.userId.ToString();

            //using (var streamWriter = new StreamWriter(createResourceHttpRequest.GetRequestStream()))
            //{
            //    string json = JsonConvert.SerializeObject(resource);
            //    streamWriter.Write(json);
            //    streamWriter.Flush();
            //    streamWriter.Close();
            //}

            var httpResponse = (HttpWebResponse)createCustomAttributeHttpRequest.GetResponse();

            return true;
        }

        public bool UpdateCustomAttribute()
        {
            if (DateTime.Now > authRes.sessionExpires)
            {
                if (!Autheticate(this.baseUrl, this.user, this.password)) return false;
            }
            string updateCustomAttributeUrl = this.baseUrl + "/Attributes/";

            var updateCustomAttributeHttpRequest = (HttpWebRequest)WebRequest.Create(updateCustomAttributeUrl);
            updateCustomAttributeHttpRequest.ContentType = "POST";
            updateCustomAttributeHttpRequest.Headers["X-Booked-SessionToken"] = authRes.sessionToken;
            updateCustomAttributeHttpRequest.Headers["X-Booked-UserId"] = authRes.userId.ToString();

            return true;
        }

        public bool GetGategoryAttributes()
        {
            return true;
        }

        public bool GetAttribute()
        {
            return true;
        }

        public bool DeleteCustomAttribute()
        {
            return true;
        }

        public bool GetAllGroups()
        {
            return true;
        }

        public bool GetGroup()
        {
            return true;
        }

        public bool CreateReservation(CreateReservationRequest request)
        {

            return true;
        }

        public bool UpdateReservation()
        {
            return true;
        }

        public bool ApproveReservation()
        {
            return true;
        }

        public bool GetReservations()
        {
            return true;
        }

        public bool GetReservation()
        {
            return true;
        }

        public bool DeleteReservation()
        {
            return true;
        }

        public bool GetAllSchedules()
        {
            if (DateTime.Now > authRes.sessionExpires)
            {
                if (!Autheticate(this.baseUrl, this.user, this.password)) return false;
            }
            string getAllSchedulesUrl = this.baseUrl + "/Schedules/";

            var getAllSchedulesHttpRequest = (HttpWebRequest)WebRequest.Create(getAllSchedulesUrl);
            getAllSchedulesHttpRequest.ContentType = "GET";
            getAllSchedulesHttpRequest.Headers["X-Booked-SessionToken"] = authRes.sessionToken;
            getAllSchedulesHttpRequest.Headers["X-Booked-UserId"] = authRes.userId.ToString();

            //using(var streamWriter = new StreamWriter(getAllSchedulesHttpRequest.GetRequestStream()))
            //{
            //    streamWriter.Flush();
            //    streamWriter.Close();
            //}
            var httpResponse = (HttpWebResponse)getAllSchedulesHttpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                GetAllSchedulesResponse response = JsonConvert.DeserializeObject<GetAllSchedulesResponse>(result);
                Console.WriteLine(result);
            }
            return true;
        }

        public bool GetSchedule()
        {
            return true;
        }

        public bool CreateUser()
        {
            return true;
        }

        public bool UpdateUser()
        {
            return true;
        }

        public bool GetAllUsers()
        {
            return true;
        }

        public bool GetUser()
        {
            return true;
        }

        public bool DeleteUser()
        {
            return true;
        }
    }
}
