using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using MovieWebsite.Domain.Interfaces;

namespace MovieWebsite.Domain
{
    public class ApplicationRepository<T> : IRepository<T> where T : class
    {
        internal ApplicationDbContext context;
        internal DbSet<T> dbSet;

        public ApplicationRepository(ApplicationDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> Get()
        {
            return dbSet.ToList();
        }

        public virtual T GetByID(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(int id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(T entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual int Count()
        {
            return dbSet.Count();
        }
    }
}
