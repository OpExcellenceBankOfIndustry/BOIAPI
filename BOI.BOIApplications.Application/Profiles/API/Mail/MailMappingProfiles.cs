using AutoMapper;
using BOI.BOIApplications.Application.Features.API.Mail.Command.EnqueueEmail;
using BOI.BOIApplications.Application.Model.Mail;
using BOI.BOIApplications.Domain.Entities;
using System.Text;

namespace BOI.BOIApplications.Application.Profiles.API.Mail
{
    public class MailMappingProfiles : Profile
    {
        public MailMappingProfiles()
        {
            CreateMap<EnqueueEmailCommand, Email>()
            .BeforeMap((eque, e) => e.DateLogged = DateTimeOffset.UtcNow)
            .ReverseMap();

            CreateMap<Email, EnqueueEmailViewModel>()
            .ReverseMap();            
            
            CreateMap<EnqueueEmailAttachmentsCommand, EmailAttachment>()
            .ForMember(
                dest => dest.Attachment,
                opt => opt.MapFrom(src => (src.Attachment == null) ? null : Encoding.ASCII.GetBytes(src.Attachment))
                )
            .ReverseMap();            
            
            CreateMap<EmailAttachment, EnqueueEmailAttachmentsViewModel>()
            .ReverseMap();


            CreateMap<Email, EmailRequest>()
            .ReverseMap();

            CreateMap<EmailAttachment, EmailAttachmentRequest>()
            .ReverseMap();
        }
    }
}
