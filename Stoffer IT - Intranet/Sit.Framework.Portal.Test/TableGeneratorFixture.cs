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

            GeneratorFixtureHelper.RunGenerator(map, gen);
        }
    }
}