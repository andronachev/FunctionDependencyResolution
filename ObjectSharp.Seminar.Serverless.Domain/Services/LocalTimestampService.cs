using Microsoft.Extensions.Logging;
using System;

namespace ObjectSharp.Seminar.Serverless.Domain.Services
{
    public class LocalTimestampService : ITimestampService
    {
        private ILogger<ITimestampService> logger;

        public LocalTimestampService(ILogger<ITimestampService> logger)
        {
            this.logger = logger;
        }

        public DateTimeOffset Now()
        {
            return DateTimeOffset.Now;
        }

        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    }
}
