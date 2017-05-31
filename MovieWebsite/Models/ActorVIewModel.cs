using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieWebsite.Models
{
    public class ActorViewModel
    {
        [Display(Name = "Name")]
        public string FullName { get; set; }
    }
}