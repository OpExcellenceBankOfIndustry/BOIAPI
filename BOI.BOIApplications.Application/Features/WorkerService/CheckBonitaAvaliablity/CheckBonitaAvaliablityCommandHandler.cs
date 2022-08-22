using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Infrastructure;
using BOI.BOIApplications.Application.Model.ConfigurationModels;
using BOI.BOIApplications.Application.Model.Mail;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BOI.BOIApplications.Application.Features.WorkerService.CheckBonitaAvaliablity
{
    public class CheckBonitaAvaliablityCommandHandler : IRequestHandler<CheckBonitaAvaliablityCommand, bool?>
    {
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly ILogger<CheckBonitaAvaliablityCommandHandler> _logger;
        private readonly IServerCheck _serverCheck;
        private readonly ServiceConfigurationSettings _serviceConfigurtionSettings;

        public CheckBonitaAvaliablityCommandHandler(IEmailService emailService,IMapper mapper,ILogger<CheckBonitaAvaliablityCommandHandler> logger, 
            IServerCheck serverCheck, IOptions<ServiceConfigurationSettings> options)
        {
            _emailService = emailService;
            _mapper = mapper;
            _logger = logger;
            _serverCheck = serverCheck;
            _serviceConfigurtionSettings = options.Value;
        }

        public async Task<bool?> Handle(CheckBonitaAvaliablityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var isWebsiteUp = await _serverCheck.IsWebsiteStillUp();
                if (!isWebsiteUp)
                {
                    _logger.LogInformation("Bonita website is down");
                    var sendEmail = await _emailService.SendEmailAsync(new EmailRequest
                    {
                        ToRecipient = _serviceConfigurtionSettings.SendBonitaAvailabilityTo,
                        Message = "Bonita Website is down Please check server and ensure the service is started",
                        IsHtml = false,
                        HasAttachment = false,
                        Subject = "BONITA Website is Down!!!"
                    });

                    return sendEmail;
                }
                _logger.LogInformation("Bonita Server is up and running perfectly");
                return isWebsiteUp;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An exception occurred at CheckBonitaAvaliablityCommandHandler {nameof(Handle)}");
                return null;
            }


        }
    }
}
