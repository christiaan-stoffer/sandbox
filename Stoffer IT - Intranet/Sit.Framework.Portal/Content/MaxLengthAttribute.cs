using System;

namespace Sit.Framework.Portal.Content
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MaxLengthAttribute : Attribute, IPortalAttribute
    {
        public uint Value
        {
            get; private set;
        }

        public MaxLengthAttribute(uint value)
        {
            Value = value;
        }
    }
}