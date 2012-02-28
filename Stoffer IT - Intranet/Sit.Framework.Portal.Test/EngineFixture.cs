using System.Diagnostics;
using NUnit.Framework;
using Sit.Framework.Portal.Sql.Generating;
using Sit.Portal.DomainModel;

namespace Sit.Framework.Portal.Test
{
    [TestFixture]
    public class EngineFixture
    {
        [Test]
        public void GenerationTest()
        {
            var types = new[] {typeof (IAddress), typeof(IContact)};

            var engine = new SqlGenerationEngine();

            // Register output tracers.

            bool hadErrors = false;

            engine.Output += msg => Trace.WriteLine(msg);
            engine.Error += (msg, ex) =>
                                {
                                    hadErrors = true;
                                    Trace.WriteLine(msg);
                                    if (ex != null)
                                    {
                                        Trace.WriteLine(ex.Message);
                                        Trace.WriteLine(ex.StackTrace);
                                    }
                                };

            engine.Generate(types);

            if (!hadErrors)
            {
                Assert.Pass();
            }

            Assert.Fail("There were errors during generation.");
        }
    }

    [TestFixture]
    public class SqlPropertyMapFixture
    {
        [Test]
        public void GenerateMapTest()
        {
            var types = new[] { typeof(IAddress) };

            var map = SqlEntityMap.Generate(types);
        }
    }
}