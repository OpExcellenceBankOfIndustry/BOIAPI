using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.RegulatoryInform
{
    public class RegulatoryInformValidators : AbstractValidator<RegulatoryInformCommand>
    {
        public RegulatoryInformValidators()
        {
            RuleFor(p => p.UserEmail)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            //RuleFor(p => p.CompanyRegistrationNumber)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.SCUMLNumber)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.TIN)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull().WithMessage("{PropertyName} cannot be null.");
        }
    }
}
