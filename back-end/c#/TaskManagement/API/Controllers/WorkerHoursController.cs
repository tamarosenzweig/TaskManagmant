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
    [RoutePrefix("api/workerHours")]
    public class WorkerHoursController : BaseController
    {
        [HttpGet]
        [Route("getAllWorkerHours")]
        public HttpResponseMessage GetAllWorkerHours(int workerId)
        {
            try
            {
                List<WorkerHours> workerHoursList = WorkerHoursService.GetAllWorkerHours(workerId);
                return Request.CreateResponse(HttpStatusCode.OK, workerHoursList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }
        [HttpPost]
        [Route("addWorkersHours")]
        public HttpResponseMessage AddWorkerHours(List<WorkerHours> workerHoursList)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool created=true;
                    workerHoursList.ForEach(workerHours =>
                    {
                        created = created && WorkerHoursService.AddWorkerHours(workerHours);
 
                    });                
                    return Request.CreateResponse(HttpStatusCode.Created, created);
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
        [Route("editWorkersHours")]
        public HttpResponseMessage EditWorkerHours(List<WorkerHours> workerHoursList)
        {
            try
            {
                bool edited = true;
                workerHoursList.ForEach(workerHours =>
                {
                    edited = edited&& WorkerHoursService.EditWorkerHours(workerHours);
                });            
                return Request.CreateResponse(HttpStatusCode.OK, edited);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("deleteWorkersHours")]
        public HttpResponseMessage DeleteWorkerHours(List<int> workerHoursIdList)
        {
            try
            {
                bool deleted = true;
                workerHoursIdList.ForEach(workerHoursId =>
                {
                    deleted = deleted&& WorkerHoursService.DeleteWorkerHours(workerHoursId);
                });
                return Request.CreateResponse(HttpStatusCode.OK, deleted);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
