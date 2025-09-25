using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using Achar.Domain.Testing.Enum;

namespace Achar.Infrastructure.Testing.Extensions
{
    public static class StringEx
    {
        public static HttpMethod ToHttpMethod(this string methodString)
        {
            switch (methodString.ToUpper())
            {
                case "GET": return HttpMethod.Get;
                case "POST": return HttpMethod.Post;
                case "DELETE": return HttpMethod.Delete;
                case "PATCH": return HttpMethod.Patch;
                case "PUT": return HttpMethod.Put;
                case "TRACE": return HttpMethod.Trace;
                case "CONNECT": return HttpMethod.Connect;
                case "HEAD": return HttpMethod.Head;
                case "OPTIONS": return HttpMethod.Options;
                default: throw new Exception($"HTTP method {methodString} is not supported");
            }
        }

        public static ElementSelectTypeEnum ToEnum(this string byString)
        {
            if (!SelectorMappings.Selectors.TryGetValue(byString, out var byEnum))
                throw new Exception(
                    $"Invalid selector [{byString}]; value values are [{string.Join(", ", SelectorMappings.Selectors.Keys)}]"
                );

            return byEnum;
        }

        public static int ExtractZeroBasedIndex(this string value)
        {
            if (string.Equals(value, "last", StringComparison.InvariantCultureIgnoreCase))
                return -1;

            var regex = new Regex("[0-9]*");
            if (!regex.IsMatch(value)) return 0;

            var result =
                regex
                    .Match(value);

            if (int.TryParse(
                    result.Value,
                    out var index
                ))
                return index - 1;

            return 0;
        }
    }
}