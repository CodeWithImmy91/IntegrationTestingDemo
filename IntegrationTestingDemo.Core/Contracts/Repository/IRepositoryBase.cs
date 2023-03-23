using IntegrationTestingDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestingDemo.Core.Contracts.Repository
{
    public interface IRepositoryBase<T> where T:class
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<bool> DeleteByCodition(Expression<Func<T, bool>> expression);
        Task<bool> Update(T entity);
        Task<bool> Create(T entity);
        Task<List<T>> FindByCodition(Expression<Func<T, bool>> expression);
    }
}
