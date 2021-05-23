using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthentication.Models
{
    public class UserInfo
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Passowrd { get; set; }
    }
}
