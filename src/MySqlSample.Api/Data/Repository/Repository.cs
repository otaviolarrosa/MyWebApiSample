using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dommel;
using MySqlSample.Api.Data.Connection;
using MySqlSample.Api.Data.Mapping;
using MySqlSample.Api.Ioc;

namespace MySqlSample.Api.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        IConnectionFactory _connectionFactory;

        public Repository()
        {
            _connectionFactory = ServiceLocator.Current.GetInstance<IConnectionFactory>();
        }

        public long Insert(T entity)
        {
            using (var conn = _connectionFactory.GetConnection())
            {
                return Convert.ToInt64(conn.Insert(entity));
            }
        }

        public bool Update(T entity)
        {
            using (var conn = _connectionFactory.GetConnection())
            {
                return conn.Update(entity);
            }
        }

        public void Delete(T entity)
        {
            using (var conn = _connectionFactory.GetConnection())
            {
                conn.Delete(entity);
            }
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            using (var conn = _connectionFactory.GetConnection())
                conn.DeleteMultiple<T>(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            using (var conn = _connectionFactory.GetConnection())
            {
                return conn.GetAll<T>();
            }
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            using (var conn = _connectionFactory.GetConnection())
            {
                return conn.Select<T>(predicate);
            }
        }

        public T GetById(long id)
        {
            using (var conn = _connectionFactory.GetConnection())
            {
                return conn.Select<T>(x => x.Id == id).FirstOrDefault();
            }
        }
    }
}