using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MySqlSample.Api.Data.Mapping;

namespace MySqlSample.Api.Data.Repository
{
    public interface IRepository<T> where T : Entity
    {
        long Insert(T entity);
        bool Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        T GetById(long id);
    }
}