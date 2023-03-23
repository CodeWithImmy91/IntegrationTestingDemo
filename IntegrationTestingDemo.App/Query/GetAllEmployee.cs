using IntegrationTestingDemo.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestingDemo.App.Query
{
    public class GetAllEmployee:IRequest<IReadOnlyList<Employee>>
    {
    }
}
