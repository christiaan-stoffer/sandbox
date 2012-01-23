using System.IO;
using System.Web;

namespace Intranet.Handlers
{
    public class ImageHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/png";

            using (var s = new StreamReader(@"C:\test.png"))
            {
                s.BaseStream.CopyTo(context.Response.OutputStream);
            }
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }

    public class ImageHelper
    {
    }
}