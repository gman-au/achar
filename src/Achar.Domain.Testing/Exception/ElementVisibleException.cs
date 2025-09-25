namespace Achar.Domain.Testing.Exception
{
    public class ElementVisibleException(
        LocationInstruction instruction,
        System.Exception innerException = null
    )
        : System.Exception($"Element {instruction} unexpectedly visible", innerException);
}