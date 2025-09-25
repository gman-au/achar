namespace Achar.Domain.Testing.Exception
{
    public class ApiResponseValueUnexpectedException(
        string path,
        string expected,
        string actual,
        ApiRequest request
    )
        : System.Exception($"Response for request {request}, path '{path}' [expected: '{expected}', actual: '{actual}']");
}