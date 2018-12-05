using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace API.Controllers
{
    public class BaseController : ApiController
    {
        public string FullPath { get; set; }
        public BaseController()
        {
            FullPath = @"C:\Users\User\Desktop\seldat-finalProject\back-end\TaskManagement\API";
        }
        public List<string> GetErrorList(List<ModelState> modelStateList)
        {
            List<string> errors = new List<string>();
            modelStateList.ForEach(value => value.Errors.ToList()
                .ForEach(err => errors.Add(err.ErrorMessage)));
            return errors;
        }
    }
}
