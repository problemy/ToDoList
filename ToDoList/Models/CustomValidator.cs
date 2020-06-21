
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public class CustomValidation
{
    public sealed class checkCategory : ValidationAttribute
    {
        public String AllowCategory { get; set; }
        protected override ValidationResult IsValid(object categoryName, ValidationContext validationContext)
        {
            string[] myarr = AllowCategory.ToString().Split(',');
            if (myarr.Contains(categoryName))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Please choose a valid category (Nieprzypisane, Frontend, Backend)");
            }
        }
    }


}


