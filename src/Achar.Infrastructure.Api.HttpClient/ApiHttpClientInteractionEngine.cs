using Achar.Domain.Testing;
using Achar.Domain.Testing.Enum;
using Achar.Interfaces;

namespace Achar.Infrastructure.Api.HttpClient
{
    public partial class ApiHttpClientInteractionEngine : IApiInteractionEngine
    {
        private ApiRequest _lastRequest;

        public bool IsApplicable(RunnerTypeEnum runnerType) => runnerType == RunnerTypeEnum.Api;
    }
}