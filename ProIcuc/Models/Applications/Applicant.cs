using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using ProIcuc.Models.HumanResource;
using ProIcuc.Models.Applications;


namespace ProIcuc.Models
{
    public enum Religion { Islam, Catholic, Protestant, Pentecostal, Adventist, Budhism, Hinduism, Atheist, Other }
    
    public enum EngSpeaking { Fluent, Adequate, Basic }
    public enum EngReading { Fluent, Adequate, Basic }
    public enum EngWriting { Fluent, Adequate, Basic }
    public enum Intake { August, December, April }
    public enum Session { FullTime, PartTime, Distance }
    public enum AdminState { Pending,Admitted, Registered}
    public class Applicant
    {
        public int ApplicantID { get; set; }
        [StringLength(15, ErrorMessage = "Surname/Family Name cannot be longer than 15 characters.")]
        [MinLength(1, ErrorMessage = "Surname/Family Name cannot be Shorter than 1 character.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "The First letter Must be a Capital Without White Space")]
        [Display(Name = "Surname/Family Name"), Required(ErrorMessage = "Surname/Family Name Is Required")]
        public string FirstName { get; set; }
        [Display(Name = "First/Given Names"), Required(ErrorMessage = "Surname/Family Name Is Required")]
        [MinLength(1, ErrorMessage = "First/Given Names cannot be Shorter than 1 character.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "The First letter Must be a Capital Without White Space")]
        public string LastName { get; set; }
       
        public string ApplicantName { get { return FirstName + " " + LastName + " " + TelNo; } }

        public Gender Gender { get; set; }

        public string Title { get; set; }
        [Display(Name = "Country Of Birth"), Required, RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "The First letter Must be a Capital Without White Space")]
        public string CountryOfBirth { get; set; }

        [Display(Name = "Country Of Residence"), Required, RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "The First letter Must be a Capital Without White Space")]
        public String CountrOfResidence { get; set; }

        [Display(Name = "Nationality"), RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "The First letter Must be a Capital Without White Space")]
        public string Nationlt { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "BirthDate"), DataType(DataType.Date,ErrorMessage = "Valid Date Required")]
        public DateTime DOB { get; set; }

        [Display(Name = "Home/Permanent Address"),RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "The First letter Must be a Capital Without White Space")]
        public string HomeAddress { get; set; }
       
