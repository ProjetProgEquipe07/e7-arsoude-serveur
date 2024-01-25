using System;
using System.ComponentModel.DataAnnotations;

public class YearRangeAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is int)
        {
            int yearToValidate = (int)value;
            int currentYear = DateTime.Now.Year;
            if (yearToValidate >= currentYear - 100 && yearToValidate <= currentYear)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(GetErrorMessage());
            }
        }
        else
        {
            return new ValidationResult("Invalid data type");
        }
    }

    private string GetErrorMessage()
    {
        return $"The year must be between {DateTime.Now.Year - 100} and {DateTime.Now.Year}.";
    }
}