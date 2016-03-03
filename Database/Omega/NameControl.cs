using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Omega
{

    public class NameControl: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value.ToString().Contains("@"))
            {
                return new ValidationResult("");
            }
            return ValidationResult.Success;

        }
    }
}
