using BOI.BOIApplications.Domain.Entities.AccountOpeningModels;
using BOI.BOIApplications.Domain.Entities.MicroCreditModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Contracts.AccountOpening
{
    public interface IAODropDownListRepository
    {
        Task<List<Bank>> FetchAllBanks();     
        Task<List<AOCompanyType>> FetchAllCompanyType();

        Task<List<AOMaritalStatus>> FetchAllMaritalStatus();
        Task<List<AOAnnualTurnover>> FetchAllAnnualTurnover();
        Task<List<AOIdentificationType>> FetchAllIdentificationType();
        Task<List<AOStakeholderCapacity>> FetchAllStakeholderCapacity();
        Task<List<AOHighestEducationalQualification>> FetchAllHighestEducationalQualification();
        Task<List<AOTitle>> FetchAllTitle();

        Task<List<AOEmployeesRelationship>> FetchEmployeesRelationship();
        Task<List<AOJobTitle>> FetchAllJobTitle();
        Task<List<AOCompanyBOIDiscover>> FetchCompanyBOIDiscover();
    }
}
