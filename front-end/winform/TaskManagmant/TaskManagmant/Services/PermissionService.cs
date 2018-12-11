using BOL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManagmant.Help;

namespace TaskManagmant.Services
{
    public static class PermissionService
    {
        public static bool AddPermission(Permission permission)
        {
            //------------post request-------------
            bool created = false;
            string url = $"{Global.HOST}/permission/addPemission";
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

        public static bool DeletePemission(int permissionId)
        {
            bool isDeleted;
            //------------post request-------------
            dynamic credential;
            string url = $"{Global.HOST}/user/deleteUser?userId={permissionId}";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(@url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                credential = null;
                string credentialString = Newtonsoft.Json.JsonConvert.SerializeObject(credential, Newtonsoft.Json.Formatting.None);
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
