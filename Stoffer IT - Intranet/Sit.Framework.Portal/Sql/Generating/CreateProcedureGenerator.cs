using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sit.Framework.Portal.Sql.Generating
{
    public class CreateProcedureGenerator : IGenerator
    {
        public void GenerateSql(SqlEntityInfo entity, StringBuilder builder)
        {
            builder.AppendLine(string.Format("CREATE PROCEDURE [SP_{0}_Create]", entity.Name));

            IEnumerable<SqlPropertyInfo> sqlPropertyInfosNoKey = entity.Properties.Where(p => !p.IsKey).ToArray();

            var spParams = sqlPropertyInfosNoKey.Select(CrudProcedureGeneratorsHelpers.ParseSqlPropertyInfoForProcedureParam);

            builder.AppendLine(string.Join(string.Format(",{0}", Environment.NewLine), spParams));

            builder.AppendLine("AS");
            builder.AppendLine("BEGIN");
            //builder.AppendLine("SET NOCOUNT ON");

            builder.AppendLine(string.Format("INSERT INTO [{0}]", entity.Name));
            builder.AppendLine("(");

            var spTableColumns =
                sqlPropertyInfosNoKey.Select(property => string.Format("\t[{0}]", property.Name));

            builder.AppendLine(string.Join(string.Format(",{0}", Environment.NewLine), spTableColumns));

            builder.AppendLine(")");

            builder.AppendLine("VALUES");

            builder.AppendLine("(");

            var spParamValueReferences =
                sqlPropertyInfosNoKey.Select(property => string.Format("\t@{0}", property.Name));
            builder.AppendLine(string.Join(string.Format(",{0}", Environment.NewLine), spParamValueReferences));

            builder.AppendLine(")");

            builder.AppendLine("END");
        }
    }
}