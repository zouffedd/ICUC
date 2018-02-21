using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.Applications
{
    public enum PaperType { Principle, Subsidiary }
    public class AlevelSubject
    {

        public int AlevelSubjectID { get; set; }
        [Display(Name = "Subject Name"), Required]
        public string AlevelSubjectName { get; set; }
        [ForeignKey("Applicant")]
        public int ApplicantID { get; set; }
        public virtual Applicant Applicant { get; set; }

        [Display(Name ="Subject Grade"), Required, MaxLength(1), MinLength(1), RegularExpression(@"[A,B,C,D,E,F,O,1,2,3,4,5,6]*$", ErrorMessage = "Please Enter A Valid Grade Without White Space !")]
        public string SubjectGrade { get; set; }
        [Display(Name = "Paper Grade"), Required, Range(1, 9, ErrorMessage = "Grade must be numeric(Not Less or More than 1)"), RegularExpression(@"[1,2,3,4,5,6,7,8,9]*$")]
        public int PaperGrade { get; set; }
        public PaperType PaperType { get; set; }
        [Display(Name = "Paper No"), Required, MaxLength(1), MinLength(1), RegularExpression(@"^[1-7]*$", ErrorMessage = "Paper No must be numeric(Not Less Than 1 or More than 7)")]
        public string PaperNo { get; set; }
        public string Score { get; set; }
      
    }
}