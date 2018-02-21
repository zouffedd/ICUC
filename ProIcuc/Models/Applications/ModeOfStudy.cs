using ProIcuc.Models.Academics;
using ProIcuc.Models.Examination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProIcuc.Models.Applications
{
    public class ModeOfStudy
    {
        public int ModeOfStudyID { get; set; }
        [Display(Name ="Mode Of Study")]
        public string ModeOfStudyName { get; set; }
       
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<ProgClass> ProgClasses { get; set; }
        public virtual ICollection<SemRegistration> SemRegistrations { get; set; }
    }
}