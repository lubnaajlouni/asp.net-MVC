using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public string About()
        {
            return "about us";
        }

        public string Contact()
        {
            return  "contact";
        }

        public string showimage()

        { return "<a href=\"DownloadImage\"><img src=\"../img/oo.jpg\"> <a/>";  }

        public FileResult DownloadImage()
        {
            var filePath = Server.MapPath("~/img/" + "oo.jpg");
            return File(filePath, "image/jpeg", "oo.jpg");

           
        }
    }
}