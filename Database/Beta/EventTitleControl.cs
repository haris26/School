using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Beta
{
    public class EventTitleControl : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
            {
                return new ValidationResult(ErrorMessage = "Please enter event title.");
            }
            return ValidationResult.Success;
        }
    }
}
