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
            if (yearToValidate >= 1900 && yearToValidate <= currentYear )
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(GetErrorMessage());
            }
        }
        else if (value is null)
        {
            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult("Invalid data type");
        }
    }

    private string GetErrorMessage()
    {
        return $"The year must be between 1900 and {DateTime.Now.Year}.";
    }
}