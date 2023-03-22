using System;
using System.Linq;
using System.Linq.Expressions;

namespace VulnerableWebApp.Interfaces
{
    public interface IGenericDataRepository<T> where T : class, IEntity
    {
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        IQueryable<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        void Add(params T[] items);
        void Update(params T[] items);
        void Remove(params T[] items);
    }
}
