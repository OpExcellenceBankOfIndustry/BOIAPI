using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserManagement.Command.UserDetails
{
    public class UserDetailValidators : AbstractValidator<UserDetailCommand>
    {
        public UserDetailValidators()
        {
           
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.BusinessName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} cannot be null.");

        }
    }
}
