using System;
using Achar.Interfaces;

namespace Achar.Infrastructure.Reporting
{
    public class TestDateStamper : ITestDateStamper
    {
        public DateTime StampedDate { get; } = DateTime.Now;
    }
}