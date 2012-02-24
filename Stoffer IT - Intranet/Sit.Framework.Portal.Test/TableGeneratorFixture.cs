using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Sit.Framework.Portal.Sql.Generating;
using Sit.Portal.DomainModel;

namespace Sit.Framework.Portal.Test
{
    [TestFixture]
    public class TableGeneratorFixture
    {
        [Test]
        public void SimpleGenerate()
        {
            var map = SqlEntityMap.Generate(typeof (IAddress));

            var gen = new TableGenerator();

            var builder = new StringBuilder();

            gen.GenerateSql(map.Entities.First(), builder);

            Trace.Write(builder);
        }
    }
}