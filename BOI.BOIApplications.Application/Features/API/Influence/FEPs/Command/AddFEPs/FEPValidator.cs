using BOI.BOIApplications.Application.Contracts.Persistence.Influence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.Influence.FEPs.Command.AddFEPs
{
    internal class FEPValidator : AbstractValidator<FEPCommand>
    {
        private readonly IFEPRepository _fEPRepository;

        public FEPValidator(IFEPRepository fEPRepository)
        {
            _fEPRepository = fEPRepository;
            RuleFor(p => p.FirstName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");            
            
            RuleFor(p => p.FepBvn)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .Length(11).WithMessage("{PropertyName} must be 11 digits.");

            RuleFor(p => p.LastName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");   
            
            RuleFor(p => p.FullName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");            
            
            RuleFor(p => p.OtherNames)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");            
            
            RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");           
            
            RuleFor(p => p.FepOrganisation)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");            
           
            RuleFor(p => p.FepPosition)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");             

            RuleFor(e => e)
            .MustAsync(DoesFEPRecordExist)
            .WithMessage("Financially Exposed Person Already exists.");
        }

        private async Task<bool> DoesFEPRecordExist(FEPCommand e, CancellationToken token)
        {
            return !(await _fEPRepository.DoesFEPExist(e.FepBvn));
        }
    }
}
