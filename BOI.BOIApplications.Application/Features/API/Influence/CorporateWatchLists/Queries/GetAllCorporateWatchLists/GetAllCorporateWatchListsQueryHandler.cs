using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Influence.CorporateWatchLists.Queries.GetAllCorporateWatchLists
{
    public class GetAllCorporateWatchListsQueryHandler : IRequestHandler<GetAllCorporateWatchListsQuery, GetAllCorporateWatchListsQueryResponse>
    {
        private readonly ICorporateWatchListRepository _iCorporateWatchListRepository;
        private readonly IMapper _mapper;

        public GetAllCorporateWatchListsQueryHandler(ICorporateWatchListRepository iCorporateWatchListRepository, IMapper mapper)
        {
            _iCorporateWatchListRepository = iCorporateWatchListRepository;
            _mapper = mapper;
        }

        public async Task<GetAllCorporateWatchListsQueryResponse> Handle(GetAllCorporateWatchListsQuery request, CancellationToken cancellationToken)
        {
            var allCorporateWatchLists = await _iCorporateWatchListRepository.ListAllAsync();

            return new GetAllCorporateWatchListsQueryResponse
            {
                Message = "Successful",
                Success = true,
                GetAllCorporateWatchListsQueryViewModel = _mapper.Map<List<GetAllCorporateWatchListsQueryViewModel>>(allCorporateWatchLists),
            };
        }
    }
}
