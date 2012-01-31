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
    }
}
