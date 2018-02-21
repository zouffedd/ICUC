using ProIcuc.Models.Academics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.Examination
{
    public class YearOfStudy
    {
        public int YearOfStudyID { get; set; }
        [Display(Name = "Study Year")]
        public string StudyYear { get; set; }
        public virtual ICollection<ProgCourse> ProgCourses { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<CourseAllocation> CourseAllocations { get; set; }
        public virtual ICollection<SemRegistration> SemRegistrations { get; set; }
    }
}