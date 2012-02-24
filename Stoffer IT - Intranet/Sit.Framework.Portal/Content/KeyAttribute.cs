using System;

namespace Sit.Framework.Portal.Content
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal class KeyAttribute : Attribute, IPortalAttribute
    {
        
    }
}