using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.Applications
{
    public class AdmissionStatus
    {
        public int AdmissionStatusID { get; set; }
        public string AdminStatusName { get; set; }
        public virtual ICollection<Applicant> Applicant { get; set; }

    }
}