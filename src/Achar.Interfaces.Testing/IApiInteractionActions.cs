using System.Threading.Tasks;

namespace Achar.Interfaces.Testing
{
    public interface IApiInteractionActions
    {
        Task CreateRequestAsync(string endpoint);

        Task SendRequestAsync(string method);

        Task SetRequestHeaderValueAsync(
            string headerKey,
            string headerValue
        );

        Task SetRequestBodyValueAsync(
            string jsonTokenPath,
            string value
        );
    }
}