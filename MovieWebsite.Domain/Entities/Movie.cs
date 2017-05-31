using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieWebsite.Domain.Entities
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }

        [StringLength(200, MinimumLength = 1)]
        public string Title { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
    }
}
