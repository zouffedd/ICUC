using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.Examination
{
    public class CourseWorkResult
    {
        public int CourseWorkResultID { get; set; }
        [Display(Name = "Registration No"), Required]
        public string RegNo { get; set; }
        [Required]
        [ForeignKey("Comment")]
        public int CommentID { get; set; }
        public virtual Comment Comment { get; set; }
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
        [ForeignKey("CourseWork")]
        public int CourseWorkID { get; set; }
        public virtual CourseWork CourseWork { get; set; }

        [ForeignKey("Examination")]
        public int ExaminationID { get; set; }
        public virtual Examination Examination { get; set; }
    }
}