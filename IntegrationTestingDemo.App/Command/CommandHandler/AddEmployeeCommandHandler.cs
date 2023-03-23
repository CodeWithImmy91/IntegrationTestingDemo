using IntegrationTestingDemo.Core.Contracts.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestingDemo.App.Command.CommandHandler
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, bool>
    {
        private IEmployeeRepository _employeeRepository { get; set; }

        public AddEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        async Task<bool> IRequestHandler<AddEmployeeCommand, bool>.Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
           return await _employeeRepository.Create(new Core.Models.Employee()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Location = request.Location
            });
        }
    }
}
