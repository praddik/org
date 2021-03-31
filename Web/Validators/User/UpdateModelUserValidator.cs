using FluentValidation;
using Web.Models.User;

namespace Web.Validators.User
{
    public class UpdateModelUserValidator : AbstractValidator<UpdateUserModel>
    {
        public UpdateModelUserValidator()
        {
            RuleFor(m => m.Email)
                .NotEmpty().MaximumLength(120).EmailAddress();
            RuleFor(m => m.FirstName)
                .NotEmpty().MaximumLength(32);
            RuleFor(m => m.LastName)
                .NotEmpty().MaximumLength(32);
            RuleFor(m => m.Phone)
                .NotEmpty()
                .MaximumLength(12)
                .WithMessage("Please input your phone format lilke '380xxxxxxxxx' ");
        }
    }
}
