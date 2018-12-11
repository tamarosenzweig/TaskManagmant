using BOL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;
using TaskManagmant.Help;

namespace TaskManagmant.Services
{
    public static class WorkerHoursService
    {
        private static string baseURL = $"{Global.HOST}/workerHours";

        public static List<WorkerHours> GetAllWorkerHours()
        {
            int workerId = Global.USER.UserId;
            List<WorkerHours> presenceStatusList;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string url = $"{baseURL}/getAllWorkerHours?workerId={workerId}";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                presenceStatusList = JsonConvert.DeserializeObject<List<WorkerHours>>(json);
                return presenceStatusList;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        public static bool EditWorkersHours(WorkerHours workerHours)
        {
            //------------put request-------------
            bool created = false;
            string url = $"{baseURL}/editWorkerHours";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(@url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string credentialString = JsonConvert.SerializeObject(workerHours, Formatting.None);
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

        public static bool HasIncomletHours(int workerId,List<int> projectIdList)
        {
            string url = $"{baseURL}/hasUncomletedHours";
            string json = JsonConvert.SerializeObject(projectIdList, Formatting.None);

            var postData = $"workerId={workerId}&projectIdList={json}";
            var data = Encoding.ASCII.GetBytes(postData);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(@url);
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentLength = data.Length;

            using (var stream = httpWebRequest.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    bool hasUncomletedHours = JsonConvert.DeserializeObject<bool>(result);
                    return hasUncomletedHours;
                }

            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
    }
}
