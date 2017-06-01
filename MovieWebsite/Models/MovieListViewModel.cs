using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieWebsite.Models
{
    public class MovieListViewModel
    {
        public string OrderBy { get; set; }
        public string FilterBy { get; set; }
        public string SearchString { get; set; }

        public virtual IPagedList<MovieListItemModel> Movies { get; set; }
    }
}