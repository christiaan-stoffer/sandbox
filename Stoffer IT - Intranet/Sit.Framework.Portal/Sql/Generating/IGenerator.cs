using System.Text;

namespace Sit.Framework.Portal.Sql.Generating
{
    public interface IGenerator
    {
        void GenerateSql(StringBuilder builder);
    }
}