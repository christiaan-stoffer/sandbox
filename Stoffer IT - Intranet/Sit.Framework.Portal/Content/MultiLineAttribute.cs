using System;

namespace Sit.Framework.Portal.Content
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MultiLineAttribute : Attribute, IPortalAttribute
    {   
    }
}