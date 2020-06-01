using System;
using log4net;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using System.Collections.Generic;
using Prime.Account.API.Models;

namespace Prime.Account.API.Controllers
{
    [Authorize]
    public class AccountController : ApiController
    {
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [Route("api/Account/GetEmployeeDetails")]
        public HttpResponseMessage GetEmployeeDetails()
        {
            try
            {
                var employeeList = GetEmployee();
                return Request.CreateResponse(HttpStatusCode.OK, employeeList);
            }
            catch (Exception e)
            {
                _logger.Error(e.ToString());
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("api/Account/GetEmployeeDetails/{employeeID}")]
        public HttpResponseMessage GetEmployeeDetailsByID(int employeeID)
        {
            try
            {
                var employeeList = GetEmployeeByID(employeeID);
                return Request.CreateResponse(HttpStatusCode.OK, employeeList);
            }
            catch (Exception e)
            {
                _logger.Error(e.ToString());
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        private List<Employee> GetEmployee()
        {
            var employeeList = new List<Employee>()
            {
                new Employee() {EmployeeID = 1, Name = "Aliza", Job = "Software Engineer", DateHired = new DateTime(2020,3,2,0,0,0)},
                new Employee() {EmployeeID = 2, Name = "Ed", Job = "QA Analyst", DateHired = new DateTime(2020,1,10,0,0,0)},
                new Employee() {EmployeeID = 3, Name = "Jeff", Job = "Consultant", DateHired = new DateTime(2020,2,3,0,0,0)},
            };

            return employeeList;
        }

        private Employee GetEmployeeByID(int employeeID)
        {
            var employee = GetEmployee().Where(x => x.EmployeeID == employeeID)
                                        .FirstOrDefault();
            return employee;
        }
    }
}