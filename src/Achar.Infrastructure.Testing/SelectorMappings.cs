using System.Collections.Generic;
using Achar.Domain.Testing.Enum;

namespace Achar.Infrastructure.Testing
{
    internal static class SelectorMappings
    {
        internal static readonly Dictionary<string, ElementSelectTypeEnum> Selectors =
            new()
            {
                { "text", ElementSelectTypeEnum.ByText },
                { "title", ElementSelectTypeEnum.ByTitle },
                { "test-id", ElementSelectTypeEnum.ByDataTestId },
                { "name", ElementSelectTypeEnum.ByName },
                { "placeholder", ElementSelectTypeEnum.ByPlaceholder },
                { "xref", ElementSelectTypeEnum.ByXref },
                { "value", ElementSelectTypeEnum.ByValue },
                { "target", ElementSelectTypeEnum.ByTarget },
                { "class", ElementSelectTypeEnum.ByClass },
                { "id", ElementSelectTypeEnum.ById }
            };
    }
}