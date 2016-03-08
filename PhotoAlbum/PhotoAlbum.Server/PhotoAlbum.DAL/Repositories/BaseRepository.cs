using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces;

namespace PhotoAlbum.DAL.Repositories
{
    public class BaseRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly IdentityDbContext<ApplicationUser> Database;

        public BaseRepository(IdentityDbContext<ApplicationUser> database)
        {
            Database = database;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => 
            await Database.Set<T>().ToListAsync();


        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate) => 
             Database.Set<T>().Where(predicate).AsEnumerable();


        public T Add(T entity) => Database.Set<T>().Add(entity);

        public T Delete(T entity) => Database.Set<T>().Remove(entity);

        public async Task<int> CountAsync() => await Database.Set<T>().CountAsync();

        public void Update(T entity) => Database.Entry(entity).State = EntityState.Modified;

        public void Dispose() => Database.Dispose();
    }
}