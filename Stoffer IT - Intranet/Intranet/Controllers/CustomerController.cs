using System.IO;
using System.Web.Mvc;

namespace Intranet.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index(string name)
        {
            ViewBag.RawName = name;

            return View();
        }

        public ActionResult GetFile(string name, string filepath)
        {
            using (var s = new FileStream("C:\\test.png", FileMode.Open))
            {
                var contents = new byte[s.Length];

                s.Read(contents, 0, (int) s.Length);

                return new FileContentResult(contents, "image/png");
            }
        }
    }
}