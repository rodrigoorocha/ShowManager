using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShowManager.Dominio.Features.Shared
{
    public interface IRepositoryAntigo <T> where T : class
    {
        Task <T>SaveAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>?> GetByIdsAsync(List<int> ids);
        Task<IEnumerable<T>?> GetAllAsync();
        Task<IEnumerable<T>?> FindAllByCriterioAsync(Expression<Func<T, bool>> expression);
        Task<T?> FindOneByCriterioAsync(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    }

}
