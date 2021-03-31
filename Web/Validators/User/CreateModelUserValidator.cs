using FluentValidation;
using Web.Models.User;

namespace Web.Validators.User
{
    public class CreateModelUserValidator : AbstractValidator<CreateUserModel>
    {
        public CreateModelUserValidator()
        {
            RuleFor(m => m.Email)
                .NotEmpty()
                .MaximumLength(120)
                .EmailAddress()
                .Must(IsEmailUnique).WithMessage("'{PropertyName}' must be unique.");
            RuleFor(m => m.Phone)
                .NotEmpty()
                .MaximumLength(12);
            RuleFor(m => m.Password)
                .NotEmpty()
                .MinimumLength(7);
            RuleFor(model => model.PasswordConfirmation)
                .NotEmpty()
                .Equal(model => model.Password)
                .WithMessage("{PropertyName} does not match Password.");
            RuleFor(m => m.FirstName)
                .NotEmpty()
                .MinimumLength(3)
                .MinimumLength(32);
            RuleFor(m => m.LastName)
                .NotEmpty()
                .MinimumLength(3)
                .MinimumLength(32);
        }

        public bool IsEmailUnique(string email) => true;
    }
}
