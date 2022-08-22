using BOI.BOIApplications.Application.Responses;

namespace BOI.BOIApplications.Application.Features.API.Influence.PEPs.Comamnd.AddPEPs
{
    public class AddPEPCommandResponse : BaseResponse
    {
        public AddPEPCommandResponse() : base()
        {

        }

        public AddPEPCommandViewModel AddPEPCommandViewModel { get; set; }
    }
}
