using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class TaskEmployeesController : Controller
    {
        private task1Entities db = new task1Entities();

        // GET: TaskEmployees
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "Gender")
            {
                return View(db.TaskEmployees.Where(x => x.Gender.ToString() == "True" && search == "male" || x.Gender.ToString() == "False" && search == "female" || search == null).ToList());
            }
            else if (searchBy == "FirstName")
            {
                return View(db.TaskEmployees.Where(x => x.First_Name.StartsWith(search) || search == null).ToList());

            }
            else if (searchBy == "LastName")
            {
                return View(db.TaskEmployees.Where(x => x.Last_Name.StartsWith(search) || search == null).ToList());

            }
            else
            {
                return View(db.TaskEmployees.Where(x => x.Email.StartsWith(search) || search == null).ToList());

            }
        }
        //public void download()
        //{
        //    var imgPath = Server.MapPath("../image/cokdon.jfif");
        //    Response.AddHeader("Content-Disposition", "attachment;filename=DealerAdTemplate.png");
        //    Response.WriteFile(imgPath);
        //    Response.End();
        //}
        [HttpPost]
        public ActionResult Upload(TaskEmployee taskemployee, HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: TaskEmployees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskEmployee taskEmployee = db.TaskEmployees.Find(id);
            if (taskEmployee == null)
            {
                return HttpNotFound();
            }
            return View(taskEmployee);
        }

        // GET: TaskEmployees/Create



        // POST: TaskEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,First_Name,Last_Name,Email,Phone,Age,Job_Title,Gender")] TaskEmployee taskEmployee, HttpPostedFileBase image, HttpPostedFileBase cv)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    //string fileName = Path.GetFileName(image.FileName);
                    string path = Server.MapPath("~/image/") + image.FileName;
                    image.SaveAs(path);
                    taskEmployee.image = image.FileName;
                }

                if (cv != null)
                {
                    //string fileName = Path.GetFileName(cv.FileName);
                    string path = Server.MapPath("~/cv/") + cv.FileName;
                    cv.SaveAs(path);
                    taskEmployee.CV = cv.FileName;
                }
                db.TaskEmployees.Add(taskEmployee);
                db.SaveChanges();
                return View(taskEmployee);
            }

            else
            {
                return View(taskEmployee);

            }

        }

        // GET: TaskEmployees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskEmployee taskEmployee = db.TaskEmployees.Find(id);
            if (taskEmployee == null)
            {
                return HttpNotFound();
            }
            return View(taskEmployee);
        }

        // POST: TaskEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,First_Name,Last_Name,Email,Phone,Age,Job_Title,Gender,image,CV")] TaskEmployee taskEmployee, HttpPostedFileBase image, HttpPostedFileBase cv)
        {

            if (ModelState.IsValid)
            {
                db.Entry(taskEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taskEmployee);
        }

        // GET: TaskEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskEmployee taskEmployee = db.TaskEmployees.Find(id);
            if (taskEmployee == null)
            {
                return HttpNotFound();
            }
            return View(taskEmployee);
        }

        // POST: TaskEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskEmployee taskEmployee = db.TaskEmployees.Find(id);
            db.TaskEmployees.Remove(taskEmployee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
