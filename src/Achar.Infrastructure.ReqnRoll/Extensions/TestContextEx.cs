using System.Linq;
using Achar.Domain.Reporting;
using NUnit.Framework;

namespace Achar.Infrastructure.ReqnRoll.Extensions
{
    internal static class TestContextEx
    {
        public static TestOutcome ToOutcome(this TestContext context)
        {
            var outcome = new TestOutcome();

            var testName = $"{context.Test.ClassName}.{context.Test.MethodName}";

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

            var testKey = testCategory.Replace("TEST_", string.Empty);
            var testSetKey = testSetCategory.Replace("TESTSET_", string.Empty);

            outcome.TestKey = testKey;

            var description =
                context
                    .Test
                    .Properties["Description"]
                    .Select(o => o.ToString())
                    .FirstOrDefault();

            outcome.TestName = testName;
            outcome.Summary = description;

            return outcome;
        }
    }
}