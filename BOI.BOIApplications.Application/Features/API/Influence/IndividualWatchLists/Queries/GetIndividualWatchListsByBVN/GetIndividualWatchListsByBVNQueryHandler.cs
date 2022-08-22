using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Influence.IndividualWatchLists.Queries.GetIndividualWatchListsByBVN
{
    public class GetIndividualWatchListsByBVNQueryHandler : IRequestHandler<GetIndividualWatchListsByBVNQuery, GetIndividualWatchListsByBVNResponse>
    {
        private readonly IIndividualWatchListRepository _individualWatchListRepository;
        private readonly IMapper _mapper;

        public GetIndividualWatchListsByBVNQueryHandler(IIndividualWatchListRepository individualWatchListRepository, IMapper mapper)
        {
            _individualWatchListRepository = individualWatchListRepository;
            _mapper = mapper;
        }

        public async Task<GetIndividualWatchListsByBVNResponse> Handle(GetIndividualWatchListsByBVNQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetIndividualWatchListsByBVNValidator(_individualWatchListRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);

            var individual = await _individualWatchListRepository.GetIndividualByBvn(request.IndividualBvn);

            return new GetIndividualWatchListsByBVNResponse
            {
                Message = "Successful",
                Success = true,
                GetIndividualWatchListsByBVNViewModel = _mapper.Map<GetIndividualWatchListsByBVNViewModel>
                                                                                        (individual)
            };
        }
    }
}
