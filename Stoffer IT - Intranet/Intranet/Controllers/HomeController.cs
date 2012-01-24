using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intranet.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HandleUpload(HttpPostedFileBase postedFile)
        {
            var name = postedFile.FileName.Split('\\').LastOrDefault();


            using (var streamWriter = new StreamWriter(@"C:\upload\" +  name))
            {
                using (Stream stream = postedFile.InputStream)
                {
                    stream.CopyTo(streamWriter.BaseStream);
                }
            }

            return Redirect("~/");
        }
    }
}