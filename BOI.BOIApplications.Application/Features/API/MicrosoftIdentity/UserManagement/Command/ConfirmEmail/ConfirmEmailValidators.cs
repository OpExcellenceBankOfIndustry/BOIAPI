using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserManagement.Command.ConfirmEmail
{
    public class ConfirmEmailValidators : AbstractValidator<ConfirmEmailCommand>
    {
    
        public ConfirmEmailValidators()
        {

            RuleFor(p => p.email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} cannot be null.");
        }
    }
}
