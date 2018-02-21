using ProIcuc.Models.Academics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.Examination
{
    public class AcademicYear
    {
        public int AcademicYearID { get; set; }
        [Display(Name = "Academic Year")]
        public string AcademicYearName { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<ProgCourse> ProgCourses { get; set; }
        public virtual ICollection<SemRegistration> SemRegistrations { get; set; }

    }
}