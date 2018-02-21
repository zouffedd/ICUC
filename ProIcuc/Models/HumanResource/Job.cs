using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.HumanResource
{
    public class Job
    {
        public int JobID { get; set; }
        [Display(Name = "Job Title")]
        public string JobName { get; set; }
        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }
        [Display(Name = "Academic Requirements")]
        public string JobAcademicRequirements { get; set; }
        [Display(Name = "Requirements description"), DataType(DataType.MultilineText)]
        public string RequirementDescription { get; set; }
        [ForeignKey("AllowanceScale")]
        [Display(Name = "Allowance Scale")]
        public int AllowanceGradeID { get; set; }
        public virtual AllowanceScale AllowanceScale { get; set; }
        [ForeignKey("SalaryScale")]
        [Display(Name = "Salary Scale")]
        public int SalaryScaleID { get; set; }
        public virtual SalaryScale SalaryScale { get; set; }
    }
}