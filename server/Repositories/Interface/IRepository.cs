using server.Models.Product;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repositories.Interface
{
    public interface IRepository <T>
    {
        Task<IEnumerable<T>> ListAsync(SieveModel query);
        Task<IEnumerable<T>> ListAsync(System.Linq.Expressions.Expression<Func<T, bool>> query);
        Task AddAsync(T item);
        Task<T> FindByIdAsync(long id);
        void Update(T item);
        void Remove(T item);
    }
}
