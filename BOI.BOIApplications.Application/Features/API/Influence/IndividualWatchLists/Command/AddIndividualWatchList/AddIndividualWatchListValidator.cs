using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using FluentValidation;

namespace BOI.BOIApplications.Application.Features.API.Influence.IndividualWatchLists.Command.AddIndividualWatchList
{
    public class AddIndividualWatchListValidator : AbstractValidator<AddIndividualWatchListCommand>
    {
        private readonly IIndividualWatchListRepository _iIndividualWatchListRepository;

        public AddIndividualWatchListValidator(IIndividualWatchListRepository iIndividualWatchListRepository)
        {
            _iIndividualWatchListRepository = iIndividualWatchListRepository;

            RuleFor(p => p.IndividualBvn)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .Length(11).WithMessage("{PropertyName} must be 11 digits."); 

            RuleFor(p => p.FirstName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.LastName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.OtherNames)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.IndividualName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.Country)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.AdditionalInformation)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.Remarks)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.CreatedBy)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(e => e)
            .MustAsync(DoesIndividualRecordExist)
            .WithMessage("Individual Already profiled as watchlist.");
        }

        private async Task<bool> DoesIndividualRecordExist(AddIndividualWatchListCommand e, CancellationToken token)
        {
            return !(await _iIndividualWatchListRepository.DoesIndividualExist(e.IndividualBvn));
        }
    }
}
