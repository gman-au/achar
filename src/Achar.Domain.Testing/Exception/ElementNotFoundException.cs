namespace Achar.Domain.Testing.Exception
{
    public class ElementNotFoundException(
        LocationInstruction instruction,
        System.Exception innerException = null
    )
        : System.Exception($"Could not find element {instruction}", innerException);
}