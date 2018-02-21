using ProIcuc.Models.Examination;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.Academics
{
    public class ProgCourse
    {
        public int ProgCourseID { get; set; }
        [ForeignKey("Program"), Required]
        public int ProgramID { get; set; }
        public virtual Program Program { get; set; }
        [ForeignKey("Course"), Required]
        public string CourseID { get; set; }
        public virtual Course Course { get; set; }
        [Display(Name = "Academic Year"), Required]
        [ForeignKey("AcademicYear")]
        public int AcademicYearID { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }
        [Required]
        [ForeignKey("Semester")]
        public int SemesterID { get; set; }
        public virtual Semester Semester { get; set; }
        [Display(Name = "Year Of Study"), Required]
        [ForeignKey("YearOfStudy")]
        public int YearOfStudyID { get; set; }
        public virtual YearOfStudy YearOfStudy { get; set; }
    }
}