using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Influence.CorporateWatchLists.Queries.GetCorporateWatchListByCompanyReg
{
    internal class GetCorporateWatchListByCompanyRegQueryHandler
        : IRequestHandler<GetCorporateWatchListByCompanyRegQuery, GetCorporateWatchListByCompanyRegQueryResponse>
    {
        private readonly ICorporateWatchListRepository _iCorporateWatchListRepository;
        private readonly IMapper _mapper;

        public GetCorporateWatchListByCompanyRegQueryHandler(ICorporateWatchListRepository iCorporateWatchListRepository, IMapper mapper)
        {
            _iCorporateWatchListRepository = iCorporateWatchListRepository;
            _mapper = mapper;
        }

        public async Task<GetCorporateWatchListByCompanyRegQueryResponse> Handle(GetCorporateWatchListByCompanyRegQuery request, 
            CancellationToken cancellationToken)
        {
            var validator = new GetCorporateWatchListByCompanyRegValidator(_iCorporateWatchListRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);

            var corporateWatchListByCompanyReg = await _iCorporateWatchListRepository.
                                                        GetCompanyByRegistrationNumber(request.CompanyRegistrationNumber);

            return new GetCorporateWatchListByCompanyRegQueryResponse
            {
                Message = "Successful",
                Success = true,
                GetCorporateWatchListByCompanyRegQueryViewModel = _mapper.Map<GetCorporateWatchListByCompanyRegQueryViewModel>
                                                                                                    (corporateWatchListByCompanyReg)
            };

        }
    }
}
