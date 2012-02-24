using System.Text;

namespace Sit.Framework.Portal.Sql.Generating
{
    public interface IGenerator
    {
        void GenerateSql(SqlEntityInfo entity, StringBuilder builder);
    }
}