using BOI.BOIApplications.Application.Contracts.Persistence.GeoInformation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.GeoInformation.City.Queries.GetCitiesByLGA
{
    public class GetCitiesByLGAQueryValidator : AbstractValidator<GetCitiesByLGAQuery>
    {
        private readonly ICityRepository _cityRepository;

        public GetCitiesByLGAQueryValidator(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
            RuleFor(p => p.LGAId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.");

            //RuleFor(e => e)
            //    .MustAsync(DoesCityExist)
            //    .WithMessage("Country does not exist for the specified id.");
        }
    }
}
