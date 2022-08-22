using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using BOI.BOIApplications.Application.Exceptions;
using BOI.BOIApplications.Domain.Entities;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Influence.CorporateWatchLists.Command.AddCorporateWatchLists
{
    public class AddCorporateWatchListsCommandHandler : IRequestHandler<AddCorporateWatchListsCommand, AddCorporateWatchListsCommandResponse>
    {
        private readonly ICorporateWatchListRepository _iCorporateWatchListRepository;
        private readonly IMapper _mapper;

        public AddCorporateWatchListsCommandHandler(ICorporateWatchListRepository iCorporateWatchListRepository, IMapper mapper)
        {
            _iCorporateWatchListRepository = iCorporateWatchListRepository;
            _mapper = mapper;
        }

        public async Task<AddCorporateWatchListsCommandResponse> Handle(AddCorporateWatchListsCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddCorporateWatchListsValidator(_iCorporateWatchListRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);

            var insertCompany = await _iCorporateWatchListRepository.AddAsync(_mapper.Map<CorporateWatchList>(request));

            return new AddCorporateWatchListsCommandResponse
            {
                Message = "New Company added to Corporate watchlist",
                Success = true,
                AddCorporateWatchListsViewModel = _mapper.Map<AddCorporateWatchListsViewModel>(insertCompany),
            };
        }
    }
}
