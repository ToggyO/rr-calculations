using FluentValidation;
using RrNetBack.DTO.CustomValidators;

namespace RrNetBack.DTO.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> MustBeAValidDate<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new BeAValidDate());
        }
    }
}