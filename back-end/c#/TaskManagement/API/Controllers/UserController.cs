using BLL;
using BOL;
using BOL.Help;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/user")]
    public class UserController : BaseController
    {

        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = UserService.Login(login.Email, login.Password);
                    return Request.CreateResponse(HttpStatusCode.OK, user);
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
        [Route("getAllUsers")]
        public HttpResponseMessage GetAllUsers()
        {
            try
            {
                List<User> users = UserService.GetAllUsers();
                return Request.CreateResponse(HttpStatusCode.OK, users);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpGet]
        [Route("getAllTeamLeaders")]
        public HttpResponseMessage GetAllTeamLeaders()
        {
            try
            {
                List<User> teamLeaders = UserService.GetAllTeamLeaders();
                return Request.CreateResponse(HttpStatusCode.OK, teamLeaders);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpGet]
        [Route("getUserById")]
        public HttpResponseMessage GetUserById(int userId)
        {
            try
            {
                User user = UserService.GetUserById(userId);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }
        [HttpPost]
        [Route("addUser")]
        public HttpResponseMessage AddUser(User newUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool created = UserService.AddUser(newUser);
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
        [Route("editUser")]
        public HttpResponseMessage EditUser(User user)
        {
            try
            {
                bool edited = UserService.EditUser(user);
                return Request.CreateResponse(HttpStatusCode.OK, edited);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("deleteUser")]
        public HttpResponseMessage DeleteUser(int userId)
        {
            try
            {
                bool deleted = UserService.DeleteUser(userId);
                return Request.CreateResponse(HttpStatusCode.OK, deleted);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("uploadImageProfile")]
        public HttpResponseMessage UploadImageProfile()
        {
            try
            {
                string originalFileName = HttpContext.Current.Request.Files[0].FileName;
                string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(originalFileName);
                string fullPathAndFileName = HttpContext.Current.Server.MapPath("~/Images/UsersProfiles/" + newFileName);
                HttpContext.Current.Request.Files[0].SaveAs(fullPathAndFileName);
                return Request.CreateResponse(HttpStatusCode.Created, newFileName);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("removeUploadedImage")]
        public HttpResponseMessage RemoveUploadedImage()
        {
            try
            {
                //TODO-move to archion
                string profileImageName = HttpContext.Current.Request.Form["profileImageName"];
                File.Delete(FullPath + "/Images/UsersProfiles/" + profileImageName);
                return Request.CreateResponse(HttpStatusCode.Created, true);
            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("sendEmail")]
        public HttpResponseMessage SendEmail()
        {
            try
            {
                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
                Email email = JsonConvert.DeserializeObject<Email>(HttpContext.Current.Request.Form["email"], jsonSerializerSettings);
                User user = JsonConvert.DeserializeObject<User>(HttpContext.Current.Request.Form["user"], jsonSerializerSettings);
                bool created=UserService.SendEmail(email, user);
                return Request.CreateResponse(HttpStatusCode.Created, created);
            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("checkUniqueValidations")]
        public HttpResponseMessage CheckUniqueValidations(User user)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    List<string> errors = GetErrorList(ModelState.Values.ToList());
                    string errorMessage = errors.FirstOrDefault(err => err == "Password must be unique" || err == "Email must be unique");
                    if (errorMessage != null)
                        return Request.CreateResponse(HttpStatusCode.OK, new { val = errorMessage });
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
