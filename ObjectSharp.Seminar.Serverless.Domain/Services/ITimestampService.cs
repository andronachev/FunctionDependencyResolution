using System;

namespace ObjectSharp.Seminar.Serverless.Domain.Services
{
    public interface ITimestampService
    {
        DateTimeOffset Now();
    }
}
