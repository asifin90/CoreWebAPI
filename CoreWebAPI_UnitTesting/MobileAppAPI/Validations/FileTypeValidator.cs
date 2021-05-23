using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAppAPI.Validations
{
    public class FileTypeValidator:ValidationAttribute
    {
        string[] _fileExtenssion;

        public FileTypeValidator(string[] fileExtenssion)
        {
            _fileExtenssion = fileExtenssion;
        }

        public FileTypeValidator(FileType type)
        {
            switch (type)
            {
                case FileType.Image:
                    _fileExtenssion = new string[] { "jpeg", "png" };
                    break;
                case FileType.Video:
                    break;
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                IFormFile file = value as IFormFile;
                if (_fileExtenssion.Contains(file.ContentType))
                {
                    return new ValidationResult("Extenssion of file not matching, make sure provide jpeg or png format.");
                }
            }
            return ValidationResult.Success;
        }

    }

    public enum FileType
    {
        Image,
        Video
    }
}
