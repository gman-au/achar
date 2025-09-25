namespace Achar.Domain.Testing.Exception
{
    public class ElementNotVisibleException(
        LocationInstruction instruction,
        System.Exception innerException = null
    )
        : System.Exception($"Element {instruction} not visible", innerException);
}