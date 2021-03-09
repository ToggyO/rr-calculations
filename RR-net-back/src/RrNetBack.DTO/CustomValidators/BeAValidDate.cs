using System;
using FluentValidation.Validators;

namespace RrNetBack.DTO.CustomValidators
{
    public class BeAValidDate : PropertyValidator
    {
        protected override bool IsValid(PropertyValidatorContext context)
        {
            var date = context.PropertyValue;
            return !date.Equals(default(DateTime));
        }
        
        protected override string GetDefaultMessageTemplate() => "Value must be a valid date";
    }
}