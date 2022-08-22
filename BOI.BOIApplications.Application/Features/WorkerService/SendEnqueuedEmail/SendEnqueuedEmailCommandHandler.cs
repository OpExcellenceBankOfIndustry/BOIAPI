using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Infrastructure;
using BOI.BOIApplications.Application.Contracts.Persistence.Mail;
using BOI.BOIApplications.Application.Model.ConfigurationModels;
using BOI.BOIApplications.Application.Model.Mail;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BOI.BOIApplications.Application.Features.WorkerService.SendEnqueuedEmail
{
    public class SendEnqueuedEmailCommandHandler : IRequestHandler<SendEnqueuedEmailCommand, bool?>
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly ILogger<SendEnqueuedEmailCommandHandler> _logger;

        public SendEnqueuedEmailCommandHandler(IEmailRepository emailRepository, IEmailService emailService,
            IMapper mapper, ILogger<SendEnqueuedEmailCommandHandler> logger)
        {
            _emailRepository = emailRepository;
            _emailService = emailService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool?> Handle(SendEnqueuedEmailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var allPendingEmails = await _emailRepository.GetPendingEnquedEmail();
                if (allPendingEmails != null)
                {
                    foreach (var email in allPendingEmails)
                    {
                        try
                        {
                            var emailsent = await _emailService.SendEmailAsync(_mapper.Map<EmailRequest>(email));

                            email.Sent = true;
                            email.SendAndReply = true;
                            email.ResponseTime = DateTimeOffset.UtcNow;
                            email.Response = $"Email sent to {email.ToRecipient}";
                            await _emailRepository.UpdateAsync(email);
                            return true;
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, $"An exception occurred while sending Email at SendEnqueuedEmailCommandHandler {nameof(Handle)}");
                            email.Sent = false;
                            email.Response = $"Email failed {ex.Message}";
                            await _emailRepository.UpdateAsync(email);
                            return null;
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An exception occurred at SendEnqueuedEmailCommandHandler {nameof(Handle)}");
                return null;
            }

        }
    }
}
