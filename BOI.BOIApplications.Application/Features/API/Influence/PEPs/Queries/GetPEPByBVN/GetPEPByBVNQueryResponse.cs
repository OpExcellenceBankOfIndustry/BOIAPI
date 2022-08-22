using BOI.BOIApplications.Application.Responses;

namespace BOI.BOIApplications.Application.Features.API.Influence.PEPs.Queries.GetPEPByBVN
{
    public class GetPEPByBVNQueryResponse : BaseResponse
    {
        public GetPEPByBVNQueryResponse() : base()
        {

        }

        public GetPEPByBVNQueryViewModel GetPEPByBVNQueryViewModel { get; set; }
    }
}
