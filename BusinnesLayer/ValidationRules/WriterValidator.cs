using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>//yazar doğrulama
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("The Author's name cannot be empty.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("The Author's email cannot be empty.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("The Author's password cannot be empty.");
            RuleFor(x => x.WriterName).MaximumLength(2).WithMessage("Please enter at least two characters.");
            RuleFor(x => x.WriterName).MinimumLength(50).WithMessage("Please enter a maximum of fifty characters.");
        }
    }
}
