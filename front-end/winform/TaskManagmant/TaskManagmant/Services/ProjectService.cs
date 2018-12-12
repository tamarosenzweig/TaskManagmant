using BOL;
using TaskManagmant.Help;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace TaskManagmant.Services
{
    public static class ProjectService
    {

        private static string baseURL = $"{Global.HOST}/project";

        //POST
        public static bool AddProject(Form form,Project project)
        {
            bool created = false;
            string url = $"{baseURL}/addProject";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(@url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string credentialString = JsonConvert.SerializeObject(project, Newtonsoft.Json.Formatting.None);
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
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    string message = reader.ReadToEnd();
                    Global.CreateDialog(form, message);
                }
                return created; 
            }
        }

        //GET
        public static List<Project> GetAllProjects()
        {
            List<Project> projects;
            string url = $"{baseURL}/getAllProjects";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                projects = JsonConvert.DeserializeObject<List<Project>>(json);
                return projects;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        //GET
        public static List<Project> GetProjectsByTeamLeaderId(int TeamLeaderId)
        {
            List<Project> projects;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string url = $"{baseURL}/getProjectsByTeamLeaderId?TeamLeaderId={TeamLeaderId}";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                projects = JsonConvert.DeserializeObject<List<Project>>(json);
                return projects;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        //GET
        public static List<Project> GetProjectsReports()
        {
            List<Project> projects;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string url = $"{baseURL}/getProjectsReports";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                projects = JsonConvert.DeserializeObject<List<Project>>(json);
                return projects;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        //GET
        public static bool HasProjects(int teamLeaderId)
        {
            bool hasProjects;
            string url = $"{baseURL}/hasProjects?teamLeaderId={teamLeaderId}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                hasProjects = JsonConvert.DeserializeObject<bool>(json);
                return hasProjects;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return false;
            }
        }
    }
}
