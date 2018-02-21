using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.Academics
{
    public class Dept
    {
        public int DeptID { get; set; }

        [Display(Name = "Department Name")]
        public string DeptName { get; set; }
        [Display(Name = "Department Code")]
        public string DeptCode { get; set; }
    }
}