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
        IOrderedEnumerable<Movie> GetMoviesList(string searchString = "",
            string filterBy = "Title", string orderBy = "asc");

        Movie GetMovie(int? id);

        void Dispose();
    }
}
