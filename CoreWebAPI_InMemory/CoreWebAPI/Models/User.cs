using CoreWebAPI.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [FirstLetterUpperCase]
        [Required]
        public string FirstName { get; set; }

        [FirstLetterUpperCase]
        [Required]
        public string LastName { get; set; }

        [Range(minimum:18, maximum:75)]
        [Required]
        public int Age { get; set; }

        [EmailAddress]
        [Required]
        public string EmailId { get; set; }

        public string Address { get; set; }
    }
}
