using ProIcuc.Models.Academics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.Applications
{
    public class GivenProgram
    {
        public int GivenProgramID { get; set; }
        public int ApplicantID { get; set; }
        public virtual Applicant Applicant{ get; set; }
        public int ProgramID { get; set; }
        public virtual Program Program { get; set; }
    }
}