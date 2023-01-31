using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class lubna : Controller
    {
        // GET: Default1
        public ActionResult Index()
        {
            return View();
        }
        public string name()
        {
            return "lubna";
        }

        public string city()
        {
            return "jordan";
        }

        public string age()
        {
            return "23 year";
        }

        public string email()
        {
            return "lubna.ajlouni@yahoo.com";
        }

    }
}