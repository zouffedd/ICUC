using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.Academics
{
    public class FacultyDepartment
    {
        public int FacultyDepartmentID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string FacultyDepartmentName { get; set; }
        public int FacultyID { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int PagerCount { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Program> Programs { get; set; }
        public virtual ICollection<SemRegistration> SemRegistrations { get; set; }
    }
}