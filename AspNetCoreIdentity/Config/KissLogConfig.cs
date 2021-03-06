using KissLog;
using KissLog.Apis.v1.Listeners;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreIdentity.Config
{
    public static class KissLogConfig
    {
        public static void RegisterKissLogListeners(IConfiguration configuration)
        {
            KissLogConfiguration.Listeners.Add(new KissLogApiListener(
                configuration["KissLog.OrganizationId"],
                configuration["KissLog.ApplicationId"],
                configuration["KissLog.ApplicationId"]
            ));
        }
    }
}
