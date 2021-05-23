using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAppAPI.Validations
{
    public class ValidateImageSize:ValidationAttribute
    {
        int fileSize { get; set; }

        public ValidateImageSize(int Size)
        {
            fileSize = Size;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IFormFile file;

            if(value != null)
            {
                file = value as IFormFile;
                if (file.Length > fileSize * 1024 * 1024)
                {
                    return new ValidationResult($"File size should be less than or equal to {fileSize}");
                }                
            }
            return ValidationResult.Success; 
        }

    }
}
