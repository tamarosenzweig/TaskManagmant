using BOL;
using TaskManagmant.Help;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace TaskManagmant.Services
{
    public static class DepartmentService
    {

        //GET
        public static List<Department> GetAllDepartments()
        {
            List<Department> departments;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string url = $"{Global.HOST}/department/getAllDepartments";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                departments = JsonConvert.DeserializeObject<List<Department>>(json);
                return departments;
            }
            else
            {
                MessageBox.Show(response.StatusCode.ToString());
                return null;
            }
        }
    }
}
