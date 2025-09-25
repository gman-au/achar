using System;
using System.IO;
using System.Threading.Tasks;
using Achar.Infrastructure.ReqnRoll.Extensions;
using Achar.Interfaces.Reporting;
using Achar.Interfaces.Testing;
using NUnit.Framework;
using Reqnroll;

namespace Achar.Infrastructure.ReqnRoll.Hooks
{
    [Binding]
    public class RecordingHook
    {
        private static readonly string ResultsPath =
            Environment.GetEnvironmentVariable("RESULTS_PATH") ??
            Directory.GetCurrentDirectory();

        [Before(Order = 3)]
        public static async Task PrepareRecordingAsync(IScreenInteractionEngine engine)
        {
            await
                engine
                    .StartRecordingAsync();
        }

        [After(Order = 998)]
        public static async Task FinaliseRecordingAsync(
            IScreenInteractionEngine engine,
            ITestDateStamper testDateStamper,
            IStepCollector stepCollector,
            ITestOutcomeExporter exporter)
        {
            var testContext =
                TestContext
                    .CurrentContext;

            // Artificial delay to hold last recording screen
            await
                Task
                    .Delay(3000);

            // ---------------------
            // For debugging purposes
            var recordingData =
                await
                    engine
                        .StopAndGetRecordingAsync();
            // ---------------------

            var testOutcome =
                testContext
                    .ToOutcome();

            if (!string.IsNullOrEmpty(recordingData))
            {
                // ---------------------
                // For debugging purposes
                var outputPath =
                    Path
                        .Combine(ResultsPath, $"{testDateStamper.StampedDate:yyyy_MM_dd_hh_mm_ss}_{testOutcome.TestKey}.mp4");

                await
                    File
                        .WriteAllBytesAsync(outputPath, Convert.FromBase64String(recordingData));
                // ---------------------

                // var evidence =
                //     new TestEvidence
                //     {
                //         Data = recordingData,
                //         Filename = $"{Guid.NewGuid()}_recording.mp4",
                //         ContentType = "video/mp4"
                //     };
                //
                // testOutcome.Evidences = [evidence];
            }
        }
    }
}