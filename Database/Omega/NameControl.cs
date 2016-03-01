using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Omega
{
<<<<<<< HEAD
    public class NameControl:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
            {
                return new ValidationResult("Please enter name of the team");
            }
            if (value.ToString().Contains("@"))
            {
                return new ValidationResult("Please do not enter your email");
            }
            return ValidationResult.Success;

=======
    public class NameControl: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value.ToString().Contains("@"))
            {
                return new ValidationResult("");
            }
            return ValidationResult.Success;
>>>>>>> 3362ff002d7c37b0137071d2af0f41ed31c55c95
        }
    }
}
