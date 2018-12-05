using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/presenceHours")]
    public class PresenceHoursController : BaseController
    {
        //[HttpGet]
        //[Route("getPresenceHours")]
        //public HttpResponseMessage GetPresenceHours()
        //{
        //    try
        //    {
        //      List<PresenceHours> PresenceHoursList = PresenceHoursService.GetPresenceHours();
        //        return Request.CreateResponse(HttpStatusCode.OK, PresenceHoursList);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
        //    }
        //}

        //[HttpGet]
        //[Route("getPresenceHoursByProjectId")]
        //public HttpResponseMessage GetPresenceHoursByProjectId(int projectId)
        //{
        //    try
        //    {
        //        List<PresenceHours> presenceHoursList = PresenceHoursService.GetPresenceHoursByProjectId(projectId);
        //        return Request.CreateResponse(HttpStatusCode.OK, presenceHoursList);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
        //    }
        //}

        [HttpPost]
        [Route("addPresenceHours")]
        public HttpResponseMessage AddPresenceHours(PresenceHours newPresenceHours)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int id = PresenceHoursService.AddPresenceHours(newPresenceHours);
                    return Request.CreateResponse(HttpStatusCode.Created, id);
                }
                List<string> errors = GetErrorList(ModelState.Values.ToList());

                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPut]
        [Route("editPresenceHours")]
        public HttpResponseMessage EditPresenceHours(PresenceHours presenceHours)
        {
            try
            {
                bool edited = PresenceHoursService.EditPresenceHours(presenceHours);
                return Request.CreateResponse(HttpStatusCode.OK, edited);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("getPresenceStatusPerWorkers")]
        public HttpResponseMessage GetPresenceStatusPerWorkers(int teamLeaderId)
        {
            try
            {

                List<dynamic> presenceStatusList = PresenceHoursService.GetPresenceStatusPerWorkers(teamLeaderId);
                return Request.CreateResponse(HttpStatusCode.OK, presenceStatusList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }
        [HttpGet]
        [Route("getPresenceStatusPerProjects")]
        public HttpResponseMessage GetPresenceStatusPerProjects(int workerId)
        {
            try
            {

                List<dynamic> presenceStatusList = PresenceHoursService.GetPresenceStatusPerProjects(workerId);
                return Request.CreateResponse(HttpStatusCode.OK, presenceStatusList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

      
    }
}
