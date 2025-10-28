using Achar.Domain.Reporting;
using Achar.Interfaces.Reporting;

namespace Achar.Infrastructure.Testing.Extensions
{
    public static class DeviceDataBuilderEx
    {
        public static IDeviceDataBuilder CreateDeviceDataBuilder(this IDeviceDataBuilder deviceDataBuilder)
        {
            deviceDataBuilder.DeviceData = new TestDeviceData();
            return deviceDataBuilder;
        }

        public static IDeviceDataBuilder WithPlatformName(this IDeviceDataBuilder builder, string platformName)
        {
            builder.DeviceData.PlatformName = platformName;
            return builder;
        }

        public static IDeviceDataBuilder WithPlatformVersion(this IDeviceDataBuilder builder, string platformVersion)
        {
            builder.DeviceData.PlatformVersion = platformVersion;
            return builder;
        }

        public static IDeviceDataBuilder WithDeviceName(this IDeviceDataBuilder builder, string deviceName)
        {
            builder.DeviceData.DeviceName = deviceName;
            return builder;
        }

        public static IDeviceDataBuilder WithDeviceModel(this IDeviceDataBuilder builder, string deviceModel)
        {
            builder.DeviceData.DeviceModel = deviceModel;
            return builder;
        }

        public static IDeviceDataBuilder WithDeviceManufacturer(this IDeviceDataBuilder builder, string deviceManufacturer)
        {
            builder.DeviceData.DeviceManufacturer = deviceManufacturer;
            return builder;
        }

        public static IDeviceDataBuilder WithDeviceApiLevel(this IDeviceDataBuilder builder, string deviceApiLevel)
        {
            builder.DeviceData.DeviceApiLevel = deviceApiLevel;
            return builder;
        }

        public static IDeviceDataBuilder WithDeviceScreenSize(this IDeviceDataBuilder builder, string deviceScreenSize)
        {
            builder.DeviceData.DeviceScreenSize = deviceScreenSize;
            return builder;
        }

        public static IDeviceDataBuilder WithDeviceId(this IDeviceDataBuilder builder, string deviceId)
        {
            builder.DeviceData.DeviceId = deviceId;
            return builder;
        }

        public static IDeviceDataBuilder WithOsName(this IDeviceDataBuilder builder, string osName)
        {
            builder.DeviceData.OsName = osName;
            return builder;
        }

        public static IDeviceDataBuilder WithPixelRatio(this IDeviceDataBuilder builder, string pixelRatio)
        {
            builder.DeviceData.PixelRatio = pixelRatio;
            return builder;
        }
    }
}