using BOL;
using TaskManagmant.Help;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace TaskManagmant.Services
{
    public static class PermissionService
    {

        private static string baseURL = $"{Global.HOST}/permission";

        //POST
        public static bool AddPermission(Permission permission)
        {
            bool created = false;
            string url = $"{baseURL}/addPemission";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(@url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string credentialString = JsonConvert.SerializeObject(permission, Formatting.None);
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

        //POST
        public static bool DeletePemission(int permissionId)
        {
            bool isDeleted;
            dynamic credential;
            string url = $"{baseURL}/deletePemission?permissionId={permissionId}";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(@url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                credential = null;
                string credentialString =JsonConvert.SerializeObject(null, Formatting.None);
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
                    isDeleted = JsonConvert.DeserializeObject<bool>(result);
                    return isDeleted;
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
