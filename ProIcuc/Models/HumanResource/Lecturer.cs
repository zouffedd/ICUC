using ProIcuc.Models.Academics;
using ProIcuc.Models.HumanResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProIcuc.Models
{
    public class Lecturer
    {
        public int LecturerID { get; set; }
        public int StaffID { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual ICollection<Faculty> Faculties { get; set; }
    }

}