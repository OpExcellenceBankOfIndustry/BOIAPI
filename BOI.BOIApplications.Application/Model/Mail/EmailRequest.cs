using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Model.Mail
{
    public class EmailRequest
    {
        public string? ToRecipient { get; set; }
        public string? CcRecipient { get; set; }
        public string? BccRecipient { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public string? Message { get; set; }
        public bool IsHtml { get; set; }
        public bool HasAttachment { get; set; }

        public List<EmailAttachmentRequest> EmailAttachmentsRequest { get; set; }
    }
}
