using BOL;
using BOL.Help;
using TaskManagmant.Help;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace TaskManagmant.Services
{
    public static class UserService
    {

        private static string baseURL = $"{Global.HOST}/user";

        //POST
        public static User Login(Login login)
        {
            string url = $"{baseURL}/login";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(@url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string credentialString = JsonConvert.SerializeObject(login, Newtonsoft.Json.Formatting.None);
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
                    User user = JsonConvert.DeserializeObject<User>(result);
                    Global.USER = user;
                    if (user != null)
                    {
                        Global.UpdateCurrentUser(user.UserId.ToString());
                    }

                    return user;
                }

            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        //GET
        public static List<User> GetAllUsers()
        {
            int managerId = Global.USER.UserId;
            string url = $"{Global.HOST}/user/getAllUsers?managerId={managerId}";
            return GetUsers(url);
        }

        //GET
        public static List<User> GetAllTeamUsers(int teamLeaderId)
        {
            string url = $"{Global.HOST}/user/getAllTeamUsers?teamLeaderId={teamLeaderId}";
            return GetUsers(url);
        }
        //GET
        public static List<User> GetAllTeamLeaders()
        {
            int managerId = Global.USER.UserId;
            string url = $"{Global.HOST}/user/getAllTeamLeaders?managerId={managerId}";
            return GetUsers(url);
        }

        //GET
        public static List<User> GetUsers(string url)
        {
            try
            {
                List<User> users;
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    users = JsonConvert.DeserializeObject<List<User>>(json);
                    return users;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return null;
                }
            }
            catch (Exception ex)
            {
                string x = ex.Message;
                return null;
            }
        }

        //GET
        public static User GetUserById(int userId)
        {
            string url = $"{Global.HOST}/user/getUserById?userId={userId}";
            return GetUser(url);
        }

        //GET
        internal static User GetUserByEmail(string email)
        {
            string url = $"{Global.HOST}/user/getUserByEmail?email={email}";
            return GetUser(url);
        }

        //GET
        public static User GetUser(string url)
        {
            User user;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(json);
                return user;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        //POST
        public static bool AddUser(Form form, User myUser)
        {
            bool created = false;
            string url = $"{Global.HOST}/user/addUser";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(@url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string credentialString = JsonConvert.SerializeObject(myUser, Formatting.None);
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

        //PUT
        public static bool EditUser(Form form, User myUser)
        {
            bool edited = false;
            string url = $"{Global.HOST}/user/editUser";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(@url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string credentialString = Newtonsoft.Json.JsonConvert.SerializeObject(myUser, Newtonsoft.Json.Formatting.None);
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
                    edited = JsonConvert.DeserializeObject<bool>(result);
                    return edited;
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
                return edited;
            }
        }

        //POST
        public static bool DeleteUser(User user)
        {
            //delete userProfile if exist
            if (user.ProfileImageName != null)
                RemoveUploadedImage(user.ProfileImageName, true);

            //delete user
            bool isDeleted;
            dynamic credential;
            string url = $"{Global.HOST}/user/deleteUser?userId={user.UserId}";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(@url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                credential = null;
                string credentialString = Newtonsoft.Json.JsonConvert.SerializeObject(credential, Formatting.None);
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

        //POST
        public static string UploadImageProfile(string fileName)
        {
            string url = $"{Global.HOST}/user/uploadImageProfile";

            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "multipart/form-data; boundary=" + boundary;
            httpWebRequest.Method = "POST";
            httpWebRequest.KeepAlive = true;
            httpWebRequest.Credentials = CredentialCache.DefaultCredentials;

            Stream stream = httpWebRequest.GetRequestStream();

            stream.Write(boundarybytes, 0, boundarybytes.Length);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string contentType = "application/x-www-form-urlencoded";
            string paramName = "file";
            string header = string.Format(headerTemplate, paramName, fileName, contentType);
            byte[] headerbytes = Encoding.UTF8.GetBytes(header);
            stream.Write(headerbytes, 0, headerbytes.Length);

            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                stream.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();

            byte[] trailer = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            stream.Write(trailer, 0, trailer.Length);
            stream.Close();
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    fileName = JsonConvert.DeserializeObject<string>(result);
                    return fileName;
                }

            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        //POST
        public static bool RemoveUploadedImage(string profileImageName, bool moveToArchives)
        {
            string url = $"{Global.HOST}/user/removeUploadedImage";

            var postData = $"profileImageName={profileImageName}&moveToArchives={moveToArchives}";
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
                    bool deleted = JsonConvert.DeserializeObject<bool>(result);
                    return deleted;
                }

            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        
       //POST
        public static bool SendEmail(Email email)
        {
            string url = $"{Global.HOST}/user/sendEmail";

            var postData = $"email={JsonConvert.SerializeObject(email)}";
            postData += $"&user={JsonConvert.SerializeObject(Global.USER)}";
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
                    bool created = JsonConvert.DeserializeObject<bool>(result);
                    return created;
                }

            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        //GET
        public static bool HasWorkes(int teamLeaderId)
        {
            bool hasWorkes;
            string url = $"{Global.HOST}/user/hasWorkers?teamLeaderId={teamLeaderId}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                hasWorkes = JsonConvert.DeserializeObject<bool>(json);
                return hasWorkes;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return false;
            }
        }

        //POST
        public static bool ForgotPassword(string email)
        {
            bool isExist;
            dynamic credential;
            string url = $"{Global.HOST}/user/forgotPassword?email={email}";
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
                    isExist = JsonConvert.DeserializeObject<bool>(result);
                    return isExist;
                }

            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        //POST
        public static bool ConfirmToken(ChangePassword changePassword)
        {
            string url = $"{baseURL}/confirmToken";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(@url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string credentialString = JsonConvert.SerializeObject(changePassword, Formatting.None);
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
                    bool confirmed = JsonConvert.DeserializeObject<bool>(result);
                    return confirmed;
                }

            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        //PUT
        public static bool ChangePassword(User user)
        {
            bool edited = false;
            string url = $"{Global.HOST}/user/changePassword";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(@url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string credentialString = JsonConvert.SerializeObject(user, Formatting.None);
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
                    edited = JsonConvert.DeserializeObject<bool>(result);
                    return edited;
                }

            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    MessageBox.Show(reader.ReadToEnd());
                }
                return edited;
            }
        }      
    }
}