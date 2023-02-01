using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task2mvc.Models;

namespace task2mvc.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
      

        public ActionResult show()
        {
            List<Models.student> students = new List<Models.student>();

            students.Add(new Models.student() { ID = 1, Name = "lubna", Major = "PlantProduction", Faculty = "Agricultural", });
            students.Add(new Models.student() { ID = 2, Name = "nesreen", Major = "SoftwareEngineering", Faculty = "IT", });
            students.Add(new Models.student() { ID = 2, Name = "Weesam", Major = "CivialEngineering", Faculty = "Engineering", });

            return View(students);
        }

    }
}