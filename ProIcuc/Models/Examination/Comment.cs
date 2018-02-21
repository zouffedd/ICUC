using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProIcuc.Models.Examination
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string CommentName { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}