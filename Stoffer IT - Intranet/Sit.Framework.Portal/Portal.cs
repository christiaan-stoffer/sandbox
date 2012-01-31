namespace Sit.Framework.Portal
{
    public class PortalContext
    {
        public string Name { get; set; }

        public PortalContext(string name)
        {
            Name = name;
        }

        public static PortalContext Load(string portalName)
        {
            return new PortalContext(portalName);
        }
    }
}
