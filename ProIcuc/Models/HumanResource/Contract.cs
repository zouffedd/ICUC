using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.HumanResource
{
    public class Contract
    {
        public int ContractID { get; set; }
        [Display(Name = "Contact Code")]
        public String ContractCode { get; set; }
        [ForeignKey("Staff")]
        [Display(Name = "Staff Names")]
        public int StaffID { get; set; }
        public virtual Staff Staff { get; set; }
        public String ContractType { get; set; }
        [Display(Name = "Contact Start"), DataType(DataType.Date)]
        public DateTime ContractStart { get; set; }
        [Display(Name = "Contact Start"), DataType(DataType.Date)]
        public DateTime ContractEnd { get; set; }
        [ForeignKey("Job")]
        public int JobID { get; set; }
        public virtual Job Job { get; set; }
    }
}