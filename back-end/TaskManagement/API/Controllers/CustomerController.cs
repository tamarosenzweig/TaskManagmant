﻿using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/customer")]
    public class CustomerController : BaseController
    {
        [HttpGet]
        [Route("getAllCustomers")]
        public HttpResponseMessage GetAllCustomers()
        {
            try
            {
                List<Customer> customers = CustomerService.GetAllCustomers();
                return Request.CreateResponse(HttpStatusCode.OK, customers);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

    }
}
