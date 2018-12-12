using BOL;
using TaskManagmant.Help;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Linq;


namespace TaskManagmant.Services
{
    public static class PresenceHoursService
    {

        private static string baseURL = $"{Global.HOST}/presenceHours";

        //POST
        public static int AddPresenceHours(PresenceHours presenceHours)
        {
            string url = $"{baseURL}/addPresenceHours";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(@url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string credentialString = Newtonsoft.Json.JsonConvert.SerializeObject(presenceHours, Newtonsoft.Json.Formatting.None);
                streamWriter.Write(credentialString);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    int PresenceHoursId = JsonConvert.DeserializeObject<int>(result);
                    return PresenceHoursId;
                }

            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.ToString());
                return 0;
            }
        }

        //PUT
        public static bool EditPresenceHours(PresenceHours presenceHours)
        {
            bool created = false;
            string url = $"{baseURL}/editPresenceHours";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(@url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string credentialString = JsonConvert.SerializeObject(presenceHours, Formatting.None);
                streamWriter.Write(credentialString);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    created = JsonConvert.DeserializeObject<bool>(result);
                    return created;
                }

            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.ToString());
                return created;
            }
        }

        //GET
        public static List<dynamic> GetPresenceStatusPerWorkers()
        {
            int teamLeaderId = Global.USER.UserId;
            string url = $"{baseURL}/getPresenceStatusPerWorkers?teamLeaderId={teamLeaderId}";
            return GetPresenceStatus(url);
        }

        //GET
        public static List<dynamic> GetPresenceStatusPerProjects()
        {
            int workerId = Global.USER.UserId;
            string url = $"{baseURL}/getPresenceStatusPerProjects?workerId={workerId}";
            return GetPresenceStatus(url);
        }

        //GET
        public static List<dynamic> GetPresenceStatus(string url)
        {
            List<dynamic> presenceStatusList;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                presenceStatusList = JsonConvert.DeserializeObject<List<dynamic>>(json);
                return presenceStatusList;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        //GET
        public static decimal GetPresenceHoursSum(int projectId, int workerId)
        {
            string url = $"{baseURL}/getPresenceHoursSum?projectId={projectId}&workerId={workerId}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                decimal presenceSum = JsonConvert.DeserializeObject<decimal>(json);
                return presenceSum;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return -1;
            }
        }

        public static double GetPresenceHoursForWorker(User worker)
        {
            return worker.PresenceHours.Sum(presenceHours => Global.DateDiffInHours(presenceHours.StartHour, (DateTime)presenceHours.EndHour));
        }

        public static double GetPresenceHoursForDepartment(Department department)
        {
            return department.Workers.Sum(worker => GetPresenceHoursForWorker(worker));
        }

        public static double GetPresenceHoursForProject(Project project)
        {
            return project.DepartmentsHours.Sum(departmentHours => GetPresenceHoursForDepartment(departmentHours.Department));
        }

        public static double GetPercentHoursForProject(Project project)
        {
            return project.DepartmentsHours.Average(departmentHours =>
            {
                double percentHoursForDepartment = departmentHours.NumHours > 0 ? GetPresenceHoursForDepartment(departmentHours.Department) / departmentHours.NumHours : 1;
                return percentHoursForDepartment <= 1 ? percentHoursForDepartment : 1;
            });
        }
    }
}
