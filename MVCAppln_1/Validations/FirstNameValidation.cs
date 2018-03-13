using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAppln_1.Validations
{
    public class FirstNameValidation : ValidationAttribute
    {
         protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Pls provide First Name");
            }
            else
            {
                if (value.ToString().Contains("@"))
                {
                    return new ValidationResult("Can't contain @ in name");
                }
            }
            return ValidationResult.Success;
        }
    }
}