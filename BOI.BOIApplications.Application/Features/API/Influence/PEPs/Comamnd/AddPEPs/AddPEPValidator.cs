using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using FluentValidation;

namespace BOI.BOIApplications.Application.Features.API.Influence.PEPs.Comamnd.AddPEPs
{
    internal class AddPEPValidator : AbstractValidator<AddPEPCommand>
    {
        private readonly IPEPRepository _pEPRepository;

        public AddPEPValidator(IPEPRepository pEPRepository)
        {
            _pEPRepository = pEPRepository;
            RuleFor(p => p.FirstName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.PepBvn)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .Length(11).WithMessage("{PropertyName} must be 11 digits.");

            RuleFor(p => p.LastName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.FullName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.OtherNames)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.PastPoliticalParty)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.PastPoliticalPosition)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.CurrentPoliticalParty)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.CurrentPoliticalPosition)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.PastPoliticalParty)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(e => e)
            .MustAsync(DoesPEPRecordExist)
            .WithMessage("Financially Exposed Person Already exists.");
        }

        private async Task<bool> DoesPEPRecordExist(AddPEPCommand e, CancellationToken token)
        {
            return !(await _pEPRepository.DoesPEPExist(e.PepBvn));
        }
    }
}
