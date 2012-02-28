using System.Diagnostics;
using System.Linq;
using System.Text;
using Sit.Framework.Portal.Sql.Generating;

namespace Sit.Framework.Portal.Test
{
    public static class GeneratorFixtureHelper
    {
        public static void RunGenerator(SqlEntityMap map, IGenerator gen)
        {
            var builder = new StringBuilder();

            gen.GenerateSql(map.Entities.First(), builder);

            Trace.Write(builder);
        }
    }
}