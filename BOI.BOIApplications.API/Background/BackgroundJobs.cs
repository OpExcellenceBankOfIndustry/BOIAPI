using BOI.BOIApplications.Application.Contracts.Background;
using Hangfire;

namespace BOI.BOIApplications.API.Background
{
    public static class BackgroundJobs
    {

        public static IConfiguration? config;
        public static void Initialize(IConfiguration Configuration)
        {
            config = Configuration;
        }
        public static void Register()
        {
            RecurringJob.AddOrUpdate<IBackgroundService>(x => x.PostData(), config.GetSection("ChronSettings")["PostData"]);
        }
    }
}
