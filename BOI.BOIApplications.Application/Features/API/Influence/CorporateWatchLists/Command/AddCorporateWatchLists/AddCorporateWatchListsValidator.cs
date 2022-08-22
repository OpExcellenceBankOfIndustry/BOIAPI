using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using FluentValidation;

namespace BOI.BOIApplications.Application.Features.API.Influence.CorporateWatchLists.Command.AddCorporateWatchLists
{
    public class AddCorporateWatchListsValidator : AbstractValidator<AddCorporateWatchListsCommand>
    {
        private readonly ICorporateWatchListRepository _iCorporateWatchListRepository;

        public AddCorporateWatchListsValidator(ICorporateWatchListRepository iCorporateWatchListRepository)
        {
            _iCorporateWatchListRepository = iCorporateWatchListRepository;

            RuleFor(p => p.CompanyName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.CompanyRegistrationNumber)
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
            .MustAsync(DoesCompanyRecordExist)
            .WithMessage("Company Already exists.");
        }

        private async Task<bool> DoesCompanyRecordExist(AddCorporateWatchListsCommand e, CancellationToken token)
        {
            return !(await _iCorporateWatchListRepository.DoesCompanyExist(e.CompanyRegistrationNumber));
        }
    }
}
