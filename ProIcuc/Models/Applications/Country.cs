using ProIcuc.Models.HumanResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProIcuc.Models.Applications
{
    public class Country
    {
        public int CountryID { get; set; }
        [Display(Name ="Country")]
        public string CountryName { get; set; }
        public virtual ICollection<Applicant> Applicants { get; set; }
        public virtual ICollection<StaffAddress> StaffAddresses { get; set; }
    }
}