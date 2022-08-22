using AutoMapper;
using BOI.BOIApplications.Application.Features.API.Influence.CorporateWatchLists.Command.AddCorporateWatchLists;
using BOI.BOIApplications.Application.Features.API.Influence.CorporateWatchLists.Queries.GetAllCorporateWatchLists;
using BOI.BOIApplications.Application.Features.API.Influence.CorporateWatchLists.Queries.GetCorporateWatchListByCompanyReg;
using BOI.BOIApplications.Application.Features.API.Influence.FEPs.Command.AddFEPs;
using BOI.BOIApplications.Application.Features.API.Influence.FEPs.Queries.GetAllFEPs;
using BOI.BOIApplications.Application.Features.API.Influence.FEPs.Queries.GetFEPsByBVN;
using BOI.BOIApplications.Application.Features.API.Influence.IndividualWatchLists.Command.AddIndividualWatchList;
using BOI.BOIApplications.Application.Features.API.Influence.IndividualWatchLists.Queries.GetAllIndividualWatchLists;
using BOI.BOIApplications.Application.Features.API.Influence.IndividualWatchLists.Queries.GetIndividualWatchListsByBVN;
using BOI.BOIApplications.Application.Features.API.Influence.PEPs.Comamnd.AddPEPs;
using BOI.BOIApplications.Application.Features.API.Influence.PEPs.Queries.GetAllPeps;
using BOI.BOIApplications.Application.Features.API.Influence.PEPs.Queries.GetPEPByBVN;
using BOI.BOIApplications.Domain.Entities;

namespace BOI.BOIApplications.Application.Profiles.API.Influence
{
    public class InfluenceMappingProfiles : Profile
    {
        public InfluenceMappingProfiles()
        {
            ///Financialy Exposed Persons
            CreateMap<FEP, FEPCommand>()
                .ReverseMap();            
            
            CreateMap<FEP, FEPCommandViewModel>()
                .ReverseMap();   
            
            CreateMap<FEP, GetAllFEPQueryViewModel>()
                .ReverseMap();            
            
            CreateMap<FEP, GetFEPsByBVNQueryViewModel>()
                .ReverseMap();


            //Politically Exposed Persons
            CreateMap<PEP, AddPEPCommand>()
                .ReverseMap();

            CreateMap<PEP, AddPEPCommandViewModel>()
                .ReverseMap();

            CreateMap<PEP, GetAllPEPQueryViewModel>()
               .ReverseMap();            
            
            CreateMap<PEP, GetPEPByBVNQueryViewModel>()
               .ReverseMap();


            //Coporate Watchlists
            CreateMap<CorporateWatchList, AddCorporateWatchListsCommand>()
                .ReverseMap();

            CreateMap<CorporateWatchList, AddCorporateWatchListsViewModel>()
                .ReverseMap();

            CreateMap<CorporateWatchList, GetAllCorporateWatchListsQueryViewModel>()
                .ReverseMap();

            CreateMap<CorporateWatchList, GetCorporateWatchListByCompanyRegQueryViewModel>()
                .ReverseMap();


            //Individual WatchLists
            CreateMap<IndividualWatchList, AddIndividualWatchListCommand>()
                .ReverseMap();

            CreateMap<IndividualWatchList, AddIndividualWatchListViewModel>()
                .ReverseMap();

            CreateMap<IndividualWatchList, GetAllIndividualWatchListsViewModel>()
                .ReverseMap();

            CreateMap<IndividualWatchList, GetIndividualWatchListsByBVNViewModel>()
                .ReverseMap();
        }
    }
}
