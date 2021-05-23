using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace JWTAuthentication.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

    }
}
