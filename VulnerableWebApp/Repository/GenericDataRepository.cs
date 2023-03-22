using VulnerableWebApp.Interfaces;
using VulnerableWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace VulnerableWebApp.Repository
{
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class, IEntity
    {
        private static DBContext _context;

        public GenericDataRepository()
        {
            _context = new DBContext();
        }
        public virtual IQueryable<T> GetAll(params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            if (_context == null) _context = new DBContext();

            IQueryable<T> list;
            IQueryable<T> dbQuery = _context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = dbQuery
                .AsNoTracking()
                .AsQueryable<T>();
            return list;
        }

        public virtual IQueryable<T> GetList(Func<T, bool> where, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            if (_context == null) _context = new DBContext();

            IQueryable<T> list;
            IQueryable<T> dbQuery = _context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = dbQuery
                .AsNoTracking()
                .Where(where)
                .AsQueryable<T>();
            return list;
        }

        public virtual T GetSingle(Func<T, bool> where, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            if (_context == null) _context = new DBContext();

            T item = null;
            IQueryable<T> dbQuery = _context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            item = dbQuery
                .AsNoTracking() //Don't track any changes for the selected item
                .FirstOrDefault(where); //Apply where clause
            return item;
        }

        public virtual void Add(params T[] items)
        {
            Update(items);
        }

        public virtual void Update(params T[] items)
        {
            DbSet<T> dbSet = _context.Set<T>();
            foreach (T item in items)
            {
                dbSet.Add(item);
                foreach (var entry in _context.ChangeTracker.Entries<IEntity>())
                {
                    IEntity entity = entry.Entity;
                    entry.State = GetEntityState(entity.EntityState);
                }
            }
            _context.SaveChanges();
        }

        protected static Microsoft.EntityFrameworkCore.EntityState GetEntityState(Constants.EntityState entityState)
        {
            Microsoft.EntityFrameworkCore.EntityState orientation = entityState switch
            {
                Constants.EntityState.Unchanged => Microsoft.EntityFrameworkCore.EntityState.Unchanged,
                Constants.EntityState.Added => Microsoft.EntityFrameworkCore.EntityState.Added,
                Constants.EntityState.Modified => Microsoft.EntityFrameworkCore.EntityState.Modified,
                Constants.EntityState.Deleted => Microsoft.EntityFrameworkCore.EntityState.Deleted,
                _ => Microsoft.EntityFrameworkCore.EntityState.Detached,
            };

            return orientation;
        }


        public virtual void Remove(params T[] items)
        {
            Update(items);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

    }
}
