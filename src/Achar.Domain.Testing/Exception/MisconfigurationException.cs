namespace Achar.Domain.Testing.Exception
{
    public class MisconfigurationException<T>(string message = null) : System.Exception(
        $"Configuration error; please check your configuration options for {typeof(T).Name}",
        new System.Exception(message));
}