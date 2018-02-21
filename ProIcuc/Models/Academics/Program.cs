using ProIcuc.Models.Applications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.Academics
{
    public class Program
    {

        public int ProgramID { get; set; }
        [Display(Name = "Program Name"), Required]
        public string ProgramName { get; set; }
        [Display(Name = "Program Code")]
        public string ProgCode { get; set; }
        public string FacultyID { get; set; }
        public virtual Faculty Faculty { get; set; }
        [Display(Name = "Years Of Duration")]
        public int Duration { get; set; }
        public int mincredit { get; set; }
        [Display(Name = "Abbreviation")]
        public string abbrev { get; set; }
        public int FacultyDepartmentID { get; set; }
        public virtual FacultyDepartment FacultyDepartment{ get; set; }
        public virtual ICollection<Preference> Preferences { get; set; }
        public virtual ICollection<ProgCourse> ProgCourses { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<SemRegistration> SemRegistrations { get; set; }
        public virtual ICollection<GivenProgram> GivenPrograms { get; set; }
    }
}