using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino;
using Rhino.Mocks;
using EmployeeDetailsWebApp;
using EmployeeDetailsWebApp.Model;
namespace NUnit.Tests1
{
    [TestFixture]
    public class TestEmployeeController
    {        
        private Employee mockEmployee1 = new Employee()
        {
            Id = "1000",
            FirstName = "Mock_First_Name",
            LastName = "Mock_Last_Name",
            EmailId = "dhureen.m@gmail.com",
            Age = 20,
            ActiveStatus = "Active"
        };
        private Employee mockEmployee2 = new Employee()
        {
            Id = "1001",
            //FirstName = "Mock_First_Name_2",
            LastName = "Mock_Last_Name_2",
            EmailId = "mockid.m@mock.com",
            Age = 20,
            ActiveStatus = "Active"
        };
        private Employee mockEmployee3 = new Employee()
        {
            Id = "1002",
            FirstName = "Mock_First_Name_2",
            LastName = "Mock_Last_Name_2",
            //EmailId = "Mock_Id_2.m@mock.com",
            Age = 20,
            ActiveStatus = "Active"
        };
        private Employee mockEmployee4 = new Employee()
        {
            Id = "1003",
            FirstName = "Mock_First_Name_2",
            LastName = "Mock_Last_Name_2",
            EmailId = "mockid.mmock.com",
            Age = 20,
            ActiveStatus = "Active"
        };
        private Employee mockEmployee5 = new Employee()
        {
            Id = "1004",
            FirstName = "Mock_First_Name_2",
            //LastName = "Mock_Last_Name_2",
           // EmailId = "Mock_Id_2.mmock.com",
            Age = 20,
            ActiveStatus = "Active"
        };
        private Employee mockEmployee6 = new Employee()
        {
            Id = "1005",
            FirstName = "Mock_First_Name_2",
            LastName = "Mock_Last_Name_2",
            EmailId = "mockid.m@mock.com",
            Age = 20,
            ActiveStatus = "Active"
        };
        private Employee mockEmployee7 = new Employee()
        {
            Id = "1006",
            FirstName = "Mock_First_Name_2",
            LastName = "Mock_Last_Name_2",
            //EmailId = "Mock_Id_2.m@mock.com",
            Age = 20,
            ActiveStatus = "Active"
        };
        private Employee mockEmployee8 = new Employee()
        {
            Id = "1007",
            FirstName = "Mock_First_Name_2",
            LastName = "Mock_Last_Name_2",
            EmailId = "Mock_Id_2.m@mock.com",
            Age = 20,
            ActiveStatus = "Active"
        };
        private Employee mockEmployee9 = new Employee()
        {
            Id = "1008",
            FirstName = "Mock_First_Name_2",
            LastName = "Mock_Last_Name_2",
            EmailId = "Mock_Id_2.m@mock.com",
            Age = 20,
            ActiveStatus = "Active"
        };
        private Employee mockEmployee10 = new Employee()
        {
            Id = "1009",
            FirstName = "Mock_First_Name_2",
            LastName = "Mock_Last_Name_2",
            EmailId = "Mock_Id_2.m@mock.com",
            Age = 20,
            ActiveStatus = "Inactive"
        };
        private Employee mockEmployee11 = new Employee()
        {
            Id = "1010",
            FirstName = "Mock_First_Name_2",
            LastName = "Mock_Last_Name_2",
            EmailId = "Mock_Id_2.m@mock.com",
            Age = 20,
            ActiveStatus = "Active"
        };
        private List<Employee> mockEmployeeList ;    

