using ProIcuc.Models.Academics;
using System.Collections.Generic;

namespace ProIcuc.ViewModels
{
    public class FacultyDeptData
    {
        public IEnumerable<FacultyDepartment> FacultyDepartment { get; set; }
        public IEnumerable<Program> Programs { get; set; }
        public IEnumerable<Course> Courses { get; set; }
       

    }
}