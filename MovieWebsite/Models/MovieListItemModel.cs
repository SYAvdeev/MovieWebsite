using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieWebsite.Models
{
    public class MovieListItemModel
    {
        public int ID { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name ="List of Actors")]
        public virtual ICollection<ActorViewModel> Actors { get; set; }

        [Display(Name = "Genres")]
        public virtual ICollection<GenreViewModel> Genres { get; set; }

        public string Description { get; set; }
    }
}