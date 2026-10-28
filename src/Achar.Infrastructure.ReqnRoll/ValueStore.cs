using System.Collections.Generic;
using Achar.Interfaces.Testing;

namespace Achar.Infrastructure.ReqnRoll
{
    public class ValueStore : IValueStore
    {
        private readonly Dictionary<string, string> _dictionary = new();

        public void SetValue(
            string key,
            string value
        )
        {
            _dictionary[key] = value;
        }

        public string GetValue(
            string key
        )
        {
            return
                _dictionary
                    .TryGetValue(
                        key,
                        out var value
                    )
                    ? value
                    : null;
        }
    }
}