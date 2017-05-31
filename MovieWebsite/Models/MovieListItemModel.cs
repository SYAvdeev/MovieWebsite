using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieWebsite.Models
{
    public class MovieListItemModel
    {
        [Display(Name = "Title")]
        public string Title { get; set; }

        public virtual ICollection<ActorViewModel> Actors { get; set; }
        public virtual ICollection<GenreViewModel> Genres { get; set; }
    }
}