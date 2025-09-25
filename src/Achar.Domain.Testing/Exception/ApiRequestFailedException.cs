namespace Achar.Domain.Testing.Exception
{
    public class ApiRequestFailedException(
        ApiRequest request,
        System.Exception innerException = null
    )
        : System.Exception($"API request {request}", innerException);
}