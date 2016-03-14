using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Delta
{
    class NameControl : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if(value == null)
            {
                return new ValidationResult("This field is required");
            }

            if(value.ToString().Contains("@"))
            {
                return new ValidationResult("This is not an email field.");
            }

           
            return ValidationResult.Success;
        }
    }
}
