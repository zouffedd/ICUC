using ProIcuc.Models.Academics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.Examination
{
    public class CourseWork
    {
        public int CourseWorkID { get; set; }
        [ForeignKey("Course")]
        public string CourseID { get; set; }
        public virtual Course Course { get; set; }
        public float Assignment1 { get; set; }
        public float OutOfAs1 { get; set; }
        public float Assignment2 { get; set; }
        public float OutOfAs2 { get; set; }
        public float Assignment3 { get; set; }
        public float OutOfAs3 { get; set; }
        public float Test1 { get; set; }
        public float OutOfTs1 { get; set; }
        public float Test2 { get; set; }
        public float OutOfTs2 { get; set; }
        public float CourseWorkRatio { get { return (30); } }
        public float FinalTotalMark { get { return (Assignment1 + Assignment2 + Assignment3 + Test1 + Test2); } }
        public float FinalOutOf { get { return (OutOfAs1 + OutOfAs2 + OutOfAs3 + OutOfTs1 + OutOfTs2); } }
        public float CWFinalMark { get { return (FinalTotalMark / FinalOutOf) * CourseWorkRatio; } }
    }
}