using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.DependencyInjection;
using ObjectSharp.Seminar.Serverless.Domain.Services;

namespace ObjectSharp.Seminar.Serverless
{
    public class HealthFunctions
    {
        private readonly ITimestampService _timestamps;

        // Dependency resolution works if done in constructor
        public HealthFunctions(ITimestampService timestamps)
        {
            _timestamps = timestamps;
        }

        [FunctionName(nameof(PingHttpTrigger))]
        public IActionResult PingHttpTrigger(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ping")] HttpRequest req)
        {
            var now = _timestamps.Now();

            // DI Resolution Exception Here, when using ServiceProvider
            var serviceInstance = DI.Services.BuildServiceProvider().GetService<ITimestampService>() as ITimestampService;

            return new OkObjectResult(new { timestamp = now });
        }
    }
}
