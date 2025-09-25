using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Achar.Infrastructure.Testing.Extensions
{
    public static class ExpressionUtil
    {
        public static Expression<Func<T, object>> GenerateMemberExpression<T>(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return o => null;

            return ToLambda<T>(propertyName);
        }

        private static Expression<Func<T, object>> ToLambda<T>(string propertyName)
        {
            var parameter =
                Expression
                    .Parameter(
                        typeof(T),
                        "c"
                    );

            Expression current = parameter;
            var currentType = typeof(T);

            foreach (var part in propertyName.Split('.'))
            {
                var prop =
                    currentType
                        .GetProperty(
                            part,
                            BindingFlags.Instance | BindingFlags.Public
                        );

                if (prop == null)
                    throw new Exception($"Property {propertyName} does not exist for type {typeof(T)}");

                var selector =
                    Expression
                        .Property(
                            current,
                            part
                        );

                current = selector;
                currentType = prop.PropertyType;
            }

            var conversion =
                Expression
                    .Convert(
                        current,
                        typeof(object)
                    );

            return
                Expression
                    .Lambda<Func<T, object>>(
                        conversion,
                        parameter
                    );
        }
    }
}