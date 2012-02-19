using System;
using System.Linq;
using System.Reflection;
using System.Text;
using Sit.Framework.Portal.Content;

namespace Sit.Framework.Portal.Sql.Generating
{
    public class TableGenerator : GeneratorBase, IGenerator
    {
        public const int DefaultNVarcharMaxLength = 50;

        public TableGenerator(Type typeForGenerating) : base(typeForGenerating)
        {
        }

        public void GenerateSql(StringBuilder builder)
        {
            builder.AppendLine(string.Format("CREATE TABLE [{0}] (", TypeForGenerating.GetEntityName()));

            var fields = TypeForGenerating.AllInterfaces().SelectMany(t=>t.GetProperties()).Select(prop =>
            {
                bool needsLengthSpecified;
                var dbType = GetDbType(prop, out needsLengthSpecified);

                var nullableText = string.Empty;

                var attrs = prop.GetCustomAttributes(typeof(IPortalAttribute), true);

                var type = prop.PropertyType;

                if ((!type.IsGenericType || type.GetGenericTypeDefinition() != typeof (Nullable<>)) &&
                    !attrs.OfType<NullableAttribute>().Any())
                {
                    nullableText = " NOT NULL";
                }
                
                var typeExtra = string.Empty;

                if (needsLengthSpecified)
                {
                    if (attrs.OfType<MultiLineAttribute>().Any())
                    {
                        typeExtra = "(MAX)";
                    }

                    if (attrs.OfType<MaxLengthAttribute>().Any())
                    {
                        typeExtra = string.Format("({0})", attrs.OfType<MaxLengthAttribute>().First().Value);
                    }

                    if (typeExtra.Length == 0)
                    {
                        typeExtra = string.Format("({0})", DefaultNVarcharMaxLength);
                    }
                }

                return string.Format("\t[{0}] [{1}]{2}{3}", prop.Name, dbType, typeExtra, nullableText);
            });

            builder.AppendLine(string.Join(string.Format(",{0}", Environment.NewLine), fields));

            builder.AppendLine(")");
        }

        private static string GetDbType(PropertyInfo prop, out bool needsLengthSpecified)
        {
            var t = prop.PropertyType;
            needsLengthSpecified = false;

            if (t == typeof(string))
            {
                needsLengthSpecified = true;
                return string.Format("nvarchar");
            }

            if (t == typeof(DateTime))
            {
                return "DateTime2";
            }

            if (t == typeof(int))
            {
                return "int";
            }

            if (t == typeof(Guid))
            {
                return "uniqueidentifier";
            }

            throw new NotSupportedException(string.Format("Type '{0}' not supported (yet).", t.FullName));
        }
    }
}
