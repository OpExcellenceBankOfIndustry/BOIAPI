namespace BOI.BOIApplications.Application.Model.Mail
{
    public class EmailAttachmentRequest
    {
        public byte[]? Attachment { get; set; }
        public string? ContentType { get; set; }
        public string? FileName { get; set; }
    }
}
