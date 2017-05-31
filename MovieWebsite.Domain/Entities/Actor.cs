
using System.ComponentModel.DataAnnotations;

namespace MovieWebsite.Domain.Entities
{
    public class Actor
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }
    }
}
