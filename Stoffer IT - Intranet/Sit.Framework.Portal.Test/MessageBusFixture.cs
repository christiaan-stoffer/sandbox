using NUnit.Framework;
using Sit.Framework.Portal.Bus;

namespace Sit.Framework.Portal.Test
{
    [TestFixture]
    public class MessageBusFixture
    {
        [Test]
        public void SimpleBusTest()
        {
            var bus = new MessageBus();

            bus.Subscribe<string>(s => Assert.Pass("Message received: " + s));

            bus.Publish("Hello world!");

            Assert.Fail("Should have been received by know...");
        }

        [Test]
        public void SimpleChannelBusTest()
        {
            var bus = new MessageBus();

            bus.Subscribe<string>("My channel", s => Assert.Fail("Because this subscribtion is on a channel, published messages without a channel specifier may not be catched by this subscriber."));

            bus.Publish("Hello world!");

            Assert.Pass();
        }

        [Test]
        public void MultiChannelBusTest()
        {
            var bus = new MessageBus();

            bus.Subscribe<string>("Channel 1", s => Assert.Fail("No message was published on this channel"));
            bus.Subscribe<string>("Channel 2", s => Assert.Pass("Message was published on this channel."));

            bus.Publish("ChanNeL 2", "Hello world!");

            Assert.Fail("Should have been received by know.");
        }
    }
}