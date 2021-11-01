
using Proj.Api.DataAccess;
using Proj.Api.Entity;
using Proj.Api.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Proj.Api.Service
{
    public class ProductService : IProductRepo
    {
        private readonly ProjDbContext _dbContext;
        public ProductService(ProjDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Create(Product entity)
        {
            _dbContext.Products.Add(entity);
            _dbContext.Entry(entity.Category).State = EntityState.Detached;
            _dbContext.SaveChanges();

            return true;
        }

        public bool Delete(Product entity)
        {
            _dbContext.Entry(entity).State = EntityState.Detached;
            _dbContext.Products.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {

            return filter == null ?
                _dbContext.Products.Include(c => c.Category).FirstOrDefault()
                : _dbContext.Products.Include(c => c.Category).Where(filter).FirstOrDefault();
        }
        public ICollection<Product> GetList(Expression<Func<Product, bool>> filter = null)
        {
            return filter == null ?
                _dbContext.Products.Include(c => c.Category).ToList()
                : _dbContext.Products.Include(c => c.Category).Where(filter).ToList();
        }

        public bool Update(Product entity)
        {
            _dbContext.Products.Update(entity);
            _dbContext.Entry(entity.Category).State = EntityState.Unchanged;
            _dbContext.SaveChanges();
            return true;
        }
    }
}
