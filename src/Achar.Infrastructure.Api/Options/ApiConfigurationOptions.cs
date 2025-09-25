using System;

namespace Achar.Infrastructure.Api.Options
{
    public class ApiConfigurationOptions
    {
        public string BaseUrl { get; set; }

        public Guid ValidApiKey { get; set; }
    }
}