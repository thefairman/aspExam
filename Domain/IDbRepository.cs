using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IDbRepository<T> 
        where T:class, IDbEntity
    {
        IQueryable<T> AllItems { get; }
        Task<List<T>> ToListAsync();
        Task<int> AddItemAsync(T item);
        Task<int> AddItemsAsync(IEnumerable<T> items);
        Task<T> GetItemAsync(Guid id);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItem(Guid id);
        Task<int> SaveChangesAsync();
    }
}
