using MovieWebsite.Domain;
using MovieWebsite.Domain.Entities;
using MovieWebsite.Domain.Interfaces;
using MovieWebsite.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieWebsite.Service
{
    public class MoviesService : IMoviesService
    {
        IUnitOfWork Database;

        public MoviesService(IUnitOfWork database)
        {
            Database = database;
        }

        public IEnumerable<Movie> GetMoviesList(
            Expression<Func<Movie, bool>> filter = null,
            Func<IQueryable<Movie>, IOrderedQueryable<Movie>> orderBy = null)
        {
            IQueryable<Movie> query = Database.Movies.Get().AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public Movie GetMovie(int? id)
        {
            if(id == null)
            {
                throw new Exception("Movie ID is not set");
            }
            else
            {
                return Database.Movies.GetByID(id.Value);
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
