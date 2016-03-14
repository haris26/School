using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Database.Delta
{
    class SymbolControl : ValidationAttribute
    {
        
        Regex pattern = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
            {
                return new ValidationResult("This field is required.");
            }

            if ( pattern.IsMatch(value.ToString()))
            {
                return new ValidationResult("Using symbols is not allowed.");
            }


            return ValidationResult.Success;
        }
        
        
    }
    
}
