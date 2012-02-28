using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sit.Framework.Portal.Sql.Generating
{
    public class DeleteProcedureGenerator : IGenerator
    {
        public void GenerateSql(SqlEntityInfo entity, StringBuilder builder)
        {
            builder.AppendLine(string.Format("CREATE PROCEDURE [SP_{0}_Delete]", entity.Name));

            IEnumerable<SqlPropertyInfo> keyProperties = entity.Properties.Where(property=>property.IsKey).ToArray();

            var spParams = keyProperties.Select(ParseSqlPropertyInfoForProcedureParam);

            builder.AppendLine(string.Join(string.Format(",{0}", Environment.NewLine), spParams));

            builder.AppendLine("AS");
            builder.AppendLine("BEGIN");
            //builder.AppendLine("SET NOCOUNT ON");

            builder.AppendLine(string.Format("DELETE FROM [{0}]", entity.Name));
            builder.AppendLine("WHERE");

            var spChecks = keyProperties.Select(property => string.Format("[{0}] = @{0}", property.Name));

            builder.AppendLine(string.Join(string.Format(" AND {0}", Environment.NewLine), spChecks));

            builder.AppendLine();

            builder.AppendLine("END");
        }

        private static string ParseSqlPropertyInfoForProcedureParam(SqlPropertyInfo property)
        {
            string nullableText, typeExtra;

            nullableText = null;
            typeExtra = null;

            if (property.Length != Length.Empty)
            {
                typeExtra = property.Length == Length.Max
                                ? "(MAX)"
                                : string.Format(
                                    "({0})",
                                    property.Length);
            }

            if (property.IsNullable)
            {
                nullableText = " = NULL";
            }

            return
                string.Format(
                    "\t@{0} {1}{2}{3}",
                    property.Name, property.DbType, typeExtra,
                    nullableText);
        }
    }
}