using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProIcuc.Models;

namespace ProIcuc.Controllers
{
    public class ApplicantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Applicants
        public ActionResult Index()
        {
            return View(db.Applicants.ToList());
        }

        // GET: Applicants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // GET: Applicants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Applicants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicantID,FirstName,LastName,Gender,Title,CountryOfBirth,CountrOfResidence,Nationlt,DOB,HomeAddress,PostalAddress,City,PostCode,TelNo,Email,CorHomeAddress,CorPostalAddress,CorCity,CorPostCode,CorTelNo,CorEmail,AlevelDocName,ExamAuthorityID,SecSchoolNameAndAddress,SecSchoolExaminationYear,SecSchoolIndexNo,ODocName,OSchoolNameAndAddress,OExaminatingYear,OIndexNo,InstitutionNameAndAddress,QualificationObtained,QualificationObtainedDate,Session,EmployerName,PositionAndWorkCarriedOut,From,To,ProffessionalQualificationName,DateObtained,EngSpeaking,EngReading,EngWriting,EnglishLanguageQualification,EngQualificName,EngQualificNameDate,RefereesNameAndAddress,DoUHaveAnyHealthCondition,AreUOnRegularMedication,StateMedicationType,DoUNeedAnyMedicalAttention,EntryYear,Religion,AdminState,Intake")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Applicants.Add(applicant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicant);
        }

        // GET: Applicants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicantID,FirstName,LastName,Gender,Title,CountryOfBirth,CountrOfResidence,Nationlt,DOB,HomeAddress,PostalAddress,City,PostCode,TelNo,Email,CorHomeAddress,CorPostalAddress,CorCity,CorPostCode,CorTelNo,CorEmail,AlevelDocName,ExamAuthorityID,SecSchoolNameAndAddress,SecSchoolExaminationYear,SecSchoolIndexNo,ODocName,OSchoolNameAndAddress,OExaminatingYear,OIndexNo,InstitutionNameAndAddress,QualificationObtained,QualificationObtainedDate,Session,EmployerName,PositionAndWorkCarriedOut,From,To,ProffessionalQualificationName,DateObtained,EngSpeaking,EngReading,EngWriting,EnglishLanguageQualification,EngQualificName,EngQualificNameDate,RefereesNameAndAddress,DoUHaveAnyHealthCondition,AreUOnRegularMedication,StateMedicationType,DoUNeedAnyMedicalAttention,EntryYear,Religion,AdminState,Intake")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicant);
        }

        // GET: Applicants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Applicant applicant = db.Applicants.Find(id);
            db.Applicants.Remove(applicant);
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
