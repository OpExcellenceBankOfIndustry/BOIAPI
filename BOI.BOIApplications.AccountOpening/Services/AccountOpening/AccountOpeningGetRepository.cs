using AutoMapper;
using BOI.BOIApplications.Application.Contracts.AccountOpening;
using BOI.BOIApplications.Domain.Entities.AccountOpeningModels;
using BOI.BOIApplications.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.AccountOpening.Services.AccountOpening
{
    public class AccountOpeningGetRepository : IAccountOpeningGetRepository
    {
        private readonly ILogger<AccountOpeningGetRepository> _logger;
        private readonly IMapper _mapper;
        private readonly BOIDbContext _dbc;
        public AccountOpeningGetRepository(ILogger<AccountOpeningGetRepository> logger, IMapper mapper, BOIDbContext dbc)
        {
            _logger = logger;
            _mapper = mapper;
            _dbc = dbc;
        }

        public async Task<List<AOAccountDetailsOfOwner>> FetchAccountDetailsByEmail(string email)
        {
            try
            {
                if (email != null)
                {
                    _logger.LogInformation("<========================Start Fetch Account Details By Email ===========================>");
                    var details = await _dbc.AOAccountDetailsOfOwner.Where(x => x.UserEmail == email).ToListAsync(); 
                    _logger.LogInformation("<========================End Fetch Account Details By Email ===========================>");

                    return details;
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred.");
                throw;
            }
        }

        public async Task<List<AODetailsOfNextOfKin>> FetchDetailsOfNextOfKinByEmail(string email)
        {
            try
            {
                if (email != null)
                {
                    _logger.LogInformation("<========================Start Fetch Details Of Next Of Kin By Email ===========================>");
                    var details = await _dbc.AODetailsOfNextOfKins.Where(x => x.UserEmail == email).ToListAsync();
                    _logger.LogInformation("<========================End Fetch Details Of Next Of Kin By Email ===========================>");

                    return details;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred.");
                throw;
            }
        }

        public async Task<List<AOOwnershipInformationCooperate>> FetchOwnershipInformationCooperateByEmail(string email)
        {
            try
            {
                if (email != null)
                {
                    _logger.LogInformation("<========================Start Fetch Ownership Information Cooperate By Email ===========================>");
                    var details = await _dbc.AOOwnershipInformationCooperate.Where(x => x.UserEmail == email).ToListAsync();
                    _logger.LogInformation("<========================End Fetch Ownership Information Cooperate By Email ===========================>");

                    return details;
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred.");
                throw;
            }
        }

        public async Task<List<AOOwnershipInformationIndividual>> FetchOwnershipInformationIndividualByEmail(string email)
        {
            try
            {
                if (email != null)
                {
                    _logger.LogInformation("<========================Start Fetch Ownership Information Individual By Email ===========================>");
                    var details = await _dbc.AOOwnershipInformationIndividual.Where(x => x.UserEmail == email).ToListAsync();
                    _logger.LogInformation("<========================End Fetch Ownership Information Individual By Email ===========================>");

                    return details;
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred.");
                throw;
            }
        }

        public async Task<AOCompanyInformation> FetchCompanyInformationByEmail(string email)
        {
            try
            {
                if (email != null)
                {
                    _logger.LogInformation("<========================Start Fetch Company Information By Email ===========================>");
                    var details = await _dbc.AOCompanyInformations.Where(x => x.UserEmail == email).FirstOrDefaultAsync();
                    _logger.LogInformation("<========================End Fetch Company Information By Email ===========================>");

                    return details;
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred.");
                throw;
            }
        }

        public async Task<AORegulatoryInformation> FetchRegulatoryInformationByEmail(string email)
        {
            try
            {
                if (email != null)
                {
                    _logger.LogInformation("<========================Start Fetch Regulatory Information By Email ===========================>");
                    var details = await _dbc.AORegulatoryInformation.Where(x => x.UserEmail == email).FirstOrDefaultAsync();
                    _logger.LogInformation("<========================End Fetch Regulatory Information By Email ===========================>");

                    return details;
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred.");
                throw;
            }
        }

        public async Task<AORelatedPartyInformation> FetchRelatedPartyInformationByEmail(string email)
        {
            try
            {
                if (email != null)
                {
                    _logger.LogInformation("<========================Start Fetch Related Party Information By Email ===========================>");
                    var details = await _dbc.AORelatedPartyInformation.Where(x => x.UserEmail == email).FirstOrDefaultAsync();
                    _logger.LogInformation("<========================End Fetch Related Party Information  By Email ===========================>");

                    return details;
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred.");
                throw;
            }
        }

        public async Task<AOSoleProprietorship> FetchSoleProprietorshipByEmail(string email)
        {
            try
            {
                if (email != null)
                {
                    _logger.LogInformation("<========================Start Fetch Sole Proprietorship By Email ===========================>");
                    var details = await _dbc.AOSoleProprietorship.Where(x => x.UserEmail == email).FirstOrDefaultAsync();
                    _logger.LogInformation("<========================End Fetch Sole Proprietorship By Email ===========================>");

                    return details;
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred.");
                throw;
            }
        }

    }
}
