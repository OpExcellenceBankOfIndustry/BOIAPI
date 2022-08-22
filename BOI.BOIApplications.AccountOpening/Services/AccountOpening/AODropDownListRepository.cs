using BOI.BOIApplications.Application.Contracts.AccountOpening;
using BOI.BOIApplications.Domain.Entities.AccountOpeningModels;
using BOI.BOIApplications.Domain.Entities.MicroCreditModels;
using BOI.BOIApplications.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.AccountOpening.Services.AccountOpening
{
    public class AODropDownListRepository : IAODropDownListRepository
    {
        private readonly BOI2DbContext _dbc;
        private readonly BOI3DbContext _dbc3;

        public AODropDownListRepository(BOI2DbContext dbc, BOI3DbContext dbc3)
        {
            _dbc = dbc;
            _dbc3 = dbc3;
        }

        public async Task<List<Bank>> FetchAllBanks()
        {
            try
            {
                var allBanks = await _dbc.Banks.Select(x => new Bank() { id = x.id, name = x.name.Trim()}).OrderBy(e => e.name).ToListAsync();

                return allBanks;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<AOCompanyType>> FetchAllCompanyType()
        {
            try
            {
                var companyType = await _dbc.AOCompanyType.Select(x => new AOCompanyType() {id = x.id, name = x.name.Trim()}).OrderBy(e => e.id).ToListAsync();
                return companyType;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<AOMaritalStatus>> FetchAllMaritalStatus()
        {
            try
            {
                var maritalStatus = await _dbc.AOMaritalStatus.Select(x => new AOMaritalStatus() { id = x.id, name = x.name.Trim()}).OrderBy(e => e.name).ToListAsync();
                return maritalStatus;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<AOAnnualTurnover>> FetchAllAnnualTurnover()
        {
            try
            {
                //var annualTurnover1 = await _dbc.AOAnnualTurnover.ToListAsync();
                var annualTurnover = await _dbc.AOAnnualTurnover.Select(x => new AOAnnualTurnover(){ id = x.id, name = x.name.Trim()}).ToListAsync();
                return annualTurnover;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<AOIdentificationType>> FetchAllIdentificationType()
        {
            try
            {
                var identificationType = await _dbc.AOIdentificationType.Select(x => new AOIdentificationType() { id = x.id, name = x.name.Trim()}).OrderBy(e => e.name).ToListAsync();
                return identificationType;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<AOStakeholderCapacity>> FetchAllStakeholderCapacity()
        {
            try
            {
                var stakeholderCapacity = await _dbc.AOStakeholderCapacity.Select(x => new AOStakeholderCapacity() { id = x.id, name = x.name.Trim()}).OrderBy(e => e.name).ToListAsync();
                return stakeholderCapacity;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<AOHighestEducationalQualification>> FetchAllHighestEducationalQualification()
        {
            try
            {
                var highestEducationalQualification = await _dbc.AOHighestEducationalQualification.Select(x => new AOHighestEducationalQualification() { id = x.id, name = x.name.Trim()}).ToListAsync();
                return highestEducationalQualification;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<AOTitle>> FetchAllTitle()
        {
            try
            {
                var title = await _dbc.AOTitle.Select(x => new AOTitle() { id = x.id, name = x.name.Trim()}).OrderBy(e => e.name).ToListAsync();
                return title;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<AOEmployeesRelationship>> FetchEmployeesRelationship()
        {
            try
            {
                var employees = await _dbc3.AOEmployeesRelationships.Select(x => new AOEmployeesRelationship() { id = x.id, name = x.name.Trim() }).OrderBy(e => e.name).ToListAsync();
                return employees;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<AOJobTitle>> FetchAllJobTitle()
        {
            try
            {
                var jobTitle = await _dbc3.AOJobTitles.Select(x => new AOJobTitle() { id = x.id, name = x.name.Trim() }).OrderBy(e => e.name).ToListAsync();
                return jobTitle;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<AOCompanyBOIDiscover>> FetchCompanyBOIDiscover()
        {
            try
            {
                var discovers = await _dbc3.AOCompanyBOIDiscovers.Select(x => new AOCompanyBOIDiscover() { id = x.id, name = x.name.Trim() }).OrderBy(e => e.name).ToListAsync();
                return discovers;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
