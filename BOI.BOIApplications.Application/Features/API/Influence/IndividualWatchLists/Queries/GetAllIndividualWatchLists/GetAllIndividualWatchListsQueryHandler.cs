using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Influence.IndividualWatchLists.Queries.GetAllIndividualWatchLists
{
    public class GetAllIndividualWatchListsQueryHandler : IRequestHandler<GetAllIndividualWatchListsQuery, GetAllIndividualWatchListsQueryResponse>
    {
        private readonly IIndividualWatchListRepository _individualWatchListRepository;
        private readonly IMapper _mapper;

        public GetAllIndividualWatchListsQueryHandler(IIndividualWatchListRepository individualWatchListRepository, IMapper mapper)
        {
            _individualWatchListRepository = individualWatchListRepository;
            _mapper = mapper;
        }

        public async Task<GetAllIndividualWatchListsQueryResponse> Handle(GetAllIndividualWatchListsQuery request, CancellationToken cancellationToken)
        {
            var allIndividuals = await _individualWatchListRepository.ListAllAsync();
            return new GetAllIndividualWatchListsQueryResponse
            {
                Message = "Successful",
                Success = true,
                GetAllIndividualWatchListsViewModel = _mapper.Map<List<GetAllIndividualWatchListsViewModel>>(allIndividuals)
            };
        }
    }
}
