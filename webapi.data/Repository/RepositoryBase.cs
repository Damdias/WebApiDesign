using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using webapi.core.Entities;

namespace webapi.data.Repository
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        private readonly IProductDbContext productDBContext;

        public RepositoryBase(IProductDbContext productDBContext)
        {
            this.productDBContext = productDBContext;
        }

        public void Add(T entity)
        {
            productDBContext.DbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            productDBContext.DbContext.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            var orgEntity = GetById(entity.Id);
            if (orgEntity != null)
            {
                productDBContext.DbContext.Entry(orgEntity).CurrentValues.SetValues(entity);
            }
        }

        public T GetById(Guid id)
        {
            return productDBContext.DbContext.Set<T>().Find(id);
        }
        public void Delete(Guid id)
        {
            var entity = GetById(id);
            Delete(entity);
        }

        public IEnumerable<T> List()
        {
            return productDBContext.DbContext.Set<T>().ToList();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> predicate)
        {
            return productDBContext.DbContext.Set<T>().Where(predicate).ToList();
        }
    }
}
