namespace Achar.Domain.Testing.Exception
{
    public class PathNotFoundException(
        string path,
        System.Exception innerException = null
    )
        : System.Exception($"Path {path} not found or defined", innerException);
}