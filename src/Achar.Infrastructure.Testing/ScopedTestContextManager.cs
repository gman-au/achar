using System;
using System.Collections.Generic;
using System.Linq;
using Achar.Domain.Testing;
using Achar.Domain.Testing.Enum;
using Achar.Interfaces;

namespace Achar.Infrastructure.Testing
{
    public class ScopedTestContextManager(
        IEnumerable<IScreenInteractionEngine> screenInteractionEngines,
        IEnumerable<IApiInteractionEngine> apiInteractionEngines,
        IEnumerable<ITestOutcomeExporter> testOutcomeExporters
    )
        : IScopedTestContextManager
    {
        private ScopedTestContext ScopedTestContext { get; set; } = new();

        public void SetDeviceContext(RunnerTypeEnum runnerType)
        {
            (ScopedTestContext ??= new ScopedTestContext()).RunnerType = runnerType;
        }

        public IScreenInteractionEngine GetScreenInteractionEngine()
        {
            var engine =
                screenInteractionEngines
                    .FirstOrDefault(o => o.IsApplicable(ScopedTestContext.RunnerType)) ??
                screenInteractionEngines
                    .FirstOrDefault(o => o.IsApplicable(RunnerTypeEnum.NotSet));

            if (engine == null)
                throw new Exception($"No applicable interaction engine found for type {ScopedTestContext?.RunnerType}");

            return engine;
        }

        public IApiInteractionEngine GetApiInteractionEngine()
        {
            var engine =
                apiInteractionEngines
                    .FirstOrDefault(o => o.IsApplicable(ScopedTestContext?.RunnerType ?? RunnerTypeEnum.NotSet));

            if (engine == null)
                throw new Exception($"No applicable interaction engine found for type {ScopedTestContext?.RunnerType}");

            return engine;
        }

        public ITestOutcomeExporter GetTestOutcomeExporter()
        {
            var outcomeExporter =
                testOutcomeExporters
                    .FirstOrDefault(o => o.IsApplicable());

            if (outcomeExporter == null)
                throw new Exception($"No applicable interaction engine found for type {ScopedTestContext?.RunnerType}");

            return outcomeExporter;
        }
    }
}