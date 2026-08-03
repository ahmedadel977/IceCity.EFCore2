using System.Linq.Expressions;

namespace IceCity.EFCore2.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
   
    Task<IEnumerable<T>> GetAllAsync();

    Task<T?> GetByIdAsync(int id);

    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

   
    Task AddAsync(T entity);

    

    void Update(T entity);

    // Delete

    void Delete(T entity);

    // Save

    Task<int> SaveChangesAsync();
}
