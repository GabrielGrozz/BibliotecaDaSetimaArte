using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaDaSetimaArte.Validations
{
    public class FirstLetterAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null || string.IsNullOrEmpty(value.ToString()))
            {
                 return ValidationResult.Success;
            }

            var FirstLetter = value.ToString()[0].ToString();
            if(FirstLetter != FirstLetter.ToUpper())
            {
                return new ValidationResult("A primeira letra deve ser maiuscula");
            }

            return ValidationResult.Success;
        }

    }
}
