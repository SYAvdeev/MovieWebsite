using MovieWebsite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieWebsite.Service.Interfaces
{
    public interface IMoviesService
    {
        IEnumerable<Movie> GetMoviesList(
            Expression<Func<Movie, bool>> filter = null,
            Func<IQueryable<Movie>, IOrderedQueryable<Movie>> orderBy = null);

        Movie GetMovie(int? id);

        void Dispose();
    }
}
