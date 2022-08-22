using BOI.BOIApplications.Application.Responses;

namespace BOI.BOIApplications.Application.Features.API.Mail.Command.EnqueueEmail
{
    public class EnqueueEmailCommandResponse : BaseResponse
    {
        public EnqueueEmailCommandResponse() : base()
        {

        }

        public EnqueueEmailViewModel EnqueueEmailViewModel { get; set; }
    }
}
