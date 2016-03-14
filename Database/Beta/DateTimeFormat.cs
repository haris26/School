using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Beta
{
    public class DateTimeFormat:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
            {
                return new ValidationResult("Please choose date.");
            }
            return ValidationResult.Success;
        }
    }
}
