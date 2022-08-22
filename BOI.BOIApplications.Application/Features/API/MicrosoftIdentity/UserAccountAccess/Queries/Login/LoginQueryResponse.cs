using BOI.BOIApplications.Application.Responses;
//using BOI.BOIApplications.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Queries.Login
{
    public class LoginQueryResponse : BaseResponse
    {
        public LoginQueryResponse() : base() { }
        public Domain.Entities.UserLoginDetailViewModel UserDetail { get; set; }
        //public LoginViewModel LoginViewModel { get; set; }
    }

}
