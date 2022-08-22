using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Persistence.GeoInformation;
using BOI.BOIApplications.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.GeoInformation.LGAs.Queries.GetAllLGAs
{
    public class GetAllLGAsQueryHandler : IRequestHandler<GetAllLGAsQuery, GetAllLGAsQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILGARepository _lGARepository;

        public GetAllLGAsQueryHandler(IMapper mapper, ILGARepository lGARepository)
        {
            _mapper = mapper;
            _lGARepository = lGARepository;
        }

        public async Task<GetAllLGAsQueryResponse> Handle(GetAllLGAsQuery request, CancellationToken cancellationToken)
        {
            var lgaLists = await _lGARepository.ListAllAsync();
            if (lgaLists == null)
            {
                throw new NotFoundException("No lga lists available", "GetAllLGAs");
            }

            return new GetAllLGAsQueryResponse
            {
                AllLGAs = _mapper.Map<List<GetAllLGAsVM>>(lgaLists)
            };
        }
    }
}
