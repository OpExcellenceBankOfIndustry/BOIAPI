using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using FluentValidation;

namespace BOI.BOIApplications.Application.Features.API.Influence.IndividualWatchLists.Queries.GetIndividualWatchListsByBVN
{
    public class GetIndividualWatchListsByBVNValidator : AbstractValidator<GetIndividualWatchListsByBVNQuery>
    {
        private readonly IIndividualWatchListRepository _individualWatchListRepository;

        public GetIndividualWatchListsByBVNValidator(IIndividualWatchListRepository individualWatchListRepository)
        {
            _individualWatchListRepository = individualWatchListRepository;

            RuleFor(e => e.IndividualBvn)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .Length(11).WithMessage("{PropertyName} must be 11 digits.");

            RuleFor(e => e)
            .MustAsync(DoesIndividualRecordExist)
            .WithMessage("Individual is not on the watchlists does not exists based on BVN supplied.");

        }

        private async Task<bool> DoesIndividualRecordExist(GetIndividualWatchListsByBVNQuery e, CancellationToken token)
        {
            return await _individualWatchListRepository.DoesIndividualExist(e.IndividualBvn);
        }
    }
}
