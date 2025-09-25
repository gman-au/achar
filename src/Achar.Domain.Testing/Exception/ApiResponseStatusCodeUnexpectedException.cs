namespace Achar.Domain.Testing.Exception
{
    public class ApiResponseStatusCodeUnexpectedException(
        int? expected,
        int actual,
        ApiRequest request
    )
        : System.Exception(
            $"HTTP Status code for request {request}, [expected: '{(expected.HasValue ? expected.Value : "failure")}', actual: '{actual}']");
}