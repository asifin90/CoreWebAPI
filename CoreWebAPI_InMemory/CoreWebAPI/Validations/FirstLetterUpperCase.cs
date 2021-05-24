using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPI.Validations
{
    public class FirstLetterUpperCase : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value.ToString() == "" || string.IsNullOrEmpty(Convert.ToString(value)))
            {
                return ValidationResult.Success;
            }

            var firstLetter = value.ToString()[0].ToString(); 

            if(firstLetter == firstLetter.ToUpper())
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("First letter should be upper case.");
        }
    }
}
