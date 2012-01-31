using System.Collections.Generic;
using Castle.DynamicProxy;

namespace Sit.Intranet.Model
{
    public class Item<TData>
    {
        internal Item()
        {
        }

        public TData Data
        {
            get; private set; 
        }
    }

    internal class SimpleWrapper
    {
        private Dictionary<string, object> _data;

        public SimpleWrapper()
        {
            _data = new Dictionary<string, object>();

            var d = typeof (ITest).GetMembers();

            

        }
    }


    interface ITest
    {
        string Name { get; set; }
    }
}
