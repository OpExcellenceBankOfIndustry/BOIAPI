using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using FluentValidation;

namespace BOI.BOIApplications.Application.Features.API.Influence.CorporateWatchLists.Queries.GetCorporateWatchListByCompanyReg
{
    public class GetCorporateWatchListByCompanyRegValidator : AbstractValidator<GetCorporateWatchListByCompanyRegQuery>
    {
        private readonly ICorporateWatchListRepository _iCorporateWatchListRepository;

        public GetCorporateWatchListByCompanyRegValidator(ICorporateWatchListRepository iCorporateWatchListRepository)
        {
            _iCorporateWatchListRepository = iCorporateWatchListRepository;
            RuleFor(e => e.CompanyRegistrationNumber)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(e => e)
            .MustAsync(DoesCompanyRecordExist)
            .WithMessage("Financially Exposed Person does not exists based on BVN supplied.");

        }

        private async Task<bool> DoesCompanyRecordExist(GetCorporateWatchListByCompanyRegQuery e, CancellationToken token)
        {
            return await _iCorporateWatchListRepository.DoesCompanyExist(e.CompanyRegistrationNumber);
        }
    }
}
