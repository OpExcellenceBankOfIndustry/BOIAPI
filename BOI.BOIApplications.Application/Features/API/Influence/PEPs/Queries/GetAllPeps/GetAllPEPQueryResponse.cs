using BOI.BOIApplications.Application.Responses;

namespace BOI.BOIApplications.Application.Features.API.Influence.PEPs.Queries.GetAllPeps
{
    public class GetAllPEPQueryResponse : BaseResponse
    {
        public GetAllPEPQueryResponse() : base()
        {

        }

        public List<GetAllPEPQueryViewModel> AllPEPs { get; set; }
    }
}
