using System.Collections.Generic;

namespace Achar.Infrastructure.Appium.Android.Options
{
    public class AppiumConfigurationOptions
    {
        public string AppiumHost { get; set; }

        public string StartPackageName { get; set; }

        public string StartActivityName { get; set; }

        public string PlatformName { get; set; }

        public string PlatformVersion { get; set; }

        public string DeviceName { get; set; }

        public RecordingConfigurationOptions RecordingConfigurationOptions { get; set; }

        public IDictionary<string, string> ActivityList { get; set; }
    }
}