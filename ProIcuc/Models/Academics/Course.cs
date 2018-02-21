using ProIcuc.Models.Examination;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.Academics
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="Number")]
        public string CourseID { get; set; }
        [Display(Name = "Course Name"), Required]
        public string CourseName { get; set; }
        [Display(Name = "Credit Units"),Range(0, 5),Required]
        public double CreditUnits { get; set; }
        [Display(Name = "Contact Hours"), Required]
        public int ContactHours { get; set; }
        [Display(Name = "Practical Hours"), Required]
        public int PracticalHours { get; set; }
        [Display(Name = "Lecture Hours"), Required]
        public int LectureHours { get; set; }
        public int ProgramID { get; set; }
        public virtual Program Program { get; set; }
        public virtual ICollection<ProgCourse> ProgCourses { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<CourseAllocation> CourseAllocations { get; set; }
        public virtual ICollection<SemRegistration> SemRegistrations { get; set; }
    }   
}