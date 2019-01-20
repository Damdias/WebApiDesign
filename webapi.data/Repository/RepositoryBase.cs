using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using webapi.core.Entities;

namespace webapi.data.Repository
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        private readonly ProductDBContext productDBContext;

        public RepositoryBase(ProductDBContext productDBContext)
        {
            this.productDBContext = productDBContext;
        }

        public void Add(T entity)
        {
            productDBContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            productDBContext.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            var orgEntity = GetById(entity.Id);
            if (orgEntity != null)
            {
                productDBContext.Entry(orgEntity).CurrentValues.SetValues(entity);
            }
        }

        public T GetById(Guid id)
        {
            return productDBContext.Set<T>().Find(id);
        }
        public void Delete(Guid id)
        {
            var entity = GetById(id);
            Delete(entity);
        }

        public IEnumerable<T> List()
        {
            return productDBContext.Set<T>().ToList();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> predicate)
        {
            return productDBContext.Set<T>().Where(predicate).ToList();
        }
    }
}
