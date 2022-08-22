using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.OwnershipInformCoop
{
    public class OwnershipInformCoopValidators : AbstractValidator<OwnershipInformCoopCommand>
    {
        public OwnershipInformCoopValidators()
        {
            RuleFor(p => p.RegistrationNumber)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.RefNumber)
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
