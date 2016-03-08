using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PhotoAlbum.DAL.Entities;

namespace PhotoAlbum.DAL.Interfaces
{
    public interface IGenericRepository<T> : IDisposable where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Delete(T entity);
        Task<int> CountAsync();
        void Update(T entity);
    }
}