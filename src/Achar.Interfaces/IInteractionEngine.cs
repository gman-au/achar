using System.Threading.Tasks;
using Achar.Domain.Testing.Enum;

namespace Achar.Interfaces
{
    public interface IInteractionEngine
    {
        bool IsApplicable(RunnerTypeEnum runnerType);

        Task WaitSecondsAsync(int seconds);
    }
}