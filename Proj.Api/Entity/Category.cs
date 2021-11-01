using Proj.Api.Entity.EntityBase;
using System.Collections.Generic;

namespace Proj.Api.Entity
{
    public class Category:IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int MinStockquantity { get; set; }
        public List<Product> Products { get; set; }
    }
}
