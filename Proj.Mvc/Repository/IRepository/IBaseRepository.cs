using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proj.Mvc.Repository.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetAsync(string url, int Id);
        Task<List<T>> GetAllAsync(string url, string filter = "");
        Task<bool> CreateAsync(string url, T obj);
        Task<bool> UpdateAsync(string url, T obj);
        Task<bool> DeleteAsync(string url, T obj);
    }
}
