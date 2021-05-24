using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPI.Models
{
    public class Genre
    {
        public int Id{ get; set; }
        [Required(ErrorMessage ="Name field required.")]
        public string Name { get; set; }
    }
}
