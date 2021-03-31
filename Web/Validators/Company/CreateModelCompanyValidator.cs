using FluentValidation;
using Web.Models.Company;

namespace Web.Validators.Company
{
    public class CreateModelCompanyValidator : AbstractValidator<CreateCompanyModel>
    {
        public CreateModelCompanyValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .MaximumLength(120);
        }
    }
}
