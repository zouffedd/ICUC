using ProIcuc.Models.HumanResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.Academics
{
    public class Faculty
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string FacultyID { get; set; }
        [Display(Name = "Faculty Name"), Required]
        public string FacultyName { get; set; }
        [Display(Name = "Faculty Code"), Required]
        public string FacultyCode { get; set; }
        [Display(Name = "Faculty Abbreviation")]
        public string Abbrev { get; set; }

        //[ForeignKey("Staff")]
        //[Display(Name = "Dean")]
        public int LecturerID { get; set; }
        public virtual Lecturer Dean { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Office Telephone No")]
        public string TelNo { get; set; }
        public virtual ICollection<Program> Programs { get; set; }
        public virtual ICollection<FacultyDepartment> FacultyDepartments { get; set; }
        public virtual ICollection<SemRegistration> SemRegistrations { get; set; }
    }
}