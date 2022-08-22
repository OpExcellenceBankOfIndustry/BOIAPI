using BOI.BOIApplications.Application.Contracts.Persistence.GeoInformation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.GeoInformation.States.Queries.GetStatesByCountry
{
    public class GetStatesByCountryQueryValidator : AbstractValidator<GetStatesByCountryQuery>
    {
        private readonly ICountryRepository _countryRepository;

        public GetStatesByCountryQueryValidator(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
            RuleFor(p => p.CountryId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.");

            RuleFor(e => e)
                .MustAsync(DoesCountryExist)
                .WithMessage("Country does not exist for the specified id.");
        }

        private async Task<bool> DoesCountryExist(GetStatesByCountryQuery e, CancellationToken token)
        {
            return await _countryRepository.DoesCountryExist(e.CountryId);
        }
    }
}
