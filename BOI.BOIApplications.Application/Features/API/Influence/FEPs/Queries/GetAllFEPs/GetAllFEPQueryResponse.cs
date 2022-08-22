using BOI.BOIApplications.Application.Features.API.Influence.FEPs.Queries.GetAllFEPs;
using BOI.BOIApplications.Application.Responses;

namespace BOI.BOIApplications.Application.Features.API.Influence.FEPs.Queries
{
    public class GetAllFEPQueryResponse : BaseResponse
    {
        public GetAllFEPQueryResponse() : base()
        {

        }

        public List<GetAllFEPQueryViewModel> FEPQueryViewModel { get; set; }
    }
}
