﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HttpClientDemo.Models
{

    public class UserInfo
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Passowrd { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
