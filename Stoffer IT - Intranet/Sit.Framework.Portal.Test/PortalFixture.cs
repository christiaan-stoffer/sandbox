using NUnit.Framework;

namespace Sit.Framework.Portal.Test
{
    [TestFixture]
    public class PortalFixture
    {
        [Test]
        public void PortalTest()
        {
            string portalName = "My portal";

            var portal = PortalContext.Load(portalName);

            Assert.IsNotNull(portal);
            Assert.AreEqual(portalName, portal.Name);
        }
    }
}
