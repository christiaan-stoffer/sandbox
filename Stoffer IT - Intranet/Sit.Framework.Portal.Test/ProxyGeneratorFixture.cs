using System;
using NUnit.Framework;
using Sit.Framework.Portal.Dynamic;

namespace Sit.Framework.Portal.Test
{
    [TestFixture]
    public class ProxyGeneratorFixture
    {
        public interface ITestObject
        {
            string Name { get; set; }
        }

        public interface ITestObjectAdvanced
        {
            Guid Id { get; set; }

            string Name { get; set; }

            string Description { get; set; }

            int Order { get; set; }
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void InvalidProxyTest()
        {
            Proxy.New<string>();
        }

        [Test]
        public void ProxyTest()
        {
            var p = Proxy.New<ITestObject>();

            const string thisIsAName = "This is a name";

            p.Name = thisIsAName;

            Assert.AreEqual(thisIsAName, p.Name);
        }

        [Test]
        public void AdvancedProxyTest()
        {
            var p = Proxy.New<ITestObjectAdvanced>();

            p.Id = new Guid("D28AED59-C1BE-4A09-96BC-0B267AE522DA");
            p.Name = "Test";
            p.Order = 19382;
            p.Description = "This is a test object";

            Process(p);
        }

        private void Process(ITestObjectAdvanced testObjectAdvanced)
        {
            // TODO; :)
        }
    }
}
