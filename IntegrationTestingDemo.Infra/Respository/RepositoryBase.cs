using IntegrationTestingDemo.Core.Contracts.Repository;
using Microsoft.EntityFrameworkCore;


namespace IntegrationTestingDemo.Infra.Respository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T:class
    {
        public RepositoryBase(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        private EmployeeContext _employeeContext { get; set; }
        public async Task<bool> Create(T entity)
        {
           await _employeeContext.Set<T>().AddAsync(entity);
            return await _employeeContext.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> DeleteByCodition(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            var entity = await _employeeContext.Set<T>().FirstOrDefaultAsync(expression);
            if (entity == null)
                return false;
            _employeeContext.Set<T>().Remove(entity);
            return await _employeeContext.SaveChangesAsync() > 0;
        }

        public virtual async Task<IReadOnlyList<T>> GetAll()
        {
            return await _employeeContext.Set<T>().ToListAsync();
        }

        public virtual async Task<List<T>> FindByCodition(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return await _employeeContext.Set<T>().Where(expression).ToListAsync();
        }

        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
