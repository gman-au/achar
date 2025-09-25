using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Achar.Infrastructure.ReqnRoll.Extensions;
using Achar.Interfaces.Reporting;
using NUnit.Framework;
using Reqnroll;

namespace Achar.Infrastructure.ReqnRoll.Hooks
{
    [Binding]
    public class TestOutcomeHook
    {
        private static readonly Stopwatch Stopwatch = new();
        private static readonly DateTime StartTime = DateTime.Now;

        private static readonly string ResultsPath =
            Environment.GetEnvironmentVariable("RESULTS_PATH") ??
            Directory.GetCurrentDirectory();

        [Before(Order = 4)]
        public static async Task PrepareOutcomeAsync() =>
            Stopwatch
                .Start();

        [After(Order = 997)]
        public static async Task FinaliseOutcomeAsync(
            IDeviceDataBuilder dataBuilder,
            IStepCollector stepCollector,
            ITestDateStamper testDateStamper,
            ITestOutcomeExporter exporter)
        {
            Stopwatch
                .Stop();

            var finishTime = DateTime.Now;

            var startTime =
                finishTime
                    .Subtract(TimeSpan.FromTicks(Stopwatch.ElapsedTicks / 2));

            var testContext =
                TestContext
                    .CurrentContext;

            var testOutcome =
                testContext
                    .ToOutcome();

            testOutcome.StartDate = startTime;
            testOutcome.FinishDate = finishTime;

            var stepOutcomes =
                stepCollector
                    .GetStepOutcomes();

            testOutcome.Steps = stepOutcomes;
            testOutcome.DeviceData = dataBuilder.DeviceData;

            await
                exporter
                    .PerformAsync(testOutcome, ResultsPath, testDateStamper.StampedDate);
        }
    }
}