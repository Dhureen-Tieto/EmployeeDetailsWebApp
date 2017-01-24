using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using EmployeeDetailsWebApp.Model;
using EmployeeDetailsWebApp.Controller;
using System.Windows;
using EmployeeDetailsWebApp;

namespace EmployeeApiClient
{
    class EmployeeClientViewModel
    {
        private void BindEmployeeList()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:3339/");
            //client.DefaultRequestHeeaders.Add("appkey", "myapp_key");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/employee").Result;
            if (response.IsSuccessStatusCode)
            {
                var employees = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                employeeGrid.ItemsSource = employees;

            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindEmployeeList();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
        }
    }
 }

