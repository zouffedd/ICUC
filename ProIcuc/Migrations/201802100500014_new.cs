namespace ProIcuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicYears",
                c => new
                    {
                        AcademicYearID = c.Int(nullable: false, identity: true),
                        AcademicYearName = c.String(),
                    })
                .PrimaryKey(t => t.AcademicYearID);
            
            CreateTable(
                "dbo.ProgCourses",
                c => new
                    {
                        ProgCourseID = c.Int(nullable: false, identity: true),
                        ProgramID = c.Int(nullable: false),
                        CourseID = c.String(nullable: false, maxLength: 128),
                        AcademicYearID = c.Int(nullable: false),
                        SemesterID = c.Int(nullable: false),
                        YearOfStudyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProgCourseID)
                .ForeignKey("dbo.AcademicYears", t => t.AcademicYearID, cascadeDelete: false)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: false)
                .ForeignKey("dbo.Programs", t => t.ProgramID, cascadeDelete: false)
                .ForeignKey("dbo.Semesters", t => t.SemesterID, cascadeDelete: false)
                .ForeignKey("dbo.YearOfStudies", t => t.YearOfStudyID, cascadeDelete: false)
                .Index(t => t.ProgramID)
                .Index(t => t.CourseID)
                .Index(t => t.AcademicYearID)
                .Index(t => t.SemesterID)
                .Index(t => t.YearOfStudyID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.String(nullable: false, maxLength: 128),
                        CourseName = c.String(nullable: false),
                        CreditUnits = c.Double(nullable: false),
                        ContactHours = c.Int(nullable: false),
                        PracticalHours = c.Int(nullable: false),
                        LectureHours = c.Int(nullable: false),
                        ProgramID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Programs", t => t.ProgramID, cascadeDelete: false)
                .Index(t => t.ProgramID);
            
            CreateTable(
                "dbo.CourseAllocations",
                c => new
                    {
                        CourseAllocationID = c.Int(nullable: false, identity: true),
                        StaffID = c.Int(nullable: false),
                        CourseID = c.String(maxLength: 128),
                        YearOfStudy_YearOfStudyID = c.Int(),
                    })
                .PrimaryKey(t => t.CourseAllocationID)
                .ForeignKey("dbo.Courses", t => t.CourseID)
                .ForeignKey("dbo.YearOfStudies", t => t.YearOfStudy_YearOfStudyID)
                .ForeignKey("dbo.Staffs", t => t.StaffID, cascadeDelete: false)
                .Index(t => t.StaffID)
                .Index(t => t.CourseID)
                .Index(t => t.YearOfStudy_YearOfStudyID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 10),
                        LastName = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        MaritalStatus = c.Int(nullable: false),
                        TelNo = c.String(),
                        Email = c.String(),
                        DOB = c.String(),
                        DateOfHire = c.String(),
                        Nationality_NationalityID = c.Int(),
                    })
                .PrimaryKey(t => t.StaffID)
                .ForeignKey("dbo.Nationalities", t => t.Nationality_NationalityID)
                .Index(t => t.Nationality_NationalityID);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        HomeAddress = c.String(),
                        ApplicantID = c.Int(nullable: false),
                        PostalAddress = c.String(),
                        City = c.String(),
                        PostCode = c.String(),
                        Fax = c.String(),
                        CountryID = c.Int(nullable: false),
                        Staff_StaffID = c.Int(),
                    })
                .PrimaryKey(t => t.AddressID)
                .ForeignKey("dbo.Applicants", t => t.ApplicantID, cascadeDelete: false)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: false)
                .ForeignKey("dbo.Staffs", t => t.Staff_StaffID)
                .Index(t => t.ApplicantID)
                .Index(t => t.CountryID)
                .Index(t => t.Staff_StaffID);
            
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        ApplicantID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 10),
                        LastName = c.String(nullable: false),
                        TelNo = c.String(),
                        Email = c.String(),
                        Gender = c.Int(nullable: false),
                        DOB = c.String(),
                        NationalityID = c.Int(nullable: false),
                        EngSpeaking = c.Int(nullable: false),
                        EngReading = c.Int(nullable: false),
                        EngWriting = c.Int(nullable: false),
                        RefereesNameAndAddress = c.String(),
                        DoUHaveAnyHealthCondition = c.Boolean(nullable: false),
                        AreUOnRegularMedication = c.Boolean(nullable: false),
                        StateMedicationType = c.String(),
                        DoUNeedAnyMedicalAttention = c.Boolean(nullable: false),
                        EntryYear = c.String(),
                        Religion = c.Int(nullable: false),
                        AdmissionStatusID = c.Int(nullable: false),
                        Intake = c.Int(nullable: false),
                        Country_CountryID = c.Int(),
                    })
                .PrimaryKey(t => t.ApplicantID)
                .ForeignKey("dbo.AdmissionStatus", t => t.AdmissionStatusID, cascadeDelete: false)
                .ForeignKey("dbo.Countries", t => t.Country_CountryID)
                .ForeignKey("dbo.Nationalities", t => t.NationalityID, cascadeDelete: false)
                .Index(t => t.NationalityID)
                .Index(t => t.AdmissionStatusID)
                .Index(t => t.Country_CountryID);
            
            CreateTable(
                "dbo.AdmissionStatus",
                c => new
                    {
                        AdmissionStatusID = c.Int(nullable: false, identity: true),
                        AdminStatusName = c.String(),
                    })
                .PrimaryKey(t => t.AdmissionStatusID);
            
            CreateTable(
                "dbo.AlevelDocs",
                c => new
                    {
                        AlevelDocID = c.Int(nullable: false, identity: true),
                        DocumentID = c.Int(nullable: false),
                        ApplicantID = c.Int(nullable: false),
                        ExaminingAuthority = c.String(),
                        SchoolNameAndAddress = c.String(),
                        ExaminationYear = c.DateTime(nullable: false),
                        IndexNo = c.String(),
                        Program = c.String(),
                        Level_LevelID = c.Int(),
                    })
                .PrimaryKey(t => t.AlevelDocID)
                .ForeignKey("dbo.Applicants", t => t.ApplicantID, cascadeDelete: false)
                .ForeignKey("dbo.Documents", t => t.DocumentID, cascadeDelete: false)
                .ForeignKey("dbo.Levels", t => t.Level_LevelID)
                .Index(t => t.DocumentID)
                .Index(t => t.ApplicantID)
                .Index(t => t.Level_LevelID);
            
            CreateTable(
                "dbo.AlevelSubjects",
                c => new
                    {
                        AlevelSubjectID = c.Int(nullable: false, identity: true),
                        ApplicantID = c.Int(nullable: false),
                        AlevelDocID = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                        PaperType = c.Int(nullable: false),
                        PaperNo = c.String(),
                        Score = c.String(),
                        GradeID = c.Int(nullable: false),
                        SubjectGradeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlevelSubjectID)
                .ForeignKey("dbo.AlevelDocs", t => t.AlevelDocID, cascadeDelete: false)
                .ForeignKey("dbo.Applicants", t => t.ApplicantID, cascadeDelete: false)
                .ForeignKey("dbo.Grades", t => t.GradeID, cascadeDelete: false)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: false)
                .ForeignKey("dbo.SubjectGrades", t => t.SubjectGradeID, cascadeDelete: false)
                .Index(t => t.ApplicantID)
                .Index(t => t.AlevelDocID)
                .Index(t => t.SubjectID)
                .Index(t => t.GradeID)
                .Index(t => t.SubjectGradeID);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeID = c.Int(nullable: false, identity: true),
                        GradeName = c.String(),
                    })
                .PrimaryKey(t => t.GradeID);
            
            CreateTable(
                "dbo.OlevelSubjects",
                c => new
                    {
                        OlevelSubjectID = c.Int(nullable: false, identity: true),
                        ApplicantID = c.Int(nullable: false),
                        OlevelDocsID = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                        GradeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OlevelSubjectID)
                .ForeignKey("dbo.Applicants", t => t.ApplicantID, cascadeDelete: false)
                .ForeignKey("dbo.Grades", t => t.GradeID, cascadeDelete: false)
                .ForeignKey("dbo.OlevelDocs", t => t.OlevelDocsID, cascadeDelete: false)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: false)
                .Index(t => t.ApplicantID)
                .Index(t => t.OlevelDocsID)
                .Index(t => t.SubjectID)
                .Index(t => t.GradeID);
            
            CreateTable(
                "dbo.OlevelDocs",
                c => new
                    {
                        OlevelDocID = c.Int(nullable: false, identity: true),
                        ApplicantID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        ExaminingAuthorityID = c.Int(nullable: false),
                        LevelID = c.Int(nullable: false),
                        SchoolNameAndAddress = c.String(nullable: false),
                        ExaminationYear = c.String(nullable: false),
                        IndexNo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OlevelDocID)
                .ForeignKey("dbo.Applicants", t => t.ApplicantID, cascadeDelete: false)
                .ForeignKey("dbo.Documents", t => t.DocumentID, cascadeDelete: false)
                .ForeignKey("dbo.ExaminingAuthorities", t => t.ExaminingAuthorityID, cascadeDelete: false)
                .ForeignKey("dbo.Levels", t => t.LevelID, cascadeDelete: false)
                .Index(t => t.ApplicantID)
                .Index(t => t.DocumentID)
                .Index(t => t.ExaminingAuthorityID)
                .Index(t => t.LevelID);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentID = c.Int(nullable: false, identity: true),
                        DocumentName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.DocumentID);
            
            CreateTable(
                "dbo.OtherDocs",
                c => new
                    {
                        OtherDocID = c.Int(nullable: false, identity: true),
                        DocumentID = c.Int(nullable: false),
                        ApplicantID = c.Int(nullable: false),
                        InstitutionNameAndAddress = c.String(),
                        QualificationObtained = c.String(),
                        YearOfExamination = c.DateTime(nullable: false),
                        Session = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OtherDocID)
                .ForeignKey("dbo.Applicants", t => t.ApplicantID, cascadeDelete: false)
                .ForeignKey("dbo.Documents", t => t.DocumentID, cascadeDelete: false)
                .Index(t => t.DocumentID)
                .Index(t => t.ApplicantID);
            
            CreateTable(
                "dbo.ExaminingAuthorities",
                c => new
                    {
                        ExaminingAuthorityID = c.Int(nullable: false, identity: true),
                        ExaminingAutorityName = c.String(),
                        ExaminingAuthority_ExaminingAuthorityID = c.Int(),
                    })
                .PrimaryKey(t => t.ExaminingAuthorityID)
                .ForeignKey("dbo.ExaminingAuthorities", t => t.ExaminingAuthority_ExaminingAuthorityID)
                .Index(t => t.ExaminingAuthority_ExaminingAuthorityID);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        LevelID = c.Int(nullable: false, identity: true),
                        LevelName = c.String(),
                    })
                .PrimaryKey(t => t.LevelID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.SubjectGrades",
                c => new
                    {
                        SubjectGradeID = c.Int(nullable: false, identity: true),
                        SubjectGradeName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectGradeID);
            
            CreateTable(
                "dbo.CorrespondenceAddresses",
                c => new
                    {
                        CorrespondenceAddressID = c.Int(nullable: false, identity: true),
                        CorrespondenceAddressName = c.String(),
                        ApplicantID = c.Int(nullable: false),
                        PostalAddress = c.String(),
                        City = c.String(),
                        PostCode = c.String(),
                        TelNo = c.String(),
                        Email = c.String(),
                        Fax = c.String(),
                        Country_CountryID = c.Int(),
                    })
                .PrimaryKey(t => t.CorrespondenceAddressID)
                .ForeignKey("dbo.Applicants", t => t.ApplicantID, cascadeDelete: false)
                .ForeignKey("dbo.Countries", t => t.Country_CountryID)
                .Index(t => t.ApplicantID)
                .Index(t => t.Country_CountryID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.StaffAddresses",
                c => new
                    {
                        StaffAddressID = c.Int(nullable: false, identity: true),
                        StaffAddressName = c.String(),
                        HomeAddress = c.String(),
                        StaffID = c.Int(nullable: false),
                        PostalAddress = c.String(),
                        City = c.String(),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StaffAddressID)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: false)
                .ForeignKey("dbo.Staffs", t => t.StaffID, cascadeDelete: false)
                .Index(t => t.StaffID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.FormerEmployments",
                c => new
                    {
                        FormerEmploymentID = c.Int(nullable: false, identity: true),
                        FormerEmploymentName = c.String(),
                        ApplicantID = c.Int(nullable: false),
                        EmployerNameAddressAndCountry = c.String(),
                        PositionAndWorkCarriedOut = c.String(),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FormerEmploymentID)
                .ForeignKey("dbo.Applicants", t => t.ApplicantID, cascadeDelete: false)
                .Index(t => t.ApplicantID);
            
            CreateTable(
                "dbo.Nationalities",
                c => new
                    {
                        NationalityID = c.Int(nullable: false, identity: true),
                        NationalityName = c.String(),
                    })
                .PrimaryKey(t => t.NationalityID);
            
            CreateTable(
                "dbo.Preferences",
                c => new
                    {
                        PreferenceId = c.Int(nullable: false, identity: true),
                        ApplicantID = c.Int(nullable: false),
                        Choice = c.Int(nullable: false),
                        ProgramID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PreferenceId)
                .ForeignKey("dbo.Applicants", t => t.ApplicantID, cascadeDelete: false)
                .ForeignKey("dbo.Programs", t => t.ProgramID, cascadeDelete: false)
                .Index(t => t.ApplicantID)
                .Index(t => t.ProgramID);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ProgramID = c.Int(nullable: false, identity: true),
                        ProgramName = c.String(nullable: false),
                        ProgCode = c.String(),
                        FacultyID = c.String(maxLength: 128),
                        Duration = c.Int(nullable: false),
                        mincredit = c.Int(nullable: false),
                        abbrev = c.String(),
                        FacultyDepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProgramID)
                .ForeignKey("dbo.FacultyDepartments", t => t.FacultyDepartmentID, cascadeDelete: false)
                .ForeignKey("dbo.Faculties", t => t.FacultyID)
                .Index(t => t.FacultyID)
                .Index(t => t.FacultyDepartmentID);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        FacultyID = c.String(nullable: false, maxLength: 128),
                        FacultyName = c.String(nullable: false),
                        FacultyCode = c.String(nullable: false),
                        Abbrev = c.String(),
                        LecturerID = c.Int(nullable: false),
                        Email = c.String(),
                        TelNo = c.String(),
                    })
                .PrimaryKey(t => t.FacultyID)
                .ForeignKey("dbo.Lecturers", t => t.LecturerID, cascadeDelete: false)
                .Index(t => t.LecturerID);
            
            CreateTable(
                "dbo.Lecturers",
                c => new
                    {
                        LecturerID = c.Int(nullable: false, identity: true),
                        StaffID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LecturerID)
                .ForeignKey("dbo.Staffs", t => t.StaffID, cascadeDelete: false)
                .Index(t => t.StaffID);
            
            CreateTable(
                "dbo.FacultyDepartments",
                c => new
                    {
                        FacultyDepartmentID = c.Int(nullable: false, identity: true),
                        FacultyDepartmentName = c.String(maxLength: 50),
                        FacultyID = c.Int(nullable: false),
                        TotalCount = c.Int(nullable: false),
                        PageSize = c.Int(nullable: false),
                        PageNumber = c.Int(nullable: false),
                        PagerCount = c.Int(nullable: false),
                        Faculty_FacultyID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FacultyDepartmentID)
                .ForeignKey("dbo.Faculties", t => t.Faculty_FacultyID)
                .Index(t => t.Faculty_FacultyID);
            
            CreateTable(
                "dbo.SemRegistrations",
                c => new
                    {
                        SemRegistrationID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        ModeOfStudyID = c.Int(nullable: false),
                        ProgramID = c.Int(nullable: false),
                        FacultyID = c.String(maxLength: 128),
                        FacultyDepartmentID = c.Int(nullable: false),
                        AcademicYearID = c.Int(nullable: false),
                        YearOfStudyID = c.Int(nullable: false),
                        SemesterID = c.Int(nullable: false),
                        CourseID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SemRegistrationID)
                .ForeignKey("dbo.AcademicYears", t => t.AcademicYearID, cascadeDelete: false)
                .ForeignKey("dbo.Courses", t => t.CourseID)
                .ForeignKey("dbo.Faculties", t => t.FacultyID)
                .ForeignKey("dbo.FacultyDepartments", t => t.FacultyDepartmentID, cascadeDelete: false)
                .ForeignKey("dbo.ModeOfStudies", t => t.ModeOfStudyID, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: false)
                .ForeignKey("dbo.Programs", t => t.ProgramID, cascadeDelete: false)
                .ForeignKey("dbo.YearOfStudies", t => t.YearOfStudyID, cascadeDelete: false)
                .ForeignKey("dbo.Semesters", t => t.SemesterID, cascadeDelete: false)
                .Index(t => t.StudentID)
                .Index(t => t.ModeOfStudyID)
                .Index(t => t.ProgramID)
                .Index(t => t.FacultyID)
                .Index(t => t.FacultyDepartmentID)
                .Index(t => t.AcademicYearID)
                .Index(t => t.YearOfStudyID)
                .Index(t => t.SemesterID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.ModeOfStudies",
                c => new
                    {
                        ModeOfStudyID = c.Int(nullable: false, identity: true),
                        ModeOfStudyName = c.String(),
                    })
                .PrimaryKey(t => t.ModeOfStudyID);
            
            CreateTable(
                "dbo.ProgClasses",
                c => new
                    {
                        ProgClassID = c.Int(nullable: false, identity: true),
                        ProgramID = c.Int(nullable: false),
                        ModeOfStudyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProgClassID)
                .ForeignKey("dbo.ModeOfStudies", t => t.ModeOfStudyID, cascadeDelete: false)
                .ForeignKey("dbo.Programs", t => t.ProgramID, cascadeDelete: false)
                .Index(t => t.ProgramID)
                .Index(t => t.ModeOfStudyID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        ApplicantID = c.Int(nullable: false),
                        PreferenceID = c.Int(nullable: false),
                        ProgramID = c.Int(nullable: false),
                        ModeOfStudy_ModeOfStudyID = c.Int(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Applicants", t => t.ApplicantID, cascadeDelete: false)
                .ForeignKey("dbo.Preferences", t => t.PreferenceID, cascadeDelete: false)
                .ForeignKey("dbo.Programs", t => t.ProgramID, cascadeDelete: false)
                .ForeignKey("dbo.ModeOfStudies", t => t.ModeOfStudy_ModeOfStudyID)
                .Index(t => t.ApplicantID)
                .Index(t => t.PreferenceID)
                .Index(t => t.ProgramID)
                .Index(t => t.ModeOfStudy_ModeOfStudyID);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        SemesterID = c.Int(nullable: false, identity: true),
                        Sem = c.String(),
                    })
                .PrimaryKey(t => t.SemesterID);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ResultID = c.Int(nullable: false, identity: true),
                        RegNo = c.String(nullable: false),
                        CommentID = c.Int(nullable: false),
                        AcademicYearID = c.Int(nullable: false),
                        SemesterID = c.Int(nullable: false),
                        YearOfStudyID = c.Int(nullable: false),
                        CourseWorkID = c.Int(nullable: false),
                        ExaminationID = c.Int(nullable: false),
                        FinalResult = c.Single(nullable: false),
                        Course_CourseID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ResultID)
                .ForeignKey("dbo.AcademicYears", t => t.AcademicYearID, cascadeDelete: false)
                .ForeignKey("dbo.Comments", t => t.CommentID, cascadeDelete: false)
                .ForeignKey("dbo.CourseWorks", t => t.CourseWorkID, cascadeDelete: false)
                .ForeignKey("dbo.Examinations", t => t.ExaminationID, cascadeDelete: false)
                .ForeignKey("dbo.Semesters", t => t.SemesterID, cascadeDelete: false)
                .ForeignKey("dbo.YearOfStudies", t => t.YearOfStudyID, cascadeDelete: false)
                .ForeignKey("dbo.Courses", t => t.Course_CourseID)
                .Index(t => t.CommentID)
                .Index(t => t.AcademicYearID)
                .Index(t => t.SemesterID)
                .Index(t => t.YearOfStudyID)
                .Index(t => t.CourseWorkID)
                .Index(t => t.ExaminationID)
                .Index(t => t.Course_CourseID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        CommentName = c.String(),
                    })
                .PrimaryKey(t => t.CommentID);
            
            CreateTable(
                "dbo.CourseWorks",
                c => new
                    {
                        CourseWorkID = c.Int(nullable: false, identity: true),
                        CourseID = c.String(maxLength: 128),
                        Assignment1 = c.Single(nullable: false),
                        OutOfAs1 = c.Single(nullable: false),
                        Assignment2 = c.Single(nullable: false),
                        OutOfAs2 = c.Single(nullable: false),
                        Assignment3 = c.Single(nullable: false),
                        OutOfAs3 = c.Single(nullable: false),
                        Test1 = c.Single(nullable: false),
                        OutOfTs1 = c.Single(nullable: false),
                        Test2 = c.Single(nullable: false),
                        OutOfTs2 = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.CourseWorkID)
                .ForeignKey("dbo.Courses", t => t.CourseID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Examinations",
                c => new
                    {
                        ExaminationID = c.Int(nullable: false, identity: true),
                        CourseAllocationID = c.Int(nullable: false),
                        Qtn1 = c.Single(nullable: false),
                        Qtn2 = c.Single(nullable: false),
                        Qtn3 = c.Single(nullable: false),
                        Qtn4 = c.Single(nullable: false),
                        Qtn5 = c.Single(nullable: false),
                        Qtn6 = c.Single(nullable: false),
                        Qtn7 = c.Single(nullable: false),
                        Qtn8 = c.Single(nullable: false),
                        Qtn9 = c.Single(nullable: false),
                        Qtn10 = c.Single(nullable: false),
                        NoofQtns = c.Single(nullable: false),
                        CourseWorkID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExaminationID)
                .ForeignKey("dbo.CourseAllocations", t => t.CourseAllocationID, cascadeDelete: false)
                .ForeignKey("dbo.CourseWorks", t => t.CourseWorkID, cascadeDelete: false)
                .Index(t => t.CourseAllocationID)
                .Index(t => t.CourseWorkID);
            
            CreateTable(
                "dbo.YearOfStudies",
                c => new
                    {
                        YearOfStudyID = c.Int(nullable: false, identity: true),
                        StudyYear = c.String(),
                    })
                .PrimaryKey(t => t.YearOfStudyID);
            
            CreateTable(
                "dbo.ProffessionalQualifications",
                c => new
                    {
                        ProffessionalQualificationID = c.Int(nullable: false, identity: true),
                        ProffessionalQualificationName = c.String(),
                        ApplicantID = c.Int(nullable: false),
                        DateObtained = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProffessionalQualificationID)
                .ForeignKey("dbo.Applicants", t => t.ApplicantID, cascadeDelete: false)
                .Index(t => t.ApplicantID);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ContractID = c.Int(nullable: false, identity: true),
                        ContractCode = c.String(),
                        StaffID = c.Int(nullable: false),
                        ContractType = c.String(),
                        ContractStart = c.DateTime(nullable: false),
                        ContractEnd = c.DateTime(nullable: false),
                        JobID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContractID)
                .ForeignKey("dbo.Jobs", t => t.JobID, cascadeDelete: false)
                .ForeignKey("dbo.Staffs", t => t.StaffID, cascadeDelete: false)
                .Index(t => t.StaffID)
                .Index(t => t.JobID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobID = c.Int(nullable: false, identity: true),
                        JobName = c.String(),
                        JobDescription = c.String(),
                        JobAcademicRequirements = c.String(),
                        RequirementDescription = c.String(),
                        AllowanceGradeID = c.Int(nullable: false),
                        SalaryScaleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobID)
                .ForeignKey("dbo.AllowanceScales", t => t.AllowanceGradeID, cascadeDelete: false)
                .ForeignKey("dbo.SalaryScales", t => t.SalaryScaleID, cascadeDelete: false)
                .Index(t => t.AllowanceGradeID)
                .Index(t => t.SalaryScaleID);
            
            CreateTable(
                "dbo.AllowanceScales",
                c => new
                    {
                        AllowanceScaleID = c.Int(nullable: false, identity: true),
                        AllowanceScaleCode = c.String(),
                        HousingAllowance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PerDM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FuelAllowance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Airtime = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.AllowanceScaleID);
            
            CreateTable(
                "dbo.SalaryScales",
                c => new
                    {
                        SalaryScaleID = c.Int(nullable: false, identity: true),
                        SalaryScaleName = c.String(),
                        SalaryAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SalaryScaleID);
            
            CreateTable(
                "dbo.Depts",
                c => new
                    {
                        DeptID = c.Int(nullable: false, identity: true),
                        DeptName = c.String(),
                        DeptCode = c.String(),
                    })
                .PrimaryKey(t => t.DeptID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProgCourses", "YearOfStudyID", "dbo.YearOfStudies");
            DropForeignKey("dbo.ProgCourses", "SemesterID", "dbo.Semesters");
            DropForeignKey("dbo.ProgCourses", "ProgramID", "dbo.Programs");
            DropForeignKey("dbo.ProgCourses", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Results", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.CourseAllocations", "StaffID", "dbo.Staffs");
            DropForeignKey("dbo.Staffs", "Nationality_NationalityID", "dbo.Nationalities");
            DropForeignKey("dbo.Contracts", "StaffID", "dbo.Staffs");
            DropForeignKey("dbo.Contracts", "JobID", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "SalaryScaleID", "dbo.SalaryScales");
            DropForeignKey("dbo.Jobs", "AllowanceGradeID", "dbo.AllowanceScales");
            DropForeignKey("dbo.Addresses", "Staff_StaffID", "dbo.Staffs");
            DropForeignKey("dbo.Addresses", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Addresses", "ApplicantID", "dbo.Applicants");
            DropForeignKey("dbo.ProffessionalQualifications", "ApplicantID", "dbo.Applicants");
            DropForeignKey("dbo.Preferences", "ProgramID", "dbo.Programs");
            DropForeignKey("dbo.Programs", "FacultyID", "dbo.Faculties");
            DropForeignKey("dbo.SemRegistrations", "SemesterID", "dbo.Semesters");
            DropForeignKey("dbo.Results", "YearOfStudyID", "dbo.YearOfStudies");
            DropForeignKey("dbo.SemRegistrations", "YearOfStudyID", "dbo.YearOfStudies");
            DropForeignKey("dbo.CourseAllocations", "YearOfStudy_YearOfStudyID", "dbo.YearOfStudies");
            DropForeignKey("dbo.Results", "SemesterID", "dbo.Semesters");
            DropForeignKey("dbo.Results", "ExaminationID", "dbo.Examinations");
            DropForeignKey("dbo.Examinations", "CourseWorkID", "dbo.CourseWorks");
            DropForeignKey("dbo.Examinations", "CourseAllocationID", "dbo.CourseAllocations");
            DropForeignKey("dbo.Results", "CourseWorkID", "dbo.CourseWorks");
            DropForeignKey("dbo.CourseWorks", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Results", "CommentID", "dbo.Comments");
            DropForeignKey("dbo.Results", "AcademicYearID", "dbo.AcademicYears");
            DropForeignKey("dbo.SemRegistrations", "ProgramID", "dbo.Programs");
            DropForeignKey("dbo.Students", "ModeOfStudy_ModeOfStudyID", "dbo.ModeOfStudies");
            DropForeignKey("dbo.SemRegistrations", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Students", "ProgramID", "dbo.Programs");
            DropForeignKey("dbo.Students", "PreferenceID", "dbo.Preferences");
            DropForeignKey("dbo.Students", "ApplicantID", "dbo.Applicants");
            DropForeignKey("dbo.SemRegistrations", "ModeOfStudyID", "dbo.ModeOfStudies");
            DropForeignKey("dbo.ProgClasses", "ProgramID", "dbo.Programs");
            DropForeignKey("dbo.ProgClasses", "ModeOfStudyID", "dbo.ModeOfStudies");
            DropForeignKey("dbo.SemRegistrations", "FacultyDepartmentID", "dbo.FacultyDepartments");
            DropForeignKey("dbo.SemRegistrations", "FacultyID", "dbo.Faculties");
            DropForeignKey("dbo.SemRegistrations", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.SemRegistrations", "AcademicYearID", "dbo.AcademicYears");
            DropForeignKey("dbo.Programs", "FacultyDepartmentID", "dbo.FacultyDepartments");
            DropForeignKey("dbo.FacultyDepartments", "Faculty_FacultyID", "dbo.Faculties");
            DropForeignKey("dbo.Lecturers", "StaffID", "dbo.Staffs");
            DropForeignKey("dbo.Faculties", "LecturerID", "dbo.Lecturers");
            DropForeignKey("dbo.Courses", "ProgramID", "dbo.Programs");
            DropForeignKey("dbo.Preferences", "ApplicantID", "dbo.Applicants");
            DropForeignKey("dbo.Applicants", "NationalityID", "dbo.Nationalities");
            DropForeignKey("dbo.FormerEmployments", "ApplicantID", "dbo.Applicants");
            DropForeignKey("dbo.CorrespondenceAddresses", "Country_CountryID", "dbo.Countries");
            DropForeignKey("dbo.StaffAddresses", "StaffID", "dbo.Staffs");
            DropForeignKey("dbo.StaffAddresses", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Applicants", "Country_CountryID", "dbo.Countries");
            DropForeignKey("dbo.CorrespondenceAddresses", "ApplicantID", "dbo.Applicants");
            DropForeignKey("dbo.AlevelDocs", "Level_LevelID", "dbo.Levels");
            DropForeignKey("dbo.AlevelDocs", "DocumentID", "dbo.Documents");
            DropForeignKey("dbo.AlevelDocs", "ApplicantID", "dbo.Applicants");
            DropForeignKey("dbo.AlevelSubjects", "SubjectGradeID", "dbo.SubjectGrades");
            DropForeignKey("dbo.AlevelSubjects", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.AlevelSubjects", "GradeID", "dbo.Grades");
            DropForeignKey("dbo.OlevelSubjects", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.OlevelSubjects", "OlevelDocsID", "dbo.OlevelDocs");
            DropForeignKey("dbo.OlevelDocs", "LevelID", "dbo.Levels");
            DropForeignKey("dbo.OlevelDocs", "ExaminingAuthorityID", "dbo.ExaminingAuthorities");
            DropForeignKey("dbo.ExaminingAuthorities", "ExaminingAuthority_ExaminingAuthorityID", "dbo.ExaminingAuthorities");
            DropForeignKey("dbo.OtherDocs", "DocumentID", "dbo.Documents");
            DropForeignKey("dbo.OtherDocs", "ApplicantID", "dbo.Applicants");
            DropForeignKey("dbo.OlevelDocs", "DocumentID", "dbo.Documents");
            DropForeignKey("dbo.OlevelDocs", "ApplicantID", "dbo.Applicants");
            DropForeignKey("dbo.OlevelSubjects", "GradeID", "dbo.Grades");
            DropForeignKey("dbo.OlevelSubjects", "ApplicantID", "dbo.Applicants");
            DropForeignKey("dbo.AlevelSubjects", "ApplicantID", "dbo.Applicants");
            DropForeignKey("dbo.AlevelSubjects", "AlevelDocID", "dbo.AlevelDocs");
            DropForeignKey("dbo.Applicants", "AdmissionStatusID", "dbo.AdmissionStatus");
            DropForeignKey("dbo.CourseAllocations", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.ProgCourses", "AcademicYearID", "dbo.AcademicYears");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Jobs", new[] { "SalaryScaleID" });
            DropIndex("dbo.Jobs", new[] { "AllowanceGradeID" });
            DropIndex("dbo.Contracts", new[] { "JobID" });
            DropIndex("dbo.Contracts", new[] { "StaffID" });
            DropIndex("dbo.ProffessionalQualifications", new[] { "ApplicantID" });
            DropIndex("dbo.Examinations", new[] { "CourseWorkID" });
            DropIndex("dbo.Examinations", new[] { "CourseAllocationID" });
            DropIndex("dbo.CourseWorks", new[] { "CourseID" });
            DropIndex("dbo.Results", new[] { "Course_CourseID" });
            DropIndex("dbo.Results", new[] { "ExaminationID" });
            DropIndex("dbo.Results", new[] { "CourseWorkID" });
            DropIndex("dbo.Results", new[] { "YearOfStudyID" });
            DropIndex("dbo.Results", new[] { "SemesterID" });
            DropIndex("dbo.Results", new[] { "AcademicYearID" });
            DropIndex("dbo.Results", new[] { "CommentID" });
            DropIndex("dbo.Students", new[] { "ModeOfStudy_ModeOfStudyID" });
            DropIndex("dbo.Students", new[] { "ProgramID" });
            DropIndex("dbo.Students", new[] { "PreferenceID" });
            DropIndex("dbo.Students", new[] { "ApplicantID" });
            DropIndex("dbo.ProgClasses", new[] { "ModeOfStudyID" });
            DropIndex("dbo.ProgClasses", new[] { "ProgramID" });
            DropIndex("dbo.SemRegistrations", new[] { "CourseID" });
            DropIndex("dbo.SemRegistrations", new[] { "SemesterID" });
            DropIndex("dbo.SemRegistrations", new[] { "YearOfStudyID" });
            DropIndex("dbo.SemRegistrations", new[] { "AcademicYearID" });
            DropIndex("dbo.SemRegistrations", new[] { "FacultyDepartmentID" });
            DropIndex("dbo.SemRegistrations", new[] { "FacultyID" });
            DropIndex("dbo.SemRegistrations", new[] { "ProgramID" });
            DropIndex("dbo.SemRegistrations", new[] { "ModeOfStudyID" });
            DropIndex("dbo.SemRegistrations", new[] { "StudentID" });
            DropIndex("dbo.FacultyDepartments", new[] { "Faculty_FacultyID" });
            DropIndex("dbo.Lecturers", new[] { "StaffID" });
            DropIndex("dbo.Faculties", new[] { "LecturerID" });
            DropIndex("dbo.Programs", new[] { "FacultyDepartmentID" });
            DropIndex("dbo.Programs", new[] { "FacultyID" });
            DropIndex("dbo.Preferences", new[] { "ProgramID" });
            DropIndex("dbo.Preferences", new[] { "ApplicantID" });
            DropIndex("dbo.FormerEmployments", new[] { "ApplicantID" });
            DropIndex("dbo.StaffAddresses", new[] { "CountryID" });
            DropIndex("dbo.StaffAddresses", new[] { "StaffID" });
            DropIndex("dbo.CorrespondenceAddresses", new[] { "Country_CountryID" });
            DropIndex("dbo.CorrespondenceAddresses", new[] { "ApplicantID" });
            DropIndex("dbo.ExaminingAuthorities", new[] { "ExaminingAuthority_ExaminingAuthorityID" });
            DropIndex("dbo.OtherDocs", new[] { "ApplicantID" });
            DropIndex("dbo.OtherDocs", new[] { "DocumentID" });
            DropIndex("dbo.OlevelDocs", new[] { "LevelID" });
            DropIndex("dbo.OlevelDocs", new[] { "ExaminingAuthorityID" });
            DropIndex("dbo.OlevelDocs", new[] { "DocumentID" });
            DropIndex("dbo.OlevelDocs", new[] { "ApplicantID" });
            DropIndex("dbo.OlevelSubjects", new[] { "GradeID" });
            DropIndex("dbo.OlevelSubjects", new[] { "SubjectID" });
            DropIndex("dbo.OlevelSubjects", new[] { "OlevelDocsID" });
            DropIndex("dbo.OlevelSubjects", new[] { "ApplicantID" });
            DropIndex("dbo.AlevelSubjects", new[] { "SubjectGradeID" });
            DropIndex("dbo.AlevelSubjects", new[] { "GradeID" });
            DropIndex("dbo.AlevelSubjects", new[] { "SubjectID" });
            DropIndex("dbo.AlevelSubjects", new[] { "AlevelDocID" });
            DropIndex("dbo.AlevelSubjects", new[] { "ApplicantID" });
            DropIndex("dbo.AlevelDocs", new[] { "Level_LevelID" });
            DropIndex("dbo.AlevelDocs", new[] { "ApplicantID" });
            DropIndex("dbo.AlevelDocs", new[] { "DocumentID" });
            DropIndex("dbo.Applicants", new[] { "Country_CountryID" });
            DropIndex("dbo.Applicants", new[] { "AdmissionStatusID" });
            DropIndex("dbo.Applicants", new[] { "NationalityID" });
            DropIndex("dbo.Addresses", new[] { "Staff_StaffID" });
            DropIndex("dbo.Addresses", new[] { "CountryID" });
            DropIndex("dbo.Addresses", new[] { "ApplicantID" });
            DropIndex("dbo.Staffs", new[] { "Nationality_NationalityID" });
            DropIndex("dbo.CourseAllocations", new[] { "YearOfStudy_YearOfStudyID" });
            DropIndex("dbo.CourseAllocations", new[] { "CourseID" });
            DropIndex("dbo.CourseAllocations", new[] { "StaffID" });
            DropIndex("dbo.Courses", new[] { "ProgramID" });
            DropIndex("dbo.ProgCourses", new[] { "YearOfStudyID" });
            DropIndex("dbo.ProgCourses", new[] { "SemesterID" });
            DropIndex("dbo.ProgCourses", new[] { "AcademicYearID" });
            DropIndex("dbo.ProgCourses", new[] { "CourseID" });
            DropIndex("dbo.ProgCourses", new[] { "ProgramID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Depts");
            DropTable("dbo.SalaryScales");
            DropTable("dbo.AllowanceScales");
            DropTable("dbo.Jobs");
            DropTable("dbo.Contracts");
            DropTable("dbo.ProffessionalQualifications");
            DropTable("dbo.YearOfStudies");
            DropTable("dbo.Examinations");
            DropTable("dbo.CourseWorks");
            DropTable("dbo.Comments");
            DropTable("dbo.Results");
            DropTable("dbo.Semesters");
            DropTable("dbo.Students");
            DropTable("dbo.ProgClasses");
            DropTable("dbo.ModeOfStudies");
            DropTable("dbo.SemRegistrations");
            DropTable("dbo.FacultyDepartments");
            DropTable("dbo.Lecturers");
            DropTable("dbo.Faculties");
            DropTable("dbo.Programs");
            DropTable("dbo.Preferences");
            DropTable("dbo.Nationalities");
            DropTable("dbo.FormerEmployments");
            DropTable("dbo.StaffAddresses");
            DropTable("dbo.Countries");
            DropTable("dbo.CorrespondenceAddresses");
            DropTable("dbo.SubjectGrades");
            DropTable("dbo.Subjects");
            DropTable("dbo.Levels");
            DropTable("dbo.ExaminingAuthorities");
            DropTable("dbo.OtherDocs");
            DropTable("dbo.Documents");
            DropTable("dbo.OlevelDocs");
            DropTable("dbo.OlevelSubjects");
            DropTable("dbo.Grades");
            DropTable("dbo.AlevelSubjects");
            DropTable("dbo.AlevelDocs");
            DropTable("dbo.AdmissionStatus");
            DropTable("dbo.Applicants");
            DropTable("dbo.Addresses");
            DropTable("dbo.Staffs");
            DropTable("dbo.CourseAllocations");
            DropTable("dbo.Courses");
            DropTable("dbo.ProgCourses");
            DropTable("dbo.AcademicYears");
        }
    }
}
