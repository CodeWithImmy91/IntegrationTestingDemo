using MediatR;


namespace IntegrationTestingDemo.App.Command
{
    public class DeleteEmployeeByIdCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
