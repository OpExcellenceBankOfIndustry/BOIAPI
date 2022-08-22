using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using BOI.BOIApplications.Application.Exceptions;
using BOI.BOIApplications.Domain.Entities;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Influence.IndividualWatchLists.Command.AddIndividualWatchList
{
    public class AddIndividualWatchListCommandHandler : IRequestHandler<AddIndividualWatchListCommand, AddIndividualWatchListCommandResponse>
    {
        private readonly IIndividualWatchListRepository _individualWatchListRepository;
        private readonly IMapper _mapper;

        public AddIndividualWatchListCommandHandler(IIndividualWatchListRepository individualWatchListRepository, IMapper mapper)
        {
            _individualWatchListRepository = individualWatchListRepository;
            _mapper = mapper;
        }
        public async Task<AddIndividualWatchListCommandResponse> Handle(AddIndividualWatchListCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddIndividualWatchListValidator(_individualWatchListRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);

            var individual = await _individualWatchListRepository.AddAsync(_mapper.Map<IndividualWatchList>(request));

            return new AddIndividualWatchListCommandResponse
            {
                Message = "New individual added to Individual watchlist",
                Success = true,
                AddIndividualWatchListViewModel = _mapper.Map<AddIndividualWatchListViewModel>(individual),
            };
        }
    }
}
