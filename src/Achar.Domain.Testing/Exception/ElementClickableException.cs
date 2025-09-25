namespace Achar.Domain.Testing.Exception
{
    public class ElementClickableException(
        LocationInstruction instruction,
        System.Exception innerException = null
    )
        : System.Exception($"Could unexpectedly click element {instruction}", innerException);
}