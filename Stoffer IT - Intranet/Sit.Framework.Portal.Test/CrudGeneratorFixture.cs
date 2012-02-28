using NUnit.Framework;
using Sit.Framework.Portal.Sql.Generating;
using Sit.Portal.DomainModel;

namespace Sit.Framework.Portal.Test
{
    [TestFixture]
    public class CrudGeneratorFixture
    {
        [Test]
        public void CreateProcedureGenerateTest()
        {
            var map = SqlEntityMap.Generate(typeof (IAddress));

            var gen = new CreateProcedureGenerator();

            GeneratorFixtureHelper.RunGenerator(map, gen);
        }

        [Test]
        public void UpdateProcedureGenerateTest()
        {
            var map = SqlEntityMap.Generate(typeof(IAddress));

            var gen = new UpdateProcedureGenerator();

            GeneratorFixtureHelper.RunGenerator(map, gen);
        }

        [Test]
        public void DeleteProcedureGenerateTest()
        {
            var map = SqlEntityMap.Generate(typeof(IAddress));

            var gen = new DeleteProcedureGenerator();

            GeneratorFixtureHelper.RunGenerator(map, gen);
        }
    }
}