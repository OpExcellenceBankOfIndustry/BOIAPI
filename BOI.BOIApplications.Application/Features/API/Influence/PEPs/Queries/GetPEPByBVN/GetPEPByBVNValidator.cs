using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using FluentValidation;

namespace BOI.BOIApplications.Application.Features.API.Influence.PEPs.Queries.GetPEPByBVN
{
    public class GetPEPByBVNValidator : AbstractValidator<GetPEPByBVNQuery>
    {
        private readonly IPEPRepository _pEPRepository;

        public GetPEPByBVNValidator(IPEPRepository pEPRepository)
        {
            _pEPRepository = pEPRepository;

            RuleFor(e => e.PepBvn)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .Length(11).WithMessage("{PropertyName} must be 11 digits.");

            RuleFor(e => e)
            .MustAsync(DoesPEPRecordExist)
            .WithMessage("Politically Exposed Person does not exists based on BVN supplied.");
        }

        private async Task<bool> DoesPEPRecordExist(GetPEPByBVNQuery e, CancellationToken token)
        {
            return await _pEPRepository.DoesPEPExist(e.PepBvn);
        }
    }
}
