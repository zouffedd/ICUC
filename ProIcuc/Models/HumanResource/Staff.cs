using ProIcuc.Models.Academics;
using ProIcuc.Models.Applications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.HumanResource
{
    public enum MaritalStatus { Married, Single, Widow, Widower, Separated, Other }
    public enum Gender { Male,Female}
    public class Staff
    {
        public int StaffID { get; set; }
        [Display(Name = "First Name"), Required]
        [StringLength(10, ErrorMessage = "First name cannot be longer than 10 characters."),MinLength(1, ErrorMessage = "First name cannot be Shorter than 1 character.")]
        
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "The First letter Must be a Capital Without White Space")]
        //[RegularExpression("(\p{Lu}[0-9a-fA-F]*| )*"]
        public string FirstName { get; set; }
        [Display(Name = "Last Name"), Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "The First letter Must be a Capital Without White Space")]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        [Display(Name = "Marital Status")]
        public MaritalStatus MaritalStatus { get; set; }
       
        [Display(Name = "Telephone No")]
        public string TelNo { get; set; }
        [Display(Name = "Email"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Date Of Birth"), DataType(DataType.Date)]

        public string DOB { get; set; }
        [Display(Name = "Date Of Hire"), DataType(DataType.Date)]
        public string DateOfHire { get; set; }
        public string StaffName { get { return FirstName + " " + LastName; } }
        public virtual ICollection<Contract> Contracts { get; set; }
        //public virtual ICollection<Academics.Faculty> Faculties { get; set; }
        
        public virtual ICollection<CourseAllocation> CourseAllocations { get; set; }
        public virtual ICollection<Lecturer> Lecturers { get; set; }
    }
}