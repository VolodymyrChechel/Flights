using System;
using System.Linq;

namespace Airline.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Get(object key);
        IQueryable<T> Find(Func<T, bool> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(object key);
    }
}