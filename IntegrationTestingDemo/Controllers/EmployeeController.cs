using IntegrationTestingDemo.App.Command;
using IntegrationTestingDemo.App.Query;
using IntegrationTestingDemo.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationTestingDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private IMediator _mediator { get; set; }

        [HttpGet]
        public async Task<IReadOnlyList<Employee>> GetAll()
        {
           return await _mediator.Send(new GetAllEmployee());
        }

        [HttpPost]
        public async Task<string> AddEmployee(AddEmployeeCommand emp)
        {
          var result=  await _mediator.Send(emp);

            if(result)
                return "Employee Added successfully";

            return "Something went wrong! Please try after sometime";
        }

        [HttpDelete]
        public async Task<string> DeleteEmployeeById(DeleteEmployeeByIdCommand deleteEmployeeByIdCommand)
        {
            var result = await _mediator.Send(deleteEmployeeByIdCommand);
            if (result)
            {
                return "Employee deleted suceessfully";
            }

            return "Something went wrong! Please try after sometime";
        }

        
    }
}
