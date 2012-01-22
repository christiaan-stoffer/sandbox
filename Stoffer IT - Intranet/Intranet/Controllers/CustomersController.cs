using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Intranet.Model;

namespace Intranet.Controllers
{
    public class CustomersController : Controller
    {
        //
        // GET: /Customers/

        public ActionResult Index()
        {
            var randomLinks = Enumerable.Range(0, 34).Select(itm => new ImageCustomerLink { ImageUrl = "http://www.google.com/images/srpr/logo3w.png", Name = "Klant " + itm, Url = "#"});

            
            return View(new CustomerOverview<ImageCustomerLink>
                          {
                              Customers = randomLinks
                          });
        }

    }
}
