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

        public IOrderedEnumerable<Movie> GetMoviesList( string searchString = "",
            string filterBy = "Title", string orderBy = "asc")
        {
            IEnumerable<Movie> movies = Database.Movies.Get();
            
            switch (filterBy ?? "Title")
            {
                case "Title":
                    movies = movies.Where(
                        m => m.Title.Contains(searchString ?? ""));
                    break;
                case "Genres":
                    movies = movies.Where(
                        m => m.Genres.Where(
                            g => g.Name.Contains(searchString ?? "")).Any());
                    break;
                case "Actors":
                    movies = movies.Where(
                        m => m.Actors.Where(
                            a => (a.FirstName + " " + a.LastName).Contains(searchString ?? "")).Any());
                    break;
                default:
                    break;
            }
            
            switch(orderBy ?? "asc")
            {
                case "desc":
                    return movies.OrderByDescending(m => m.Title);
                case "asc":
                default:
                    return movies.OrderBy(m => m.Title);
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
