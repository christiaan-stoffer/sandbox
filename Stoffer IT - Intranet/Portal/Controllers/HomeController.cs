using System.Web.Mvc;
using Sit.Framework.Portal.Widgets;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var page = new WidgetPage
                           {
                               Panels = new []
                                            {
                                                GetLeft(), 
                                                GetCenter(), 
                                                GetRight()
                                            }
                           };


            ViewData.Model = page;

            return View();
        }

        private WidgetPanel GetRight()
        {
            var widgetPanel = new WidgetPanel();

            widgetPanel.Identifier = "Right";

            widgetPanel.Widgets = new[]
                                      {
                                          new WidgetInstance{Order = 1, Widget = new Widget()},
                                          new WidgetInstance{Order = 4, Widget = new Widget()},
                                          new WidgetInstance{Order = 2, Widget = new Widget()},
                                          new WidgetInstance{Order = 0, Widget = new Widget()},
                                          new WidgetInstance{Order = 3, Widget = new Widget()},
                                          new WidgetInstance{Order = 1, Widget = new Widget()},
                                      };

            return widgetPanel;
        }

        private WidgetPanel GetCenter()
        {
            var widgetPanel = new WidgetPanel();

            widgetPanel.Identifier = "Center";

            widgetPanel.Widgets = new[]
                                      {
                                          new WidgetInstance{Order = 1, Widget = new Widget()},
                                          new WidgetInstance{Order = 0, Widget = new Widget()},
                                          new WidgetInstance{Order = 3, Widget = new Widget()},
                                          new WidgetInstance{Order = 1, Widget = new Widget()},
                                      };

            return widgetPanel;
        }

        private WidgetPanel GetLeft()
        {
            var widgetPanel = new WidgetPanel();

            widgetPanel.Identifier = "Left";

            widgetPanel.Widgets = new[]
                                      {
                                          new WidgetInstance{Order = 1, Widget = new Widget()},
                                          new WidgetInstance{Order = 4, Widget = new Widget()},
                                          new WidgetInstance{Order = 2, Widget = new Widget()},
                                          new WidgetInstance{Order = 0, Widget = new Widget()},
                                          new WidgetInstance{Order = 3, Widget = new Widget()},
                                          new WidgetInstance{Order = 1, Widget = new Widget()},
                                      };

            return widgetPanel;
        }
    }
}
