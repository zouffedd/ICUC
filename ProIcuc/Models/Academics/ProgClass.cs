using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProIcuc.Models.Applications;

namespace ProIcuc.Models.Academics
{
    public class ProgClass
    {
        public int ProgClassID { get; set; }
        [ForeignKey("Program")]
        public int ProgramID { get; set; }
        public virtual Program Program { get; set; }
        [ForeignKey("ModeOfStudy")]
        public int ModeOfStudyID { get; set; }
        public virtual ModeOfStudy ModeOfStudy { get; set; }

    }
}