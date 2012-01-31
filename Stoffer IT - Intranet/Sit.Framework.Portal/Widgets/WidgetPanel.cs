using System.Collections.Generic;

namespace Sit.Framework.Portal.Widgets
{
    public class WidgetPanel
    {
        public string Identifier { get; set; }

        public IEnumerable<WidgetInstance> Widgets { get; set; }
    }
}