using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.CompanyInform
{
    public class CompanyInformValidators : AbstractValidator<CompanyInformCommand>
    {
        public CompanyInformValidators()
        {
            RuleFor(p => p.CompanyName)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.UserEmail)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} cannot be null.");
            RuleFor(p => p.EmailAddress)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull().WithMessage("{PropertyName} cannot be null.");
            RuleFor(p => p.PhoneNumber)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull().WithMessage("{PropertyName} cannot be null.");
        }
    }
}
