using ProIcuc.Models.Applications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.HumanResource
{
    public class StaffAddress
    {
        public int StaffAddressID { get; set; }
        [Display(Name = "Address")]
        public string StaffAddressName { get; set; }
        [Display(Name = "Home Address")]
        public string HomeAddress { get; set; }

        [ForeignKey("Staff")]
        [Display(Name = "Staff Names")]
        public int StaffID { get; set; }
        public virtual Staff Staff { get; set; }
        [Display(Name = "Postal Address")]
        public string PostalAddress { get; set; }
        public string City { get; set; }
       
        [ForeignKey("Country")]
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }
    }
}