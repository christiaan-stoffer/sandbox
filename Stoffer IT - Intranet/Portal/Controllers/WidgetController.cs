using System.Web.Mvc;
using Sit.Framework.Portal.Widgets;

namespace Portal.Controllers
{
    public class WidgetController : Controller
    {
        public ActionResult GetWidget(Widget widget)
        {
            return PartialView("TestWidget", widget.WidgetData);
        }
    }
}
