using BOI.BOIApplications.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.Influence.CorporateWatchLists.Queries.GetCorporateWatchListByCompanyReg
{
    public class GetCorporateWatchListByCompanyRegQueryResponse : BaseResponse
    {
        public GetCorporateWatchListByCompanyRegQueryResponse() : base()
        {

        }

        public GetCorporateWatchListByCompanyRegQueryViewModel GetCorporateWatchListByCompanyRegQueryViewModel { get; set; }
    }
}
