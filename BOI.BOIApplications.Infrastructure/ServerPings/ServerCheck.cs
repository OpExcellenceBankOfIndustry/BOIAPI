using BOI.BOIApplications.Application.Contracts.Infrastructure;
using BOI.BOIApplications.Application.Model.ConfigurationModels;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Infrastructure.ServerPings
{
    public class ServerCheck : IServerCheck
    {
        private readonly ServiceConfigurationSettings _serviceConfigurtionSettings;

        public ServerCheck(IOptions<ServiceConfigurationSettings> serviceConfigurtionSettings)
        {
            _serviceConfigurtionSettings = serviceConfigurtionSettings.Value;
        }
        public Task<bool> IsServerStillUp()
        {
            var ping = new Ping();
            IPAddress address = IPAddress.Parse(_serviceConfigurtionSettings.BonitaServerIPAddress);
            PingReply pong = ping.Send(address);
            if (pong.Status == IPStatus.Success)
            {
               return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        public async Task<bool> IsWebsiteStillUp()
        {
            var client = new HttpClient();
            var checkingResponse = await client.GetAsync(_serviceConfigurtionSettings.BonitaWebUrl);
            return checkingResponse.IsSuccessStatusCode;
        }
    }
}
