using FluentValidation;
using RrNetBack.Common.Errors;
using RrNetBack.Domain.Models.Users;
using RrNetBack.DTO.Extensions;

namespace RrNetBack.DTO.Users.Validators
{
    public class CreateUserDTOValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserDTOValidator()
        {
            RuleFor(x => x.RegistartionDate)
                .NotEmpty().MustBeAValidDate().WithErrorCode(ErrorCodes.Common.FieldInvalid);
            RuleFor(x => x.LastActivityDate)
                .NotEmpty().MustBeAValidDate().WithErrorCode(ErrorCodes.Common.FieldInvalid);
        }
    }
}