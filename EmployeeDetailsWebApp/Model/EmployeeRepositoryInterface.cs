using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetailsWebApp.Model
{
    public interface IEmployeeRepositoryInterface
    {
        List<Employee> GetEmployees();
        Employee GetEmployeeById(string id);
        int InsertEmployeeById(Employee employee);
        int UpdateEmployeeById(Employee employee);
        int DeleteEmployeeById(string id);
    }
}
