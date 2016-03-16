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
<<<<<<< HEAD

=======
>>>>>>> 5700b91658f31bf84a31f2235250c7fb4c1d5b58
            if (value == null)
            {
                return new ValidationResult("Pliz pliz enter name");
            }
            if (value.ToString().Contains("@"))
            {
                return new ValidationResult("Pliz pliz don't enter email");
            }
            return ValidationResult.Success;
        }
    }
}
