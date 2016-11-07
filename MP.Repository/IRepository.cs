using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MP.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int Count();

        int Count(Expression<Func<TEntity, bool>> whereClause);

        IEnumerable<TEntity> Find();

        IEnumerable<TEntity> Find(int pgSize, int pgNum);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> whereClause);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> whereClause, int pgSize, int pgNum);

        IEnumerable<TEntity> Find<T>(Expression<Func<TEntity, bool>> whereClause, Expression<Func<TEntity, T>> orderbyClause, bool des);

        IEnumerable<TEntity> Find<T>(Expression<Func<TEntity, bool>> whereClause, Expression<Func<TEntity, T>> orderbyClause, bool des, int pgSize, int pgNum);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> whereClause);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> whereClause);

        TEntity LastOrDefault(Expression<Func<TEntity, bool>> whereClause);

        void Insert(TEntity entity);

        void Insert(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);

        void Delete(IEnumerable<TEntity> enities);

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);

        void Save();
    }
}
