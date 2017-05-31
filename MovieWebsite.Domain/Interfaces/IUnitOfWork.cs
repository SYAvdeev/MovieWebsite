using System;
using MovieWebsite.Domain.Entities;

namespace MovieWebsite.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Movie> Movies { get; }
        IRepository<Actor> Actors { get; }
        IRepository<Genre> Genres { get; }

        void Save();
    }
}
