using System;
using Achar.Domain.Testing.Enum;
using Achar.Interfaces.Testing;

namespace Achar.Infrastructure.Testing
{
    public class KeyboardKeyMapper : IKeyboardKeyMapper
    {
        public string ToKeyString(KeyboardKeyEnum value)
        {
            return value switch
            {
                KeyboardKeyEnum.DownArrow => "ArrowDown",
                KeyboardKeyEnum.Enter => "Enter",
                KeyboardKeyEnum.Tab => "Tab",
                KeyboardKeyEnum.Space => "Space",
                _ => throw new NotImplementedException($"Key mapping for {value} not implemented")
            };
        }

        public string ToKeyString(char value) => throw new NotImplementedException();
    }
}