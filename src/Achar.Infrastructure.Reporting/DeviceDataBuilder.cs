using Achar.Domain.Reporting;
using Achar.Interfaces.Reporting;

namespace Achar.Infrastructure.Reporting
{
    public class DeviceDataBuilder : IDeviceDataBuilder
    {
        public TestDeviceData DeviceData { get; set; }
    }
}