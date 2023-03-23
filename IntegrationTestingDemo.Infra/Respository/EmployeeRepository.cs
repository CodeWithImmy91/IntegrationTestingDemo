using IntegrationTestingDemo.Core.Contracts.Repository;
using IntegrationTestingDemo.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IntegrationTestingDemo.Infra.Respository
{
    public class EmployeeRepository:RepositoryBase<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(EmployeeContext employeeContext):base(employeeContext) 
        {
            _employeeContext = employeeContext;
        }

        private EmployeeContext _employeeContext { get; set; }

        public override async Task<IReadOnlyList<Employee>> GetAll()
        {
            return await _employeeContext.Employees.Where(x => !x.IsDeleted).ToListAsync();

        }

        public override  async Task<bool> DeleteByCodition(Expression<Func<Employee, bool>> expression)
        {
          var result=  await _employeeContext.Employees.FirstOrDefaultAsync(expression);
            if (result == null)
                return false;
            result.IsDeleted = true;
           _employeeContext.Entry<Employee>(result).State=EntityState.Modified;
            return await _employeeContext.SaveChangesAsync()>0;

        }
    }
}
