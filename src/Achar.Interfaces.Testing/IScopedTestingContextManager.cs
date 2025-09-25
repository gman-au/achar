namespace Achar.Interfaces.Testing
{
    public interface IScopedTestingContextManager
    {
        IScreenInteractionEngine GetScreenInteractionEngine();

        IApiInteractionEngine GetApiInteractionEngine();
    }
}