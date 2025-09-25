using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Achar.Domain.Testing.Enum;
using Achar.Interfaces.Reporting;
using Achar.Interfaces.Testing;
using NUnit.Framework;
using Reqnroll;

namespace Achar.Infrastructure.ReqnRoll.Hooks
{
    [Binding]
    public class ContextLoadHook
    {
        private const string TagDevice = "DEVICE:";

        // Needs to be the absolute first thing loaded by the test runner
        // (injected interfaces are selected based on values extracted here)
        [Before(Order = 1)]
        public static async Task LoadContextDataAsync(
            IScopedReportingContextManager scopedReportingContextManager,
            ITestOutcomeBuilder builder)
        {
            var testContext =
                TestContext
                    .CurrentContext;

            var deviceContext =
                await ExtractFeatureAttributesAsync<RunnerTypeEnum>(testContext, TagDevice);

            scopedReportingContextManager
                .SetDeviceContext(deviceContext);

            // await
            //     ValidateAttributesAsync(testContext);
        }

        private static async Task<T> ExtractFeatureAttributesAsync<T>(
            TestContext testContext,
            string tagPrefix)
        {
            var tagName =
                testContext
                    .Test
                    .Type?
                    .GetCustomAttributes<CategoryAttribute>()?
                    .Where(o =>
                        o
                            .Name
                            .StartsWith(tagPrefix)
                    )?
                    .FirstOrDefault()?
                    .Name;

            if (string.IsNullOrEmpty(tagName))
                throw new Exception($"Could not find tag with prefix {tagPrefix} for {testContext.Test.Name}");

            var value =
                tagName
                    .Split(tagPrefix, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)?
                    .FirstOrDefault();

            if (value == null)
                throw new Exception($"Value not defined for tag {tagPrefix} for {testContext.Test.Name}");

            T convertedValue = default;

            try
            {
                convertedValue =
                    (T)Convert
                        .ChangeType(value, typeof(T));
            }
            catch (InvalidCastException)
            {
                convertedValue =
                    (T)
                    Enum
                        .Parse(typeof(T), value, true);
            }

            return convertedValue;
        }

        private static async Task ValidateAttributesAsync(TestContext context)
        {
            var categories =
                context
                    .Test
                    .Properties["Category"]
                    .Select(o => o.ToString())
                    .ToList();


            var testCategory =
                categories
                    .FirstOrDefault(o => (o ?? string.Empty).StartsWith("TEST_")) ?? string.Empty;

            var testSetCategory =
                categories
                    .FirstOrDefault(o => (o ?? string.Empty).StartsWith("TESTSET_")) ?? string.Empty;

            if (string.IsNullOrEmpty(testCategory))
                throw new Exception(
                    $"A test context has not been specified for the test {context.Test.Name}; please check your feature.");

            var testKey = testCategory.Replace("TEST_", string.Empty);
            var testSetKey = testSetCategory.Replace("TESTSET_", string.Empty);
        }
    }
}