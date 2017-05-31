using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MovieWebsite.Domain.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();

        T GetByID(int id);

        void Insert(T entity);

        void Delete(int id);

        void Delete(T entityToDelete);

        void Update(T entityToUpdate);
    }
}
