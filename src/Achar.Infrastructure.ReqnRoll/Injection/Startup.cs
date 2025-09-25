using System;
using System.IO;
using Achar.Infrastructure.Api.HttpClient;
using Achar.Infrastructure.Api.Options;
using Achar.Infrastructure.Reporting;
using Achar.Infrastructure.Testing;
using Achar.Infrastructure.Testing.Null;
using Achar.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reqnroll.Microsoft.Extensions.DependencyInjection;

namespace Achar.Infrastructure.ReqnRoll.Injection
{
    public class Startup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var environment =
                Environment
                    .GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            if (string.IsNullOrEmpty(environment))
                throw new Exception(
                    "Runtime environment variable [ASPNETCORE_ENVIRONMENT] is not defined; please check your configuration.");

            var configuration =
                new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile($"appsettings.{environment}.json", false)
                    .Build();

            var services = new ServiceCollection();

            services
                .Configure<ApiConfigurationOptions>(configuration.GetSection(nameof(ApiConfigurationOptions)))
                // .Configure<AppiumConfigurationOptions>(configuration.GetSection(nameof(AppiumConfigurationOptions)))
                // .Configure<BrowserStackConfigurationOptions>(configuration.GetSection(nameof(BrowserStackConfigurationOptions)))
                .AddSingleton<IApiInteractionEngine, ApiHttpClientInteractionEngine>()
                // .AddSingleton<IScreenInteractionEngine, AndroidBrowserStackInteractionEngine>()
                .AddSingleton<IScreenInteractionEngine, NullInteractionEngine>()
                // .AddSingleton<IScreenInteractionEngine, AndroidAppiumInteractionEngine>()
                // .AddTransient<IKeyboardKeyMapper, AndroidAppiumKeyboardKeyMapper>()
                // .AddSingleton<ITestOutcomeExporter, ZephyrTestOutcomeFileExporter>()
                // .AddSingleton<ITestOutcomeExporter, XrayFileTestOutcomeFileExporter>()
                .AddSingleton<ITestOutcomeExporter, NullTestOutcomeExporter>()
                .AddSingleton<ITestOutcomeBuilder, TestOutcomeBuilder>()
                .AddSingleton<IScopedTestContextManager, ScopedTestContextManager>()
                .AddSingleton<IDeviceDataBuilder, DeviceDataBuilder>()
                .AddScoped<ITestDateStamper, TestDateStamper>()
                .AddScoped<IStepCollector, StepCollector>();

            return services;
        }
    }
}