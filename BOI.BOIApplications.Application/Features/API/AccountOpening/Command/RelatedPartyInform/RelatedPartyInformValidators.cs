using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.AccountOpening.Command.RelatedPartyInform
{
    public class RelatedPartyInformValidators : AbstractValidator<RelatedPartyInformCommand>
    {
        public RelatedPartyInformValidators()
        {
            RuleFor(p => p.UserEmail)
           .NotEmpty().WithMessage("{PropertyName} is required.")
           .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.RefNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.HowDoYouKnowAboutBOI)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull().WithMessage("{PropertyName} cannot be null.");

        }
    }
}
