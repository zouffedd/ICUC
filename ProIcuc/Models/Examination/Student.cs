using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProIcuc.Models.Applications;
using ProIcuc.Models.Academics;

namespace ProIcuc.Models.Examination
{
    public class Student
    {
        public int StudentID { get; set; }
        [Display(Name ="Registration No")]
        public string RegNo { get; set; }

        [Display(Name = "Faculty")]
        public int FacultyID { get; set; }
        public virtual Faculty Faculty { get; set; }

        [Display(Name = "Department")]
        public int FacultyDepartmentID { get; set; }
        public virtual FacultyDepartment FacultyDepartment { get; set; }

        [Display(Name = "Program")]
        public int ProgramID { get; set; }
        public virtual Program Program { get; set; }


        [Display(Name ="Student")]
        public int ApplicantID { get; set; }
        public virtual Applicant Applicant { get; set; }

        [Display(Name = "Program")]
        public int PreferenceID { get; set; }
        public virtual Preference ModeOfStudy { get; set; }

       
        public string StudentName { get { return Applicant.FirstName + " " + Applicant.LastName + " " + Applicant.TelNo; } }
        public virtual ICollection<SemRegistration> SemRegistrations { get; set; }

    }
}