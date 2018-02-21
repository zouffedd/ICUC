using ProIcuc.Models.Academics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.Examination
{
    public class Semester
    {
        public int SemesterID { get; set; }
        public string Sem { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<ProgCourse> ProgCourses { get; set; }
        public virtual ICollection<SemRegistration> SemRegistrations { get; set; }

    }
}