using IntegrationTestingDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestingDemo.Core.Contracts.Repository
{
    public interface IEmployeeRepository:IRepositoryBase<Employee>
    {
    }
}
