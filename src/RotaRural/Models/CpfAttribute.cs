using System.ComponentModel.DataAnnotations;

namespace RotaRural.Models;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class CpfAttribute : ValidationAttribute
{
    public CpfAttribute() : base("CPF inválido.")
    {
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null || string.IsNullOrWhiteSpace(value.ToString()))
        {
            return ValidationResult.Success;
        }

        return CpfHelper.Validar(value.ToString())
            ? ValidationResult.Success
            : new ValidationResult(ErrorMessage);
    }
}
