namespace Achar.Domain.Testing.Exception
{
    public class ElementNotClickableException(
        LocationInstruction instruction,
        System.Exception innerException = null
    )
        : System.Exception($"Could not click element {instruction}", innerException);
}