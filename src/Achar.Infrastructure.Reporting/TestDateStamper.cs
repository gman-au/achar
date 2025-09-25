using System;
using Achar.Interfaces.Reporting;

namespace Achar.Infrastructure.Reporting
{
    public class TestDateStamper : ITestDateStamper
    {
        public DateTime StampedDate { get; } = DateTime.Now;
    }
}