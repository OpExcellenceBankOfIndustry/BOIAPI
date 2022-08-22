using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using FluentValidation;

namespace BOI.BOIApplications.Application.Features.API.Influence.FEPs.Queries.GetFEPsByBVN
{
    internal class GetFEPsByBVNValidator : AbstractValidator<GetFepsByBvnQuery>
    {
        private readonly IFEPRepository _fEPRepository;

        public GetFEPsByBVNValidator(IFEPRepository fEPRepository)
        {
            _fEPRepository = fEPRepository;

            RuleFor(e => e.FepBvn)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .Length(11).WithMessage("{PropertyName} must be 11 digits.");

            RuleFor(e => e)
            .MustAsync(DoesFEPRecordExist)
            .WithMessage("Financially Exposed Person does not exists based on BVN supplied.");
        }

        private async Task<bool> DoesFEPRecordExist(GetFepsByBvnQuery e, CancellationToken token)
        {
            return await _fEPRepository.DoesFEPExist(e.FepBvn);
        }
    }
}
