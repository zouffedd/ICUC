using ProIcuc.Models.Applications;
using ProIcuc.Models.Examination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.Academics
{
    public class SemRegistration
    {
        public int SemRegistrationID { get; set; }

        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

        public int ModeOfStudyID { get; set; }
        public virtual ModeOfStudy ModeOfStudy { get; set; }
       
        public int ProgramID { get; set; }
        public virtual Program Program { get; set; }

        public string FacultyID { get; set; }
        public virtual Faculty Faculty { get; set; }

        public int FacultyDepartmentID { get; set; }
        public virtual FacultyDepartment FacultyDepartment { get; set; }

        public int AcademicYearID { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }

        public int YearOfStudyID { get; set; }
        public virtual YearOfStudy YearOfStudy { get; set; }

        public int SemesterID { get; set; }
        public virtual Semester Semester { get; set; }

        public string CourseID { get; set; }
        public virtual Course Course { get; set; }
    }
}