        [Display(Name = "Postal Address")]
        public string PostalAddress { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "The First letter Must be a Capital Without White Space")]
        public string City { get; set; }
        [Display(Name = "Postcode")]
        public string PostCode { get; set; }

        [Display(Name = "Telephone No"),DataType(DataType.PhoneNumber, ErrorMessage = "Valid Phone No Required")]
        public string TelNo { get; set; }
        [Display(Name = "E-mail Address"), DataType(DataType.EmailAddress,ErrorMessage = "Valid Email Required")]
        public string Email { get; set; }

        [Display(Name = "Correspondence Home Address"), RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "The First letter Must be a Capital Without White Space")]
        public string CorHomeAddress { get; set; }
        [Display(Name = "Correspondence Postal Address")]
        public string CorPostalAddress { get; set; }
        [Display(Name = "Correspondence City"),RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "The First letter Must be a Capital Without White Space")]
        public string CorCity { get; set; }
        [Display(Name = "Correspondence Postcode")]
        public string CorPostCode { get; set; }
        [Display(Name = "Correspondence Telephone No"), DataType(DataType.PhoneNumber,ErrorMessage = "Valid Phone No Required")]
        public string CorTelNo { get; set; }
        [Display(Name = "Correspondence E-mail Address"), DataType(DataType.EmailAddress,ErrorMessage = "Valid Email Required")]
        public string CorEmail { get; set; }

        [Display(Name = "Advanced Level Document"), RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "The First letter Must be a Capital Without White Space")]
        public string AlevelDocName { get; set; }
        public string ExamAuthorityID { get; set; }
        [Display(Name = "School Name And Address")]
        public string SecSchoolNameAndAddress { get; set; }
        [Display(Name = "Examination Year"),RegularExpression(@"^(\d{4})$",ErrorMessage ="Valid Year Required")]
        public int SecSchoolExaminationYear { get; set; }
        [Display(Name = "Index No")]
        public string SecSchoolIndexNo { get; set; }

        [Display(Name = "Ordinary Level Document"), RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "The First letter Must be a Capital Without White Space")]
        public string ODocName { get; set; }
        [Display(Name = "School Name And Address")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "The First letter Must be a Capital Without White Space")]
        public string OSchoolNameAndAddress { get; set; }
        [Display(Name = "Examination Year"), RegularExpression(@"^(\d{4})$", ErrorMessage = "Valid Year Required")]
        public int OExaminatingYear { get; set; }
        [Display(Name = "Index No")]
        public string OIndexNo { get; set; }

        [Display(Name = "Institution Name/Address"), RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "The First letter Must be a Capital Without White Space")]
        public string InstitutionNameAndAddress { get; set; }
        [Display(Name = "Qualifications Obtained"), RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "The First letter Must be a Capital Without White Space")]
        public string QualificationObtained { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Obtained"), DataType(DataType.Date, ErrorMessage = "Valid Date Required")]
        public DateTime QualificationObtainedDate { get; set; }
        public Session Session { get; set; }


        [Display(Name = "Employer And Address"), RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "The First letter Must be a Capital Without White Space")]
        public string EmployerName { get; set; }
        [Display(Name = "Position And Work Carried Out")]
        public string PositionAndWorkCarriedOut { get; set; }
        [Display(Name = "From"), DataType(DataType.Date, ErrorMessage = "Valid Date Required")]
        public DateTime From { get; set; }
        [Display(Name = "To"), DataType(DataType.Date, ErrorMessage = "Valid Date Required")]
        public DateTime To { get; set; }

        [Display(Name = "Proffessional Qualification"), RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "The First letter Must be a Capital Without White Space")]
        public string ProffessionalQualificationName { get; set; }
        
        [Display(Name = "Date Obtained"), DataType(DataType.Date, ErrorMessage = "Valid Date Required")]
        public DateTime DateObtained { get; set; }

        [Display(Name = "English Speaking")]
        public EngSpeaking EngSpeaking { get; set; }
        [Display(Name = "English Reading")]
        public EngReading EngReading { get; set; }
        [Display(Name = "English Writing")]
        public EngWriting EngWriting { get; set; }

        [Display(Name = "Any English Language Qualification")]
        public bool EnglishLanguageQualification { get; set; }
        [Display(Name = "Qualification Name"), RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "The First letter Must be a Capital Without White Space")]
        public string EngQualificName { get; set; }
        [Display(Name = "Final Examination Date"), DataType(DataType.Date, ErrorMessage = "Valid Date Required")]
        public DateTime EngQualificNameDate { get; set; }

        [Display(Name = "Referees Name And Address"), RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "The First letter Must be a Capital Without White Space")]
        public string RefereesNameAndAddress { get; set; }

        [Display(Name = "Any Health Condition ?")]
        public bool DoUHaveAnyHealthCondition { get; set; }
        [Display(Name = "Are You Regular Medication ?")]
        public bool AreUOnRegularMedication { get; set; }
        [Display(Name = "State Medication Type?")]
        public string StateMedicationType { get; set; }
        [Display(Name = "Any Medical Attention Needed ?")]
        public bool DoUNeedAnyMedicalAttention { get; set; }
        [Display(Name = "Entry Year"), RegularExpression(@"^(\d{4})$", ErrorMessage = "Valid Year Required")]
        public int EntryYear { get; set; }
        public Religion Religion { get; set; }

        [Display(Name = "Admission Status")]
        public AdminState AdminState { get; set; }
        public Intake Intake { get; set; }
        public virtual ICollection<AlevelSubject> AlevelSubjects { get; set; }
        public virtual ICollection<GivenProgram> GivenPrograms { get; set; }
        public virtual ICollection<Preference> Preferences { get; set; }
    }
}