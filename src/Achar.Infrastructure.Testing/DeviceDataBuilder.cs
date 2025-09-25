using Achar.Domain.Reporting;
using Achar.Interfaces;

namespace Achar.Infrastructure.Testing
{
    public class DeviceDataBuilder : IDeviceDataBuilder
    {
        public TestDeviceData DeviceData { get; set; }
    }
}