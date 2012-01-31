using System;
using System.Collections.Generic;
using System.Linq;

namespace Sit.Framework.Portal.Widgets
{
    public class WidgetPage
    {
        public IEnumerable<WidgetPanel> Panels { get; set; }

        public WidgetPanel this[string panelIdentifer]
        {
            get 
            { 
                var pnl = Panels.FirstOrDefault(panel => panel.Identifier == panelIdentifer);

                if (pnl == null)
                {
                    throw new ArgumentOutOfRangeException("panelIdentifer",
                                                          "Could not find a panel with that identifier");
                }

                return pnl;
            }
        }
    }
}