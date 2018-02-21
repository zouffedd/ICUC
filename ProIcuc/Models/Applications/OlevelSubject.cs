using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.Applications
{
    public class OlevelSubject
    {
        public int OlevelSubjectID { get; set; }
        public string OlevelSubjectName { get; set; }
        
        [Display(Name ="Grade"),Range(1, 1, ErrorMessage = "Grade must be numeric(Not Less or More than 1 Digits)"), RegularExpression(@"^[1-9]*$", ErrorMessage = "Grade must be numeric(Not Less or More than 1 Digits)")]
        public int Grading { get; set; }
        [ForeignKey("Applicant")]
        [Display(Name = "Applicant Names")]
        public int ApplicantID { get; set; }
        public virtual Applicant Applicant { get; set; }


    }
}