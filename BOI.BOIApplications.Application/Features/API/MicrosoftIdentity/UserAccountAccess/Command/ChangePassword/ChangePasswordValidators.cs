using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Command.ChangePassword
{
    public class ChangePasswordValidators : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordValidators()
        {
            RuleFor(p => p.Email)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull().WithMessage("{PropertyName} cannot be null.");

        }
    }
}
