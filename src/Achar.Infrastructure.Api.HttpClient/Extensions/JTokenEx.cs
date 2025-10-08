using System.Linq;
using Newtonsoft.Json.Linq;

namespace Achar.Infrastructure.Api.HttpClient.Extensions
{
    internal static class JTokenEx
    {
        public static void SetJObject(
            this JObject m,
            string path,
            object value)
        {
            JToken o = m;

            var p =
                path
                    .Split('.')
                    .ToList();

            for (var i = 0; i < p.Count - 1; i++)
            {
                var name = p[i];
                var j = o[name];

                if (j == null)
                    o[name] = j = new JObject();

                o = j;
            }

            o[p[^1]] =
                JToken
                    .FromObject(value);
        }
    }
}