        [SetUp]
        public void TestInit()
        {
            mockEmployeeList = new List<Employee>();
            mockEmployeeList.Add(mockEmployee1);
            mockEmployeeList.Add(mockEmployee2);           
        }
        [Test]
        public void GivingEmployeeWithValidDetailsOnCreateReturnsOne()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepositoryInterface>();
            employeeRepositoryMock.Expect(x => x.InsertEmployeeById(mockEmployee1)).Return(1);            
            EmployeeController employeeController = new EmployeeController(employeeRepositoryMock);
            var result = employeeController.CreateNewEmployee(mockEmployee1);
            Assert.AreEqual(1,result,"Result is not 1");
        }
        [Test]
        public void GivingEmployeeWithEmptyFirstNameOrLastNameOnCreateReturnsZero()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepositoryInterface>();
            employeeRepositoryMock.Expect(x => x.InsertEmployeeById(mockEmployee2)).Return(1);
            EmployeeController employeeController = new EmployeeController(employeeRepositoryMock);
            var result = employeeController.CreateNewEmployee(mockEmployee2);
            Assert.AreEqual(0, result, "Result is not 0");
        }
        [Test]
        public void GivingEmployeeWithEmptyEmailOnCreateReturnsZero()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepositoryInterface>();
            employeeRepositoryMock.Expect(x => x.InsertEmployeeById(mockEmployee3)).Return(1);
            EmployeeController employeeController = new EmployeeController(employeeRepositoryMock);
            var result = employeeController.CreateNewEmployee(mockEmployee3);
            Assert.AreEqual(0, result, "Result is not 0");
        }
        [Test]
        public void GivingEmployeeWithInvalidEmailOnCreateReturnsZero()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepositoryInterface>();
            employeeRepositoryMock.Expect(x => x.InsertEmployeeById(mockEmployee4)).Return(1);
            EmployeeController employeeController = new EmployeeController(employeeRepositoryMock);
            var result = employeeController.CreateNewEmployee(mockEmployee4);
            Assert.AreEqual(0, result, "Result is not 0");
        }
        [Test]
        public void GivingEmployeeWithEmptyFirstNameOrLastNameOnEditReturnsZero()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepositoryInterface>();
            employeeRepositoryMock.Expect(x => x.UpdateEmployeeById(mockEmployee5)).Return(1);
            EmployeeController employeeController = new EmployeeController(employeeRepositoryMock);
            var result = employeeController.UpdateEmployee(mockEmployee5);
            Assert.AreEqual(0, result, "Result is not 0");
        }
        [Test]
        public void GivingEmployeeWithEmailOnEditReturnsZero()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepositoryInterface>();
            employeeRepositoryMock.Expect(x => x.UpdateEmployeeById(mockEmployee6)).Return(1);
            EmployeeController employeeController = new EmployeeController(employeeRepositoryMock);
            var result = employeeController.UpdateEmployee(mockEmployee6);
            Assert.AreEqual(0, result, "Result is not 0");
        }
        
        [Test]
        public void GivingEmployeeInvalidIdOnEditReturnsZero()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepositoryInterface>();
            employeeRepositoryMock.Expect(x => x.UpdateEmployeeById(mockEmployee7)).Return(0);
            employeeRepositoryMock.Expect(x => x.GetEmployeeById(mockEmployee7.Id)).Return(mockEmployee7);
            EmployeeController employeeController = new EmployeeController(employeeRepositoryMock);
            var result = employeeController.UpdateEmployee(mockEmployee7);
            Assert.AreEqual(0, result, "Result is not 0");
        }
        [Test]
        public void GivingEmployeeWithInvalidIdOnCreatesReturnsZero()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepositoryInterface>();
            employeeRepositoryMock.Expect(x => x.InsertEmployeeById(mockEmployee8)).Return(0);
            EmployeeController employeeController = new EmployeeController(employeeRepositoryMock);
            var result = employeeController.CreateNewEmployee(mockEmployee8);
            Assert.AreEqual(0, result, "Result is not 0");
        }
        [Test]
        public void GivingActivatedEmployeeOnDeleteReturnsZero()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepositoryInterface>();
            employeeRepositoryMock.Expect(x => x.DeleteEmployeeById(mockEmployee9.Id)).Return(1);
            EmployeeController employeeController = new EmployeeController(employeeRepositoryMock);
            var result = employeeController.DeleteEmployee(mockEmployee9);
            Assert.AreEqual(0, result, "Result is not 0");
        }
        [Test]
        public void GivingDeactivatedEmployeeOnDeleteReturnsOne()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepositoryInterface>();
            employeeRepositoryMock.Expect(x => x.DeleteEmployeeById(mockEmployee10.Id)).Return(1);
            employeeRepositoryMock.Expect(x => x.GetEmployeeById(mockEmployee10.Id)).Return(mockEmployee10);
            EmployeeController employeeController = new EmployeeController(employeeRepositoryMock);
            var result = employeeController.DeleteEmployee(mockEmployee10);
            Assert.AreEqual(1, result, "Result is not 1");
        }
        [Test]
        public void GivingEmployeeWithInvalidIdOnDeleteReturnsZero()
        {
            var employeeRepositoryMock = MockRepository.GenerateMock<IEmployeeRepositoryInterface>();
            employeeRepositoryMock.Expect(x => x.DeleteEmployeeById(mockEmployee11.Id)).Return(0);
            EmployeeController employeeController = new EmployeeController(employeeRepositoryMock);
            var result = employeeController.DeleteEmployee(mockEmployee11);
            Assert.AreEqual(0, result, "Result is not 0");
        }
    }
}
