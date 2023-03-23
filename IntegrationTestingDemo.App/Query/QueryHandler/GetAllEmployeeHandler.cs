using IntegrationTestingDemo.Core.Contracts.Repository;
using IntegrationTestingDemo.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestingDemo.App.Query.QueryHandler
{
    internal class GetAllEmployeeHandler : IRequestHandler<GetAllEmployee, IReadOnlyList<Employee>>
    {
        public GetAllEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        private IEmployeeRepository _employeeRepository { get; set; }
        public Task<IReadOnlyList<Employee>> Handle(GetAllEmployee request, CancellationToken cancellationToken)
        {
            return _employeeRepository.GetAll();
        }
    }
}
