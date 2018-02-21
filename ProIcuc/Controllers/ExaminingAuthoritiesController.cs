using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProIcuc.Models;
using ProIcuc.Models.Applications;

namespace ProIcuc.Controllers
{
    public class ExaminingAuthoritiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExaminingAuthorities
        public ActionResult Index()
        {
            return View(db.ExaminingAuthorities.ToList());
        }

        // GET: ExaminingAuthorities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExaminingAuthority examiningAuthority = db.ExaminingAuthorities.Find(id);
            if (examiningAuthority == null)
            {
                return HttpNotFound();
            }
            return View(examiningAuthority);
        }

        // GET: ExaminingAuthorities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExaminingAuthorities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExaminingAuthorityID,ExaminingAutorityName")] ExaminingAuthority examiningAuthority)
        {
            if (ModelState.IsValid)
            {
                db.ExaminingAuthorities.Add(examiningAuthority);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(examiningAuthority);
        }

        // GET: ExaminingAuthorities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExaminingAuthority examiningAuthority = db.ExaminingAuthorities.Find(id);
            if (examiningAuthority == null)
            {
                return HttpNotFound();
            }
            return View(examiningAuthority);
        }

        // POST: ExaminingAuthorities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExaminingAuthorityID,ExaminingAutorityName")] ExaminingAuthority examiningAuthority)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examiningAuthority).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(examiningAuthority);
        }

        // GET: ExaminingAuthorities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExaminingAuthority examiningAuthority = db.ExaminingAuthorities.Find(id);
            if (examiningAuthority == null)
            {
                return HttpNotFound();
            }
            return View(examiningAuthority);
        }

        // POST: ExaminingAuthorities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExaminingAuthority examiningAuthority = db.ExaminingAuthorities.Find(id);
            db.ExaminingAuthorities.Remove(examiningAuthority);
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
