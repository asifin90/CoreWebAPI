using Microsoft.AspNetCore.Http;
using MobileAppAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace MobileAppAPI.Models
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

        //[ValidateImageSize(Size:5)]
        //[FileTypeValidator(FileType.Image)]
        //public IFormFile Image { get; set; }
    }
}
