using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Beta
{
    
        public class StatusControl : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext context)
            {
                if (value.ToString().Equals("0"))
                {
                    return new ValidationResult("Please choose status");
                }
                return ValidationResult.Success;
            }
        }
}
