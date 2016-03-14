using System;

using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class NameControl : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext  context)
        {
            if (value == null){
                return new ValidationResult("Pliz enter name");

            }
            if(value.ToString().Contains("@"))
            {
                return new ValidationResult("Please don't enter email");
            }
            return ValidationResult.Success;

        }
    }
}
