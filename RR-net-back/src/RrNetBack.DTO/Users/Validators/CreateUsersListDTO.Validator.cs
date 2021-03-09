using FluentValidation;
using RrNetBack.Common.Errors;

namespace RrNetBack.DTO.Users.Validators
{
    public class CreateUsersListDTOValidator : AbstractValidator<CreateUsersListDTO>
    {
        public CreateUsersListDTOValidator()
        {
            RuleForEach(x => x.Users)
                .SetValidator(new CreateUserDTOValidator())
                .WithName("Users")
                .WithErrorCode(ErrorCodes.Common.FieldDuplicate);
        }
    }
}