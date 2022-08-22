using BOI.BOIApplications.Application.Contracts.Persistence.GeoInformation;
using FluentValidation;

namespace BOI.BOIApplications.Application.Features.API.GeoInformation.LGAs.Queries.GetAllLGAsByState
{
    public class GetAllLGAsByStateValidator : AbstractValidator<GetAllLGAsByStateQuery>
    {
        private readonly IStateRepository _stateRepository;

        public GetAllLGAsByStateValidator(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
            RuleFor(p => p.StateId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.");

            RuleFor(e => e)
                .MustAsync(DoesStateExist)
                .WithMessage("Country does not exist for the specified id.");
        }

        private async Task<bool> DoesStateExist(GetAllLGAsByStateQuery e, CancellationToken token)
        {
            return await _stateRepository.DoesStateExist(e.StateId);
        }
    }
}
