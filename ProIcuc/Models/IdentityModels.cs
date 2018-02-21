using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProIcuc.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ProIcuc.Models.Academics.Course> Courses { get; set; }
       
        public System.Data.Entity.DbSet<ProIcuc.Models.Academics.FacultyDepartment> FacultyDepartments { get; set; }


        public System.Data.Entity.DbSet<ProIcuc.Models.Academics.Dept> Depts { get; set; }

        public System.Data.Entity.DbSet<ProIcuc.Models.Academics.Faculty> Faculties { get; set; }

        public System.Data.Entity.DbSet<ProIcuc.Models.HumanResource.Staff> Staffs { get; set; }

        public System.Data.Entity.DbSet<ProIcuc.Models.Academics.ProgCourse> ProgCourses { get; set; }

        public System.Data.Entity.DbSet<ProIcuc.Models.Examination.AcademicYear> AcademicYears { get; set; }

        public System.Data.Entity.DbSet<ProIcuc.Models.Academics.Program> Programs { get; set; }

        public System.Data.Entity.DbSet<ProIcuc.Models.Examination.Semester> Semesters { get; set; }

        public System.Data.Entity.DbSet<ProIcuc.Models.Examination.YearOfStudy> YearOfStudies { get; set; }

        
        public System.Data.Entity.DbSet<ProIcuc.Models.Applications.AlevelSubject> AlevelSubjects { get; set; }

        public System.Data.Entity.DbSet<ProIcuc.Models.Applications.Country> Countries { get; set; }


        public System.Data.Entity.DbSet<ProIcuc.Models.Applications.ExaminingAuthority> ExaminingAuthorities { get; set; }


        public System.Data.Entity.DbSet<ProIcuc.Models.Applications.OlevelSubject> OlevelSubjects { get; set; }

        

        public System.Data.Entity.DbSet<ProIcuc.Models.Applications.Preference> Preferences { get; set; }

       

        public System.Data.Entity.DbSet<ProIcuc.Models.Examination.Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<ProIcuc.Models.Examination.Result> Results { get; set; }

        public System.Data.Entity.DbSet<ProIcuc.Models.AllowanceScale> AllowanceScales { get; set; }

        public System.Data.Entity.DbSet<ProIcuc.Models.HumanResource.Contract> Contracts { get; set; }

        public System.Data.Entity.DbSet<ProIcuc.Models.HumanResource.Job> Jobs { get; set; }

        public System.Data.Entity.DbSet<ProIcuc.Models.HumanResource.SalaryScale> SalaryScales { get; set; }

        public System.Data.Entity.DbSet<ProIcuc.Models.HumanResource.StaffAddress> StaffAddresses { get; set; }

        public System.Data.Entity.DbSet<ProIcuc.Models.Applicant> Applicants { get; set; }

        public System.Data.Entity.DbSet<ProIcuc.Models.Academics.CourseAllocation> CourseAllocations { get; set; }

        public System.Data.Entity.DbSet<ProIcuc.Models.Examination.CourseWork> CourseWorks { get; set; }

        object placeHolderVariable;
        public System.Data.Entity.DbSet<ProIcuc.Models.Lecturer> Lecturers { get; set; }

        public System.Data.Entity.DbSet<ProIcuc.Models.Applications.AdmissionStatus> AdmissionStatus { get; set; }

        public System.Data.Entity.DbSet<ProIcuc.Models.Applications.ModeOfStudy> ModeOfStudies { get; set; }

        public System.Data.Entity.DbSet<ProIcuc.Models.Examination.Student> Students { get; set; }
    }
}