namespace BOI.BOIApplications.Domain.Entities
{
    public class EmailAttachment
    {
        public int EmailAttachmentId { get; set; }
        public byte[]? Attachment { get; set; }
        public string? ContentType { get; set; }
        public string? FileName { get; set; }
    }
}
