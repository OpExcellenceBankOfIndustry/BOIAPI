using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.AccountDetailsOfOwner
{
    public class AccountDetailsOfOwnerValidators : AbstractValidator<AccountDetailsOfOwnerViewModel>
    {
        public AccountDetailsOfOwnerValidators()
        {
            RuleFor(p => p.AccountName)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.AccountNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} cannot be null.");
            RuleFor(p => p.BankName)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull().WithMessage("{PropertyName} cannot be null.");
            RuleFor(p => p.UserEmail)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull().WithMessage("{PropertyName} cannot be null.");
        }
    }
}
