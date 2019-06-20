using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using ObjectSharp.Seminar.Serverless;
using ObjectSharp.Seminar.Serverless.Domain.Services;

[assembly: FunctionsStartup(typeof(Startup))]
namespace ObjectSharp.Seminar.Serverless
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<ITimestampService, LocalTimestampService>();
            builder.Services.AddLogging();

            DI.Services = builder.Services;
           
        }
    }

    public static class DI
    {
        public static IServiceCollection Services;
    }
}
