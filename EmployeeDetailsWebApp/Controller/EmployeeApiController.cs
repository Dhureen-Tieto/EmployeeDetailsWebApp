using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDetailsWebApp.Model;

namespace EmployeeDetailsWebApp.Controller
{
    public class EmployeeApiController : ApiController
    {
        // GET: api/EmployeeApi
        public EmployeeApiController()
        {
            EmployeeRepository = new EmployeeRepositoryAccessUsingDapper();
            Controller = new EmployeeController(EmployeeRepository);
        }
        public EmployeeController Controller { get; set; }
        public IEmployeeRepositoryInterface EmployeeRepository { get; set; }
        // GET api/ptemployees
        [Route("api/getEmployees")]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            var employees = Controller.RetrieveEmployees();
            if (employees == null)
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, employees);
            else 
                response = Request.CreateResponse(HttpStatusCode.OK, employees);
            return response;
        }

        // GET api/ptemployees/5
        [Route("api/getEmployee/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response;
            Employee employee = new Employee { Id = id.ToString() };
            var employees = Controller.RetrieveEmployee(employee);
            if (employees == null)
                response = Request.CreateResponse(HttpStatusCode.BadRequest, employees);
            else
                response = Request.CreateResponse(HttpStatusCode.OK, employees);
            return response;
        }

        [Route("api/createEmployee")]
        public HttpResponseMessage Post(Employee employee)
        {
            HttpResponseMessage response;
            var employees = Controller.CreateNewEmployee(employee);
            if (employees == 0)
                response = Request.CreateResponse(HttpStatusCode.BadRequest, employees);
            else
                response = Request.CreateResponse(HttpStatusCode.OK, employees);
            return response;            
        }

        [Route("api/updateEmployee")]
        public HttpResponseMessage Put(Employee employee)
        {
            HttpResponseMessage response;
            var employees = Controller.UpdateEmployee(employee);
            if (employees == 0)
                response = Request.CreateResponse(HttpStatusCode.BadRequest, employees);
            else
                response = Request.CreateResponse(HttpStatusCode.OK, employees);
            return response;
        }

        [Route("api/deleteEmployee/{id?}")]
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response;
            Employee employee = new Employee { Id = id.ToString() };
            var employees = Controller.DeleteEmployee(employee);
            if (employees == 0)
                response = Request.CreateResponse(HttpStatusCode.BadRequest, employees);
            else
                response = Request.CreateResponse(HttpStatusCode.OK, employees);
            return response;
        }

        //[Route("api/employees/{name:alpha}")]
        //public HttpResponseMessage Get(string name)
        //{
        //    var employees = Controller.SearchEmployeesByName(name);
        //    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, employees);
        //    return response;
        //}

    }
}
