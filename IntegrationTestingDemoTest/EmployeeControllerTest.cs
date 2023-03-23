using IntegrationTestingDemo;
using IntegrationTestingDemo.Core.Models;
using IntegrationTestingDemoTest.Helper;
using Newtonsoft.Json;
using NUnit.Framework;


namespace IntegrationTestingDemoTest
{
    internal class EmployeeControllerTest
    {
        CustomWebApplicationFactory<Startup> _customWebApplicationFactory;
        public EmployeeControllerTest()
        {
            _customWebApplicationFactory = new CustomWebApplicationFactory<Startup>();
        }
        public HttpClient GetClient() => _customWebApplicationFactory.CreateClient();

        [Test]
        public async Task EmployeeController_GetAll_ShouldGetEmployeeData()
        {
            var client = GetClient();
            var result = await client.GetAsync("/api/Employee/GetAll");
            var responseString = await result.Content.ReadAsStringAsync();
            var actualResult = JsonConvert.DeserializeObject<List<Employee>>(responseString);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK && actualResult.Count>0);
        }
        [Test]
        public async Task EmployeeController_AddEmployee_EmployeeAdded()
        {
            var client = GetClient();
            var result = await client.PostAsync("api/employee/AddEmployee",
                ContentHelper.GetStringContent(new Employee() { FirstName = "TestName",LastName = "TestLastName",Location = "TestLocation"
                }));
            var actualResult = await result.Content.ReadAsStringAsync();
            Assert.That(actualResult , Is.EqualTo("Employee Added successfully")); 
        }
    }
}
