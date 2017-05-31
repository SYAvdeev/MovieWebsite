using MovieWebsite.Domain.Entities;
using MovieWebsite.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWebsite.Domain
{
    public class ApplicationUnitOfWork : IUnitOfWork
    {
        ApplicationDbContext db;
        ApplicationRepository<Movie> moviesRepository;
        ApplicationRepository<Genre> genresRepository;
        ApplicationRepository<Actor> actorsRepository;

        public ApplicationUnitOfWork(string connectionString)
        {
            db = new ApplicationDbContext(connectionString);
        }

        public IRepository<Movie> Movies
        {
            get
            {
                if (moviesRepository == null)
                    moviesRepository = new ApplicationRepository<Movie>(db);
                return moviesRepository;
            }
        }

        public IRepository<Actor> Actors
        {
            get
            {
                if (actorsRepository == null)
                    actorsRepository = new ApplicationRepository<Actor>(db);
                return actorsRepository;
            }
        }

        public IRepository<Genre> Genres
        {
            get
            {
                if (genresRepository == null)
                    genresRepository = new ApplicationRepository<Genre>(db);
                return genresRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
