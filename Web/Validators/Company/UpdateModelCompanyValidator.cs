using FluentValidation;
using Web.Models.Company;

namespace Web.Validators.Company
{
    public class UpdateModelCompanyValidator : AbstractValidator<UpdateCompanyModel>
    {
        public UpdateModelCompanyValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .MaximumLength(120);
        }
    }
}
