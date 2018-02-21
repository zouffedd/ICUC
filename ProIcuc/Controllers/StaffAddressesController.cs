using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProIcuc.Models;
using ProIcuc.Models.HumanResource;

namespace ProIcuc.Controllers
{
    public class StaffAddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StaffAddresses
        public ActionResult Index()
        {
            var staffAddresses = db.StaffAddresses.Include(s => s.Country).Include(s => s.Staff);
            return View(staffAddresses.ToList());
        }

        // GET: StaffAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffAddress staffAddress = db.StaffAddresses.Find(id);
            if (staffAddress == null)
            {
                return HttpNotFound();
            }
            return View(staffAddress);
        }

        // GET: StaffAddresses/Create
        public ActionResult Create()
        {
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "CountryName");
            ViewBag.StaffID = new SelectList(db.Staffs, "StaffID", "FirstName");
            return View();
        }

        // POST: StaffAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StaffAddressID,StaffAddressName,HomeAddress,StaffID,PostalAddress,City,CountryID")] StaffAddress staffAddress)
        {
            if (ModelState.IsValid)
            {
                db.StaffAddresses.Add(staffAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "CountryName", staffAddress.CountryID);
            ViewBag.StaffID = new SelectList(db.Staffs, "StaffID", "FirstName", staffAddress.StaffID);
            return View(staffAddress);
        }

        // GET: StaffAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffAddress staffAddress = db.StaffAddresses.Find(id);
            if (staffAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "CountryName", staffAddress.CountryID);
            ViewBag.StaffID = new SelectList(db.Staffs, "StaffID", "FirstName", staffAddress.StaffID);
            return View(staffAddress);
        }

        // POST: StaffAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StaffAddressID,StaffAddressName,HomeAddress,StaffID,PostalAddress,City,CountryID")] StaffAddress staffAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staffAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "CountryName", staffAddress.CountryID);
            ViewBag.StaffID = new SelectList(db.Staffs, "StaffID", "FirstName", staffAddress.StaffID);
            return View(staffAddress);
        }

        // GET: StaffAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffAddress staffAddress = db.StaffAddresses.Find(id);
            if (staffAddress == null)
            {
                return HttpNotFound();
            }
            return View(staffAddress);
        }

        // POST: StaffAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StaffAddress staffAddress = db.StaffAddresses.Find(id);
            db.StaffAddresses.Remove(staffAddress);
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
