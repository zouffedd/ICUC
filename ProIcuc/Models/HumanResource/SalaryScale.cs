using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.HumanResource
{
    public class SalaryScale
    {
        public int SalaryScaleID { get; set; }
        public string SalaryScaleName { get; set; }
        [DataType(DataType.Currency)]
        public decimal SalaryAmount { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}