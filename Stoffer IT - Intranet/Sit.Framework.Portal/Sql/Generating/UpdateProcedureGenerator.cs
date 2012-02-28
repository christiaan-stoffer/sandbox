using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sit.Framework.Portal.Sql.Generating
{
    public class UpdateProcedureGenerator : IGenerator
    {
        public void GenerateSql(SqlEntityInfo entity, StringBuilder builder)
        {
            builder.AppendLine(string.Format("CREATE PROCEDURE [SP_{0}_Update]", entity.Name));

            IEnumerable<SqlPropertyInfo> allProperties = entity.Properties.ToArray();

            var spParams = allProperties.Select(CrudProcedureGeneratorsHelpers.ParseSqlPropertyInfoForProcedureParam);

            builder.AppendLine(string.Join(string.Format(",{0}", Environment.NewLine), spParams));

            builder.AppendLine("AS");
            builder.AppendLine("BEGIN");
            //builder.AppendLine("SET NOCOUNT ON");

            builder.AppendLine(string.Format("UPDATE [{0}]", entity.Name));
            builder.AppendLine("SET");

            var spTableColumns =
                allProperties.Where(property=>!property.IsKey)
                .Select(property => string.Format("\t[{0}] = @{0}", property.Name));

            builder.AppendLine(string.Join(string.Format(",{0}", Environment.NewLine), spTableColumns));
            
            builder.AppendLine("WHERE");

            var keyProperty = entity.Properties.First(property => property.IsKey);

            builder.AppendLine(string.Format("[{0}] = @{0}", keyProperty.Name));

            builder.AppendLine("END");
        }
    }
}