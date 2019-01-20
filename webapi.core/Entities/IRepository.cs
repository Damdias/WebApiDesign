using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace webapi.core.Entities
{
    public interface IRepository<T> where T:EntityBase
    {
        T GetById(Guid id);
        IEnumerable<T> List();
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Delete(Guid id);
        void Edit(T entity);
    }
}
