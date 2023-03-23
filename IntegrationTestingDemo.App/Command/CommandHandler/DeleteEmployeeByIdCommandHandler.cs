using IntegrationTestingDemo.Core.Contracts.Repository;
using MediatR;


namespace IntegrationTestingDemo.App.Command.CommandHandler
{
    internal class DeleteEmployeeByIdCommandHandler : IRequestHandler<DeleteEmployeeByIdCommand, bool>
    {
        public DeleteEmployeeByIdCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEmployeeRepository  _employeeRepository { get; set; }
        public async Task<bool> Handle(DeleteEmployeeByIdCommand request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.DeleteByCodition(x => x.Id == request.Id);
        }
    }
}
