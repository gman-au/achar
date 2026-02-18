using System;

namespace Achar.Infrastructure.ReqnRoll.Extensions
{
    internal static class StringEx
    {
        public static object ParseValueAs(this string value, string dataType)
        {
            return dataType.ToLower() switch
            {
                "bool" or "boolean" => bool.Parse(value),
                "int" or "int32"    => int.Parse(value),
                "long" or "int64"   => long.Parse(value),
                "float" or "single" => float.Parse(value),
                "double"            => double.Parse(value),
                "decimal"           => decimal.Parse(value),
                "char"              => char.Parse(value),
                "byte"              => byte.Parse(value),
                "short" or "int16"  => short.Parse(value),
                "string"            => value,
                _ => throw new ArgumentException($"Unsupported data type: '{dataType}'")
            };
        }
    }
}