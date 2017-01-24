using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeDetailsWebApp.Model;
 
namespace EmployeeDetailsWebApp
{
    public class EmployeeController
    {
        private IEmployeeRepositoryInterface employeeRepository;
        public EmployeeController(IEmployeeRepositoryInterface employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        private static bool CheckIfFirstNameOrLastName(Employee employee)
        {
            return string.IsNullOrEmpty(employee.FirstName) || string.IsNullOrEmpty(employee.LastName);
        }
        private static bool CheckIfEmailIsNullOrEmpty(Employee employee)
        {
            return string.IsNullOrEmpty(employee.EmailId);
        }

        public int CreateNewEmployee(Employee employee)
        {
            int status;
            RegexUtilities emailValidator = new RegexUtilities();
            try
            {
                if (CheckIfFirstNameOrLastName(employee) || CheckIfEmailIsNullOrEmpty(employee) || !emailValidator.IsValidEmail(employee.EmailId))
                    status = 0;
                else
                    status = employeeRepository.InsertEmployeeById(employee);
                return status;
            }
            catch
            {
                return 0;
            }
            
        }
        public Employee RetrieveEmployee(Employee employee)
        {
            try
            {
                return employeeRepository.GetEmployeeById(employee.Id);
            }
            catch
            {
                return null;
            }
        }   
        public List<Employee> RetrieveEmployees()
        {
            try
            {
                return employeeRepository.GetEmployees();
            }
            catch
            {
                return null;
            }            
        }
        public int UpdateEmployee(Employee employee)
        {
            int status;
            try
            {
                if (CheckIfFirstNameOrLastName(employee) || !CheckIfEmailIsNullOrEmpty(employee))
                    status = 0;
                else
                    status = employeeRepository.UpdateEmployeeById(employee);
                return status;
            }
            catch
            {
                return 0;
            }
        }
        public int DeleteEmployee(Employee employee)
        {
            int status;
            try
            {
                Employee employeeFromRepo = RetrieveEmployee(employee);
                if (employeeFromRepo == null)
                    status = 0;
                else if (employeeFromRepo.ActiveStatus == "Active")
                    status = 0;
                else
                    status = employeeRepository.DeleteEmployeeById(employeeFromRepo.Id);
                return status;
            }
            catch
            {
                return 0;
            }
            
        }
        //public int DeleteEmployees(Employee[] employees)
        //{

        //}
    }
}