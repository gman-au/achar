using System.Threading.Tasks;

namespace Achar.Interfaces
{
    public interface IApiInteractionAssertions
    {
        Task AssertResponseSucceededAsync();

        Task AssertResponseFailedAsync(int? expectedStatusCode = null);

        Task AssertJsonTokenPathValueEqualsAsync(
            string jsonTokenPath,
            string expectedValue
        );
    }
}