using System;
using System.Linq;
using System.Reflection;
using System.Text;
using Sit.Framework.Portal.Content;

namespace Sit.Framework.Portal.Sql.Generating
{
    public class TableGenerator : IGenerator
    {
        public void GenerateSql(SqlEntityInfo entityInfo, StringBuilder builder)
        {
            builder.AppendLine(string.Format("CREATE TABLE [{0}] (", entityInfo.Name));

            var fields = entityInfo.Properties.Select(prop =>
            {
                var nullableText = string.Empty;

                if (prop.IsNullable)
                {
                    nullableText = " NOT NULL";
                }
                
                var typeExtra = string.Empty;

                if (prop.Length != Length.Empty)
                {
                    typeExtra = prop.Length == Length.Max ? "(MAX)" : string.Format("({0})", prop.Length);
                }

                string identity = string.Empty;

                if (prop.IsKey)
                {
                    identity = " IDENTITY(1,1)";
                }

                return string.Format("\t[{0}] [{1}]{2}{3}{4}", prop.Name, prop.DbType, typeExtra, identity, nullableText);
            });

            builder.AppendLine(string.Join(string.Format(",{0}", Environment.NewLine), fields) + ",");

            builder.AppendLine("CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED");
            builder.AppendLine("(");
            builder.AppendLine("[Key] ASC");
            builder.AppendLine(")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]");
            builder.AppendLine(") ON [PRIMARY]");
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
