using System;
using System.Linq.Expressions;

namespace Achar.Domain.Testing
{
    public class ApiRequest
    {
        public string Method { get; set; }

        public Expression<Func<string>> Data { get; set; }

        public string Endpoint { get; set; }

        public override string ToString() => $"[method: {Method}, endpoint: {Endpoint}, data: \"{Data.Compile().Invoke()}\"]";
    }
}