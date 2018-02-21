using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProIcuc.Models.HumanResource;
using ProIcuc.Models.Examination;

namespace ProIcuc.Models.Academics
{
    public class CourseAllocation
    {
        public int CourseAllocationID { get; set; }
        [ForeignKey("Staff")]
        [Display(Name ="Lecturer")]
        public int StaffID { get; set; }
        public virtual Staff Staff { get; set; }
        [ForeignKey("Course")]
        [Display(Name = "Course")]
        public string CourseID { get; set; }
        public virtual Course Course { get; set; }
        


    }
}