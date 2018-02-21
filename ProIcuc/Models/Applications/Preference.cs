using ProIcuc.Models.Academics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.Applications
{
    public enum Choices { First, Second }

    public class Preference
    {
        public int PreferenceId { get; set; }
  
        public int ApplicantID { get; set; }
        public virtual Applicant Applicant { get; set; }

        public Choices Choice { get; set; }
        public int ModeOfStudyID { get; set; }
        public virtual ModeOfStudy ModeOfStudy { get; set; }


        [Display(Name ="Program")]
        public int ProgramID { get; set; }
        public virtual Program Program { get; set; }
        
        
    }
}