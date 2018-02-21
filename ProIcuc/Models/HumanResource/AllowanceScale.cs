using ProIcuc.Models.HumanResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProIcuc.Models
{
    public class AllowanceScale
    {
        public int AllowanceScaleID { get; set; }
        [Display(Name = "Allowance Scale")]
        public string AllowanceScaleCode { get; set; }
        [Display(Name = "Fuel Allowance"), DataType(DataType.Currency)]
        public decimal HousingAllowance { get; set; }
        [Display(Name = "Fuel Allowance"), DataType(DataType.Currency)]
        public decimal PerDM { get; set; }
        [Display(Name = "Fuel Allowance"),DataType(DataType.Currency)]
        public decimal FuelAllowance { get; set; }
        [Display(Name = "Fuel Allowance"), DataType(DataType.Currency)]
        public decimal Airtime { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}