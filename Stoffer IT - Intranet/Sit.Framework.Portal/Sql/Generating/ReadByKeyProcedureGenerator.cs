using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sit.Framework.Portal.Sql.Generating
{
    public class ReadByKeyProcedureGenerator : IGenerator
    {
        public void GenerateSql(SqlEntityInfo entity, StringBuilder builder)
        {
            builder.AppendLine(string.Format("CREATE PROCEDURE [SP_{0}_ReadByKey]", entity.Name));

            IEnumerable<SqlPropertyInfo> keyProperties = entity.Properties.Where(property => property.IsKey).ToArray();

            var spParams = keyProperties.Select(CrudProcedureGeneratorsHelpers.ParseSqlPropertyInfoForProcedureParam);

            builder.AppendLine(string.Join(string.Format(",{0}", Environment.NewLine), spParams));

            builder.AppendLine("AS");
            builder.AppendLine("BEGIN");
            //builder.AppendLine("SET NOCOUNT ON");

            builder.AppendLine("SELECT");

            var spSelectColumns = entity.Properties.Select(property => string.Format("\t[{0}]", property.Name));

            builder.AppendLine(string.Join(string.Format(",{0}", Environment.NewLine), spSelectColumns));

            builder.AppendLine(string.Format("FROM [{0}]", entity.Name));
            builder.AppendLine("WHERE");

            var spChecks = keyProperties.Select(property => string.Format("[{0}] = @{0}", property.Name));

            builder.AppendLine(string.Join(string.Format(" AND {0}", Environment.NewLine), spChecks));

            builder.AppendLine();

            builder.AppendLine("END");
        }
    }
}