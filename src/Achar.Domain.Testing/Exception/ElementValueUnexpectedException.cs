namespace Achar.Domain.Testing.Exception
{
    public class ElementValueUnexpectedException(
        string expected,
        string actual,
        LocationInstruction instruction
    )
        : System.Exception($"Value for element {instruction}, [expected: '{expected}', actual: '{actual}']");
}