using BOI.BOIApplications.Application.Responses;

namespace BOI.BOIApplications.Application.Features.API.Influence.FEPs.Queries.GetFEPsByBVN
{
    public class GetFEPsByBVNQueryResponse : BaseResponse
    {
        public GetFEPsByBVNQueryResponse() : base()
        {

        }

        public GetFEPsByBVNQueryViewModel GetFEPsByBVNQueryViewModel { get; set; }
    }
}
