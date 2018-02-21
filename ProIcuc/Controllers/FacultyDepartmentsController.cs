using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProIcuc.Models;
using ProIcuc.Models.Academics;

namespace ProIcuc.Controllers
{
    public class FacultyDepartmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FacultyDepartments
        public ActionResult Index()
        {
            var facultyDepartments = db.FacultyDepartments.Include(f => f.Faculty);
            return View(facultyDepartments.ToList());
        }
        public ActionResult Index(int? pageNumber)
{
    FacultyDepartment model = new FacultyDepartment();
    model.PageNumber = (pageNumber == null ? 1 : Convert.ToInt32(pageNumber));
    model.PageSize = 4;

            var facultyDepartments = db.FacultyDepartments.ToList();

    if (facultyDepartments != null)
    {

        var Program=facultyDepartments.OrderBy(x => x.FacultyDepartmentID)
                  .Skip(model.PageSize * (model.PageNumber - 1))
                  .Take(model.PageSize).ToList();

        model.TotalCount = facultyDepartments.Count();
        var page = (model.TotalCount / model.PageSize) - 
                   (model.TotalCount % model.PageSize == 0 ? 1 : 0);
        model.PagerCount = page + 1;
    }

    return View(model);
}
        // GET: FacultyDepartments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacultyDepartment facultyDepartment = db.FacultyDepartments.Find(id);
            if (facultyDepartment == null)
            {
                return HttpNotFound();
            }
            return View(facultyDepartment);
        }

        // GET: FacultyDepartments/Create
        public ActionResult Create()
        {
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName");
            return View();
        }

        // POST: FacultyDepartments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacultyDepartmentID,FacultyDepartmentName,FacultyID")] FacultyDepartment facultyDepartment)
        {
            if (ModelState.IsValid)
            {
                db.FacultyDepartments.Add(facultyDepartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", facultyDepartment.FacultyID);
            return View(facultyDepartment);
        }

        // GET: FacultyDepartments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacultyDepartment facultyDepartment = db.FacultyDepartments.Find(id);
            if (facultyDepartment == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", facultyDepartment.FacultyID);
            return View(facultyDepartment);
        }

        // POST: FacultyDepartments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacultyDepartmentID,FacultyDepartmentName,FacultyID")] FacultyDepartment facultyDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facultyDepartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", facultyDepartment.FacultyID);
            return View(facultyDepartment);
        }

        // GET: FacultyDepartments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacultyDepartment facultyDepartment = db.FacultyDepartments.Find(id);
            if (facultyDepartment == null)
            {
                return HttpNotFound();
            }
            return View(facultyDepartment);
        }

        // POST: FacultyDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FacultyDepartment facultyDepartment = db.FacultyDepartments.Find(id);
            db.FacultyDepartments.Remove(facultyDepartment);
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
