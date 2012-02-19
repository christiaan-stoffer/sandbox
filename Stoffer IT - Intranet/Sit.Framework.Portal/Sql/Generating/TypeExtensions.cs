using System;
using System.Collections.Generic;
using System.Linq;

namespace Sit.Framework.Portal.Sql.Generating
{
    internal static class TypeExtensions
    {
        public static string GetEntityName(this Type t)
        {
            if (t == null)
            {
                return string.Empty;
            }

            var entityName = t.Name;

            return entityName.StartsWith("I") ? entityName.Substring(1) : entityName;
        }

        public static IEnumerable<Type> AllInterfaces(this Type t)
        {
            return new[] { t }.Concat(t.GetInterfaces());
        }
    }
}