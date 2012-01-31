using System;
using System.Diagnostics;
using System.Linq;
using Castle.DynamicProxy;
using NUnit.Framework;

namespace Sit.Intranet.Model.Test
{
    [TestFixture]
    public class ObjectCreationFixture
    {
        private const int NumberOfObjects = 5000000;

        [Test]
        public void ProxyTest()
        {
            DoWork(CreateProxies);
            DoWork(CreateObjects);
            DoWork(CreateProxiesWithLinq);
            DoWork(CreateObjectsWithLinq);
        }

        private static void DoWork(Action a)
        {
            var ticks1 = DateTime.Now.Ticks;
            a();
            Trace.WriteLine("Miliseconds: " + new TimeSpan(DateTime.Now.Ticks - ticks1).TotalMilliseconds);
        }

        private static void CreateProxies()
        {
            Trace.WriteLine("Proxies...");

            ProxyGenerator p = new ProxyGenerator();

            for (var i = 0; i < NumberOfObjects; i++)
            {
                p.CreateInterfaceProxyWithoutTarget<IProduct>();
            }
        }

        private void CreateObjects()
        {
            Trace.WriteLine("Objects...");
            for (var i = 0; i < NumberOfObjects; i++)
            {
                new Product();
            }
        }

        private void CreateProxiesWithLinq()
        {
            Trace.WriteLine("Proxies with linq...");

            ProxyGenerator p = new ProxyGenerator();

            Enumerable.Range(0, NumberOfObjects).Select(i => p.CreateInterfaceProxyWithoutTarget<IProduct>()).ToArray();
        }

        private void CreateObjectsWithLinq()
        {
            Trace.WriteLine("Objects with linq...");

            Enumerable.Range(0, NumberOfObjects).Select(i =>new Product()).ToArray();
        }
    }

    public class Product : IProduct
    {
        public string Name
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string Description
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}