using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/department")]
    public class DepartmentController : BaseController
    {

        [HttpGet]
        [Route("getAllDepartments")]
        public HttpResponseMessage GetAllDepartments()
        {
            try
            {
                List<Department> departments = DepartmentService.GetAllDepartments();
                return Request.CreateResponse(HttpStatusCode.OK, departments);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}

