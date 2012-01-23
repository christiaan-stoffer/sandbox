using System;
using System.Web.Mvc;

namespace Intranet.Helpers
{
    public static class WidgetHelper
    {
        public static IDisposable BeginWidget(this HtmlHelper helper, string title = "")
        {
            return new WidgetHtml(helper, title);
        }
    }

    public class WidgetHtml : IDisposable
    {
        private HtmlHelper _helper;
        private string _title;

        public WidgetHtml(HtmlHelper helper, string title)
        {
            _helper = helper;
            _title = title;

            _helper.ViewContext.Writer.Write("<div class=\"widget\">");
            _helper.ViewContext.Writer.Write("<div class=\"inner\">");

            if (string.IsNullOrEmpty(_title))
            {
                return;
            }

            _helper.ViewContext.Writer.Write("<div class=\"title\">");
            _helper.ViewContext.Writer.Write(_title);
            _helper.ViewContext.Writer.Write("</div>");
        }

        public void Dispose()
        {
            _helper.ViewContext.Writer.Write("</div>");
            _helper.ViewContext.Writer.Write("</div>");
        }
    }
}