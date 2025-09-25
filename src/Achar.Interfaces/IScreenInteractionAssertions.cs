using System.Threading.Tasks;

namespace Achar.Interfaces
{
    public interface IScreenInteractionAssertions
    {
        Task AssertClickableAsync();

        Task AssertNotClickableAsync();

        Task AssertVisibleAsync();

        Task AssertNotVisibleAsync();

        Task AssertEqualAsync(string expected);

        Task AssertCurrentPathAsync(string expectedPath);
    }
}