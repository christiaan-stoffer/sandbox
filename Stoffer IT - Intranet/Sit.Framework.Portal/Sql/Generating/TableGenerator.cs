using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sit.Framework.Portal.Sql.Generating
{
    public class TableGenerator : IGenerator
    {
        #region IGenerator Members

        public void GenerateSql(SqlEntityInfo entityInfo, StringBuilder builder)
        {
            builder.AppendLine(string.Format("CREATE TABLE [{0}] (", entityInfo.Name));

            IEnumerable<string> fields = entityInfo.Properties.Select(ParseProperty);

            builder.Append(string.Join(string.Format(",{0}", Environment.NewLine), fields));
            builder.AppendLine(",");
            builder.AppendLine("CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED");
            builder.AppendLine("(");
            builder.AppendLine("[Key] ASC");
            builder.AppendLine(
                ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]");
            builder.AppendLine(") ON [PRIMARY]");
        }

        #endregion

        private static string ParseProperty(SqlPropertyInfo prop)
        {
            string nullableText = string.Empty;

            if (prop.IsNullable)
            {
                nullableText = " NOT NULL";
            }

            string typeExtra = string.Empty;

            if (prop.Length != Length.Empty)
            {
                typeExtra = prop.Length == Length.Max
                                ? "(MAX)"
                                : string.Format(
                                    "({0})",
                                    prop.Length);
            }

            string identity = string.Empty;

            if (prop.IsKey)
            {
                identity = " IDENTITY(1,1)";
            }

            return
                string.Format(
                    "\t[{0}] [{1}]{2}{3}{4}",
                    prop.Name, prop.DbType, typeExtra,
                    identity, nullableText);
        }
    }
}