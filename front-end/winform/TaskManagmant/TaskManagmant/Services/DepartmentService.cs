using BOL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManagmant.Help;

namespace TaskManagmant.Services
{
    public static class DepartmentService
    {
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
