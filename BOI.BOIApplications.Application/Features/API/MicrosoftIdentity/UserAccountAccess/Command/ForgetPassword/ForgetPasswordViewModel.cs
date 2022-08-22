using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Features.API.MicrosoftIdentity.UserAccountAccess.Command.ForgetPassword
{
    public class ForgetPasswordViewModel : ForgetPasswordCommand    
    {
        public string Message { get; set; }
        public string ErrorMessage { set; get; }
    }
}
