namespace BOI.BOIApplications.Domain.Entities
{
    public class Email
    {
		public int EmailId { get; set; }
		public string? Subject { get; set; }
		public string? Sender { get; set; }
		public string? ToRecipient { get; set; }
		public string? CcRecipient { get; set; }
		public string? BccRecipient { get; set; }
		public string? Message { get; set; }
		public bool IsHtml { get; set; }
		public string? Channel { get; set; }
		public DateTimeOffset? DateLogged { get; set; }
		public string? Response { get; set; }
		public DateTimeOffset? ResponseTime { get; set; }
		public bool Sent { get; set; }
		public bool HasAttachment { get; set; }
		public bool HasAlternateView { get; set; }
		public DateTimeOffset? SendDate { get; set; }
		public bool SendAndReply { get; set; }

		public ICollection<EmailAttachment>? EmailAttachments { get; set; }
	}
}
