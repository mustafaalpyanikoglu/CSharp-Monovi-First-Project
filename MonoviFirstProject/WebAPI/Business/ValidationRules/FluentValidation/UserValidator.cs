using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("Adınızı boş geçemezsiniz.");
            RuleFor(u => u.FirstName).MinimumLength(2).WithMessage("Adınız minimum 2 karakter içermeli.");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Soyadınızı boş geçemezsiniz.");
            RuleFor(u => u.LastName).MinimumLength(2).WithMessage("Soyadınız minimum 2 karakter içermeli.");
            RuleFor(u => u.Email).NotEmpty().WithMessage("Emailinizi boş geçemezsiniz.");
        }
    }
}
