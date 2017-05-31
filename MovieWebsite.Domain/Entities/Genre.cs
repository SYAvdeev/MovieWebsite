using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWebsite.Domain.Entities
{
    public class Genre
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }
    }
}
