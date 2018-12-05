﻿using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/project")]
    public class ProjectController : BaseController
    {
        [HttpPost]
        [Route("addProject")]
        public HttpResponseMessage AddProject(Project newProject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool created = ProjectService.AddProject(newProject);
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

        [HttpGet]
        [Route("getAllProjects")]
        public HttpResponseMessage GetAllProjects()
        {
            try
            {

                List<Project> projects = ProjectService.GetAllProjects();
                return Request.CreateResponse(HttpStatusCode.OK, projects);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpGet]
        [Route("getProjectsByTeamLeaderId")]
        public HttpResponseMessage getProjectsByTeamLeaderId(int TeamLeaderId)
        {
            try
            {
                List<Project> projects = ProjectService.getProjectsByTeamLeaderId(TeamLeaderId);
                return Request.CreateResponse(HttpStatusCode.OK, projects);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpGet]
        [Route("getProjectsReports")]
        public HttpResponseMessage GetProjectsReports()
        {
            try
            {

                List<Project> projects = ProjectService.GetProjectsReports();
                return Request.CreateResponse(HttpStatusCode.OK, projects);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpPost]
        [Route("checkUniqueValidation")]
        public HttpResponseMessage CheckUniqueValidation(Project project)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    List<string> errors = GetErrorList(ModelState.Values.ToList());
                    if (errors.Any(err => err == "ProjectName must be unique"))
                        return Request.CreateResponse(HttpStatusCode.OK, new { val = "project name must be unique" });
                }
                return Request.CreateResponse(HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
