using BOI.BOIApplications.Application.Contracts.Background;
using BOI.BOIApplications.Application.Contracts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Background.Services
{
    public class BackgroundService : IBackgroundService
    {
        public readonly IHttpClientHelper? _httpClientHelper;

        public BackgroundService(IHttpClientHelper? httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }

        protected

        public Task PostData()
        {
            throw new NotImplementedException();
        }
    }
}
