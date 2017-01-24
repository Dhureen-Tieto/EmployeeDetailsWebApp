using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EmployeeDetailsWebApp.Model
{
    public class EmployeeRepositoryAccessUsingDapper:IEmployeeRepositoryInterface
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["EmployeeDatabaseConnectionString"].ConnectionString;
        public int DeleteEmployeeById(string id)
        {
            // throw new NotImplementedException();
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();                 
                    string query = "DELETE FROM EmployeeDetails2 WHERE Id = @Id";
                    var result = connection.Execute(query, new { Id = id });
                    connection.Close();
                    return result;
                }
                catch
                {
                    return 0;
                }

            }
        }

        public Employee GetEmployeeById(string id)
        {
            //throw new NotImplementedException();
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Employee employee = new Employee() { Id = id };
                    string query = "SELECT * FROM EmployeeDetails2 WHERE Id = @Id";
                    var result = connection.Query<Employee>(query, employee).SingleOrDefault<Employee>();
                    connection.Close();
                    return result;
                }
                catch
                {
                    return null;
                }

            }
        }

        public int InsertEmployeeById(Employee employee)
        {
            // throw new NotImplementedException();
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO EmployeeDetails2(Id,FirstName,LastName,EmailId, PhoneNumber, Age, ActiveStatus)values(@Id, @FirstName, @LastName, @EmailId, @PhoneNumber, @Age, @ActiveStatus) ";
                    var result = connection.Execute(query, employee);
                    connection.Close();
                    return result;
                }
                catch
                {
                    return 0;
                }

            }
        }

        public int UpdateEmployeeById(Employee employee)
        {
            // throw new NotImplementedException();
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();                  
                    string query = "UPDATE EmployeeDetails2 SET Id = @Id, FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber, Age = @Age, ActiveStatus = @ActiveStatus WHERE Id = @Id ";
                    var result = connection.Execute(query, employee);
                    connection.Close();
                    return result;
                }
                catch
                {
                    return 0;
                }

            }
        }

        public List<Employee> GetEmployees()
        {
            // throw new NotImplementedException();
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM EmployeeDetails2";
                    List<Employee> result;
                    result = connection.Query<Employee>(query).ToList();
                    connection.Close();
                    return result;
                }
                catch
                {
                    return null;
                }
            }
        }

        

    }
}