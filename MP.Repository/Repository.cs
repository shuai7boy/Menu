using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MP.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        public DbContext context;

        public Repository()
        {
            this.context = new MP.Entity.Models.MenuContext();
        }

        protected DbContext _context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public int Count()
        {
            DbSet<TEntity> query = context.Set<TEntity>();
            return query.Count();
        }
        public int Count(Expression<Func<TEntity, bool>> whereClause)
        {
            DbSet<TEntity> query = context.Set<TEntity>();
            return query.Count(whereClause);
        }

        public IEnumerable<TEntity> Find()
        {
            DbSet<TEntity> query = context.Set<TEntity>();
            return query.Select(p => p);
        }
        public IEnumerable<TEntity> Find(int pgSize, int pgNum)
        {
            DbSet<TEntity> query = context.Set<TEntity>();
            return query.Select(p => p).Skip((pgNum - 1) * pgSize).Take(pgSize);
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> whereClause)
        {
            DbSet<TEntity> query = context.Set<TEntity>();
            return query.Select(p => p).Where(whereClause);
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> whereClause, int pgSize, int pgNum)
        {
            DbSet<TEntity> query = context.Set<TEntity>();
            return query.Select(p => p).Where(whereClause).Skip((pgNum - 1) * pgSize).Take(pgSize);
        }
        public IEnumerable<TEntity> Find<T>(Expression<Func<TEntity, bool>> whereClause, Expression<Func<TEntity, T>> orderbyClause, bool des)
        {
            DbSet<TEntity> query = context.Set<TEntity>();
            if (des)
            {
                return query.Select(p => p).Where(whereClause).OrderByDescending(orderbyClause);
            }
            return query.Select(p => p).Where(whereClause).OrderBy(orderbyClause);
        }
        public IEnumerable<TEntity> Find<T>(Expression<Func<TEntity, bool>> whereClause, Expression<Func<TEntity, T>> orderbyClause, bool des, int pgSize, int pgNum)
        {
            DbSet<TEntity> query = context.Set<TEntity>();
            if (des)
            {
                return query.Select(p => p).Where(whereClause).OrderByDescending(orderbyClause).Skip((pgNum - 1) * pgSize).Take(pgSize);
            }
            return query.Select(p => p).Where(whereClause).OrderBy(orderbyClause).Skip((pgNum - 1) * pgSize).Take(pgSize);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> whereClause)
        {
            DbSet<TEntity> query = context.Set<TEntity>();
            return query.SingleOrDefault(whereClause);
        }
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> whereClause)
        {
            DbSet<TEntity> query = context.Set<TEntity>();
            return query.FirstOrDefault(whereClause);
        }
        public TEntity LastOrDefault(Expression<Func<TEntity, bool>> whereClause)
        {
            DbSet<TEntity> query = context.Set<TEntity>();
            return query.LastOrDefault(whereClause);
        }

        public void Insert(TEntity entity)
        {
            DbSet<TEntity> query = context.Set<TEntity>();
            query.Add(entity);
        }
        public void Insert(IEnumerable<TEntity> entities)
        {
            DbSet<TEntity> query = context.Set<TEntity>();
            foreach (TEntity en in entities)
            {
                query.Add(en);
            }
        }

        public void Delete(TEntity entity)
        {
            DbSet<TEntity> query = context.Set<TEntity>();
            query.Remove(entity);
        }
        public void Delete(IEnumerable<TEntity> enities)
        {
            DbSet<TEntity> query = context.Set<TEntity>();
            foreach (TEntity en in enities)
            {
                query.Remove(en);
            }
        }

        public void Update(TEntity entity)
        {
            DbSet<TEntity> query = context.Set<TEntity>();
            var stateEntry = ((IObjectContextAdapter)context).ObjectContext;
            query.Attach(entity);
            stateEntry.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }
        public void Update(IEnumerable<TEntity> entities)
        {
            DbSet<TEntity> query = context.Set<TEntity>();
            var stateEntry = ((IObjectContextAdapter)context).ObjectContext;
            foreach (var entity in entities)
            {
                query.Attach(entity);
                stateEntry.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            }
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }
        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
