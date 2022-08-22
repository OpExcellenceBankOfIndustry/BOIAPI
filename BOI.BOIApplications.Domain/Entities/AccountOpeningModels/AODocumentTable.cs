using BOI.BOIApplications.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Domain.Entities.AccountOpeningModels
{
    public class AODocumentTable
    {
        public int Id { get; set; }
        public string? FileDesc { get; set; }
        public string? FileName { get; set; }
        public string? FileExt { get; set; }
        public string? FilePath { get; set; }
        public DateTime FileUploadedDate { get; set; }
        public string? UploadedBy { get; set; }
        public UploadStatus UploadStatus { get; set; }
        public string? FileSubject { get; set; }
        public string? FileCategory { get; set; }
        public string? FileNameUrl { get; set; }
        public Boolean Isdeleted { get; set; }
    }
}
