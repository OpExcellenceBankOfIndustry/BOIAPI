using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Persistence.Mail;
using BOI.BOIApplications.Application.Exceptions;
using BOI.BOIApplications.Domain.Entities;
using MediatR;

namespace BOI.BOIApplications.Application.Features.API.Mail.Command.EnqueueEmail
{
    public class EnqueueEmailCommandHandler : IRequestHandler<EnqueueEmailCommand, EnqueueEmailCommandResponse>
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IMapper _mapper;

        public EnqueueEmailCommandHandler(IEmailRepository emailRepository, IMapper mapper)
        {
            _emailRepository = emailRepository;
            _mapper = mapper;
        }
        public async Task<EnqueueEmailCommandResponse> Handle(EnqueueEmailCommand request, CancellationToken cancellationToken)
        {
            var validator = new EnqueueEmailValidators();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new CustomValidationException(validationResult);

            var insertedEmail = await _emailRepository.AddAsync(_mapper.Map<Email>(request));

            return new EnqueueEmailCommandResponse
            {
                Message = "Email submitted successfully",
                Success = true,
                EnqueueEmailViewModel = _mapper.Map<EnqueueEmailViewModel>(insertedEmail)

            };
        }
    }
}
