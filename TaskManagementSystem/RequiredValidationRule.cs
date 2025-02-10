using System.Globalization;
using System.Windows.Controls;

public class RequiredValidationRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        return string.IsNullOrWhiteSpace(value as string)
            ? new ValidationResult(false, "Description is required.")
            : ValidationResult.ValidResult;
    }
}