using System.Collections.Generic;

namespace LibraryAPI.Services.Interfaces
{
    public interface ICrud<T> where T : class, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task CreateAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
    }
}
