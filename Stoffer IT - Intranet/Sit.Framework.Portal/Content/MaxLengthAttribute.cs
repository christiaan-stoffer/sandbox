using System;

namespace Sit.Framework.Portal.Content
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MaxLengthAttribute : Attribute, IPortalAttribute
    {
        public int Value
        {
            get; private set;
        }

        public MaxLengthAttribute(int value)
        {
            Value = value;
        }
    }
}