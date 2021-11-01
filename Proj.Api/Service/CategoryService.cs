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
    public class CategoryService : ICategoryRepo
    {
        private readonly ProjDbContext _dbContext;
        public CategoryService(ProjDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Create(Category entity)
        {
            _dbContext.Categories.Add(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(Category entity)
        {
            _dbContext.Categories.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }

       
        public Category Get(Expression<Func<Category, bool>> filter = null)
        {
            return filter == null ?
                _dbContext.Categories.Include(p => p.Products).FirstOrDefault()
                : _dbContext.Categories.Include(p => p.Products).Where(filter).FirstOrDefault();
                
        }

        public ICollection<Category> GetList(Expression<Func<Category, bool>> filter = null)
        {
            return filter==null?
                _dbContext.Categories.Include(p=>p.Products).ToList()
                :_dbContext.Categories.Include(p=>p.Products).Where(filter).ToList();
        }

        public bool Update(Category entity)
        {
            _dbContext.Categories.Update(entity);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
