using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Airline.DAL.Interfaces;

namespace Airline.DAL.Repositories
{
    public abstract class GenericRepository<C, T> :
        IGenericRepository<T> where T : class where C : DbContext
    {
        private C db;

        protected GenericRepository(C context)
        {
            db = context;
        }

        public virtual void Create(T item)
        {
            db.Set<T>().Add(item);
        }

        public virtual void Delete(object key)
        {
            var item = db.Set<T>().Find(key);
            if (item != null)
                db.Set<T>().Remove(item);
        }

        public IQueryable<T> Find(Func<T, bool> predicate)
        {
            return db.Set<T>().Where(predicate) as IQueryable<T>;
        }

        public T Get(object key)
        {
            return db.Set<T>().Find(key);
        }

        public IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }

        public virtual void Update(T item)
        {
            db.Set<T>().AddOrUpdate(item);
        }
    }
}