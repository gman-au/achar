using System;
using System.Text.RegularExpressions;
using Achar.Domain.Testing.Enum;
using Achar.Interfaces.Testing;

namespace Achar.Infrastructure.Appium.Android
{
    public class AppiumKeyboardKeyMapper : IKeyboardKeyMapper
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

        public string ToKeyString(char value)
        {
            var lowerValue = char.ToLower(value);
            if (new Regex("[a-z]").IsMatch(lowerValue.ToString()))
                return (lowerValue - 68).ToString();

            if (new Regex("[0-9]").IsMatch(lowerValue.ToString()))
                return (lowerValue - 41).ToString();

            if (new Regex("\\ ").IsMatch(lowerValue.ToString()))
                return 62.ToString();

            throw new NotImplementedException($"Key mapping for {value} not implemented");
        }
    }
}