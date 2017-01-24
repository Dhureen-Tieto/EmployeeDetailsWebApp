using EmployeeDetailsWebApp.Model;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        [Route("api/employees")]
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
        [Route("api/employee/{id?}")]
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

        [Route("api/employee/create")]
        public HttpResponseMessage Post(Employee employee)
        {
            HttpResponseMessage response;
            var employees = Controller.CreateNewEmployee(employee);
            if (employees == 0)
                response = Request.CreateResponse(HttpStatusCode.BadRequest, employees);
            else
            {
                var responseContent = Controller.RetrieveEmployees();
                response = Request.CreateResponse(HttpStatusCode.OK, employees);
                response.Content.ReadAsAsync<IEnumerable<Employee>>();
            }
                
            return response;
        }

        [Route("api/employee/update")]
        public HttpResponseMessage Put(Employee employee)
        {
            HttpResponseMessage response;
            var employees = Controller.UpdateEmployee(employee);
            if (employees == 0)
                response = Request.CreateResponse(HttpStatusCode.BadRequest, employees);
            else
            {
                var responseContent = Controller.RetrieveEmployee(employee);
                response = Request.CreateResponse(HttpStatusCode.OK, employees);
                response.Content.ReadAsAsync<IEnumerable<Employee>>();
            }
                
            return response;
        }

        [Route("api/employee/delete/{id?}")]
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
    }
}
