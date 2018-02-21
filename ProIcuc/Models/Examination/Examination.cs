using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProIcuc.Models.Academics;

namespace ProIcuc.Models.Examination
{
    public class Examination
    {
        public int ExaminationID { get; set; }
        [ForeignKey("CourseAllocation")]
        [Display(Name ="Course")]
        public int CourseAllocationID { get; set; }
        public virtual CourseAllocation CourseAllocation { get; set; }
        [Display(Name ="Q1 Marks")]
        public float Qtn1 { get; set; }
        
        [Display(Name = "Q2 Marks")]
        public float Qtn2 { get; set; }
        [Display(Name = "Q3 Marks")]
        public float Qtn3 { get; set; }
        [Display(Name = "Q4 Marks")]
        public float Qtn4 { get; set; }
        [Display(Name = "Q5 Marks")]
        public float Qtn5 { get; set; }
        [Display(Name = "Q6 Marks")]
        public float Qtn6 { get; set; }
        [Display(Name = "Q7 Marks")]
        public float Qtn7 { get; set; }
        [Display(Name = "Q8 Marks")]
        public float Qtn8 { get; set; }
        [Display(Name = "Q9 Marks")]
        public float Qtn9 { get; set; }
        [Display(Name = "Q10 Marks")]
        public float Qtn10 { get; set; }
        [Display(Name = "Exam Ratio")]
        public float ExamRatio { get { return(100); } }
        [Display(Name ="Number of Questions")]
        public float NoofQtns { get; set; }
        public float TotalMark { get { return (Qtn1+Qtn2+Qtn3+Qtn4+Qtn5+Qtn6+Qtn7+Qtn8+Qtn9+Qtn10); } }
        [ForeignKey("CourseWork")]
        public int CourseWorkID { get; set; }
        public virtual CourseWork CourseWork { get;set; }
       public float FinalMark { get { return (TotalMark / ExamRatio)*70; } }
        
    }
}