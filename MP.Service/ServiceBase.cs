using MP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MP.Service
{
    public class ServiceBase<TEntity> where TEntity : class
    {
        public Repository<TEntity> _dao;

        public ServiceBase()
        {
            _dao = new Repository<TEntity>();
        }

        public int Count()
        {
            return _dao.Count();
        }
        public int Count(Expression<Func<TEntity, bool>> whereClause)
        {
            return _dao.Count(whereClause);
        }

        public IEnumerable<TEntity> Find()
        {
            return _dao.Find();
        }
        public IEnumerable<TEntity> Find(int pgSize, int pgNum)
        {
            return _dao.Find(pgSize, pgNum);
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> whereClause)
        {
            return _dao.Find(whereClause);
        }
        //public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> whereClause, int pgSize, int pgNum)
        //{
        //    return _dao.Find(whereClause, pgSize, pgNum);
        //}
        public IEnumerable<TEntity> Find<T>(Expression<Func<TEntity, bool>> whereClause, Expression<Func<TEntity, T>> orderbyClause, bool des)
        {
            return _dao.Find(whereClause, orderbyClause, des);
        }
        public IEnumerable<TEntity> Find<T>(Expression<Func<TEntity, bool>> whereClause, Expression<Func<TEntity, T>> orderbyClause, bool des, int pgSize, int pgNum)
        {
            return _dao.Find(whereClause, orderbyClause, des, pgSize, pgNum);

        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> whereClause)
        {
            return _dao.SingleOrDefault(whereClause);
        }
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> whereClause)
        {
            return _dao.FirstOrDefault(whereClause);
        }
        public TEntity LastOrDefault(Expression<Func<TEntity, bool>> whereClause)
        {
            return _dao.LastOrDefault(whereClause);
        }

        public void Insert(TEntity entity)
        {
            _dao.Insert(entity);
        }
        public void Insert(IEnumerable<TEntity> entities)
        {
            _dao.Insert(entities);
        }

        public void Delete(TEntity entity)
        {
            _dao.Delete(entity);
        }
        public void Delete(IEnumerable<TEntity> enities)
        {
            _dao.Delete(enities);
        }

        public void Update(TEntity entity)
        {
            _dao.Update(entity);

        }
        public void Update(IEnumerable<TEntity> entities)
        {
            _dao.Update(entities);
        }

        public void Save()
        {
            _dao.Save();
        }
        public void Dispose()
        {
            _dao.Dispose();
        }
    }
}
