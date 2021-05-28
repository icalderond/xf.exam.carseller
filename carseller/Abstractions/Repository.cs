using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SQLite;

namespace carseller.Abstractions
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly SQLiteAsyncConnection db;

        public Repository(string connectionString)
        {
            this.db = new SQLiteAsyncConnection(connectionString);
        }

        public async Task Initialize()
        {
            await this.db.CreateTableAsync<T>();//.ConfigureAwait(false);
        }

        public AsyncTableQuery<T> AsQueryable() => db.Table<T>();

        public async Task<List<T>> Get()
        {
            try
            {
                var result = await db.Table<T>().ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            var query = db.Table<T>();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = query.OrderBy<TValue>(orderBy);

            return await query.ToListAsync();
        }

        public async Task<T> Get(int id) =>
             await db.FindAsync<T>(id);

        public async Task<T> Get(Expression<Func<T, bool>> predicate) =>
            await db.FindAsync<T>(predicate);

        public async Task<int> Insert(T entity) =>
             await db.InsertAsync(entity);

        public async Task<int> Update(T entity) =>
             await db.UpdateAsync(entity);

        public async Task<int> Delete(T entity) =>
             await db.DeleteAsync(entity);
    }
}
