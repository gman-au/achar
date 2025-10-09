using System.Threading.Tasks;
using Achar.Domain.Testing;
using Achar.Domain.Testing.Enum;

namespace Achar.Interfaces.Testing
{
    public interface IScreenInteractionActions
    {
        Task ClickFocussedAsync();

        Task NavigateToHomePageAsync();

        Task NavigateToPathAsync(string path);

        Task SetFocussedAsync(LocationInstruction instruction);

        Task SetFocussedWithScrollAsync(LocationInstruction instruction);

        Task SendKeysToFocussedAsync(params KeyboardKeyEnum[] keys);

        Task SendKeysToFocussedAsync(string value);

        Task WaitForFocussedAsync(LocationInstruction instruction);

        Task FlingFocussedAsync(
            int x,
            int y
        );
    }
}