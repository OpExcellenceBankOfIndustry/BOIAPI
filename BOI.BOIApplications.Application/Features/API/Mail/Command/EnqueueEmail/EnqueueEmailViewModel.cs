namespace BOI.BOIApplications.Application.Features.API.Mail.Command.EnqueueEmail
{
    public class EnqueueEmailViewModel
    {
        public string Subject { get; set; }
        public string Sender { get; set; }
        public string ToRecipient { get; set; }
        public string CcRecipient { get; set; }
        public string BccRecipient { get; set; }
        public bool IsHtml { get; set; }
        public string Channel { get; set; }
        public bool HasAttachment { get; set; }

        public List<EnqueueEmailAttachmentsViewModel>? EmailAttachments { get; set; }
    }
}
