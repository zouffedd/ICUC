using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProIcuc.Models;
using ProIcuc.Models.Examination;

namespace ProIcuc.Controllers
{
    public class CourseWorksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CourseWorks
        public ActionResult Index()
        {
            var courseWorks = db.CourseWorks.Include(c => c.Course);
            return View(courseWorks.ToList());
        }

        // GET: CourseWorks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseWork courseWork = db.CourseWorks.Find(id);
            if (courseWork == null)
            {
                return HttpNotFound();
            }
            return View(courseWork);
        }

        // GET: CourseWorks/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            return View();
        }

        // POST: CourseWorks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseWorkID,CourseID,Assignment1,OutOfAs1,Assignment2,OutOfAs2,Assignment3,OutOfAs3,Test1,OutOfTs1,Test2,OutOfTs2,CourseWorkRatio")] CourseWork courseWork)
        {
            if (ModelState.IsValid)
            {
                db.CourseWorks.Add(courseWork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", courseWork.CourseID);
            return View(courseWork);
        }

        // GET: CourseWorks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseWork courseWork = db.CourseWorks.Find(id);
            if (courseWork == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", courseWork.CourseID);
            return View(courseWork);
        }

        // POST: CourseWorks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseWorkID,CourseID,Assignment1,OutOfAs1,Assignment2,OutOfAs2,Assignment3,OutOfAs3,Test1,OutOfTs1,Test2,OutOfTs2,CourseWorkRatio")] CourseWork courseWork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseWork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", courseWork.CourseID);
            return View(courseWork);
        }

        // GET: CourseWorks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseWork courseWork = db.CourseWorks.Find(id);
            if (courseWork == null)
            {
                return HttpNotFound();
            }
            return View(courseWork);
        }

        // POST: CourseWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseWork courseWork = db.CourseWorks.Find(id);
            db.CourseWorks.Remove(courseWork);
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
