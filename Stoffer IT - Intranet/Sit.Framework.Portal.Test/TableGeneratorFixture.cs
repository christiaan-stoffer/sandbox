using System.Diagnostics;
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
            var gen = Generator.For<IAddress>(GeneratorType.Table);

            var builder = new StringBuilder();

            gen.GenerateSql(builder);

            Trace.Write(builder.ToString());
        }
    }
}