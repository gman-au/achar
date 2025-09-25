using Achar.Domain.Testing.Enum;

namespace Achar.Interfaces
{
    public interface IKeyboardKeyMapper
    {
        string ToKeyString(KeyboardKeyEnum value);

        string ToKeyString(char value);
    }
}