using Proj.Mvc.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proj.Mvc.Repository.IRepository
{
    public interface IProductRepository: IBaseRepository<Product>
    {
        Task<List<Product>> GetAllWithRangeAsync(string url, int start, int finish);

    }
}
