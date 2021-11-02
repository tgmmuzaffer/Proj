using Proj.Mvc.Models;
using Proj.Mvc.Repository.IRepository;
using System.Net.Http;

namespace Proj.Mvc.Repository
{
    public class CategoryRepository:BaseRepository<Category>, ICategoryRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public CategoryRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

    }
}
