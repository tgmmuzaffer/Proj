using Proj.Mvc.Models;
using Proj.Mvc.Repository.IRepository;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Proj.Mvc.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public ProductRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<Product>> GetAllWithRangeAsync(string url, int start, int finish)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + start+"/" +finish);
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Product>>(jsonString);
            }

            return null;
        }
    }
}
