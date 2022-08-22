using FluentValidation;

namespace BOI.BOIApplications.Application.Features.API.Mail.Command.EnqueueEmail
{
    public class EnqueueEmailValidators : AbstractValidator<EnqueueEmailCommand>
    {
        public EnqueueEmailValidators()
        {
            RuleFor(p => p.Message)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} cannot be null.");            
            
            RuleFor(p => p.Channel)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} cannot be null.");            
            
            RuleFor(p => p.Sender)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} cannot be null.");            
            
            RuleFor(p => p.ToRecipient)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} cannot be null.");            
            
            RuleFor(p => p.Subject)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} cannot be null.");            
            
            RuleFor(p => p.Channel)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} cannot be null.");            
            
            RuleFor(p => p.IsHtml)
                .NotNull().WithMessage("{PropertyName} cannot be null.");            
            
            RuleFor(p => p.HasAlternateView)
                .NotNull().WithMessage("{PropertyName} cannot be null.");            
            
            RuleFor(p => p.HasAttachment)
                .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(e => e)
                .MustAsync(DoesAttachementExist)
                .WithMessage("please include an attachment when attachment field is selected");

            RuleFor(e => e)
            .MustAsync(IsAttachementDataCompletedorValid)
            .WithMessage("Attachement provided is not valid or attachment data is incomplete please check");
        }

        private Task<bool> DoesAttachementExist(EnqueueEmailCommand e, CancellationToken token)
        {
            if (e.HasAttachment)
            {
                if (e.EmailAttachments == null)
                {
                    return Task.FromResult(false);
                }
            }

            return Task.FromResult(true);

        }

        private Task<bool> IsAttachementDataCompletedorValid(EnqueueEmailCommand e, CancellationToken token)
        {

            foreach (var attachment in e.EmailAttachments)
            {
                var buffer = new Span<byte>(new byte[attachment.Attachment.Length]);
                // check if attachemnt is a valid byte array
                if (Convert.TryFromBase64String(attachment.Attachment, buffer, out int bytesParsed))
                {
                    return Task.FromResult(false);
                }

                if (e.HasAttachment)
                {
                    if (string.IsNullOrEmpty(attachment.FileName))
                    {
                        return Task.FromResult(false);
                    }
                    if (string.IsNullOrEmpty(attachment.ContentType))
                    {
                        return Task.FromResult(false);
                    }
                }

            }

            return Task.FromResult(true);

        }

    }
}
