using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieWebsite.Models
{
    public class MovieListViewModel
    {
        public string SortParam { get; set; }

        public string SearchBy { get; set; }

        public virtual IPagedList<MovieListItemModel> Movies { get; set; }
    }
}