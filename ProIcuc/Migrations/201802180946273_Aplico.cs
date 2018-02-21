namespace ProIcuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aplico : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OlevelDocs", "LevelID", "dbo.Levels");
            DropForeignKey("dbo.AlevelDocs", "LevelID", "dbo.Levels");
            DropForeignKey("dbo.CorrespondenceAddresses", "ApplicantID", "dbo.Applicants");
            DropForeignKey("dbo.CorrespondenceAddresses", "Country_CountryID", "dbo.Countries");
            DropForeignKey("dbo.FormerEmployments", "ApplicantID", "dbo.Applicants");
            DropForeignKey("dbo.Applicants", "NationalityID", "dbo.Nationalities");
            DropForeignKey("dbo.OtherDocs", "ApplicantID", "dbo.Applicants");
            DropForeignKey("dbo.ProffessionalQualifications", "ApplicantID", "dbo.Applicants");
            DropForeignKey("dbo.Addresses", "ApplicantID", "dbo.Applicants");
            DropForeignKey("dbo.Addresses", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Addresses", "Staff_StaffID", "dbo.Staffs");
            DropForeignKey("dbo.Staffs", "Nationality_NationalityID", "dbo.Nationalities");
            DropForeignKey("dbo.AlevelSubjects", "SubjectGrade_SubjectGradeID", "dbo.SubjectGrades");
            DropForeignKey("dbo.Applicants", "AdmissionStatusID", "dbo.AdmissionStatus");
            DropIndex("dbo.Staffs", new[] { "Nationality_NationalityID" });
            DropIndex("dbo.Addresses", new[] { "ApplicantID" });
            DropIndex("dbo.Addresses", new[] { "CountryID" });
            DropIndex("dbo.Addresses", new[] { "Staff_StaffID" });
            DropIndex("dbo.Applicants", new[] { "NationalityID" });
            DropIndex("dbo.Applicants", new[] { "AdmissionStatusID" });
            DropIndex("dbo.AlevelDocs", new[] { "LevelID" });
            DropIndex("dbo.AlevelSubjects", new[] { "SubjectGrade_SubjectGradeID" });
            DropIndex("dbo.OlevelDocs", new[] { "LevelID" });
            DropIndex("dbo.CorrespondenceAddresses", new[] { "ApplicantID" });
            DropIndex("dbo.CorrespondenceAddresses", new[] { "Country_CountryID" });
            DropIndex("dbo.FormerEmployments", new[] { "ApplicantID" });
            DropIndex("dbo.OtherDocs", new[] { "ApplicantID" });
            DropIndex("dbo.ProffessionalQualifications", new[] { "ApplicantID" });
            RenameColumn(table: "dbo.Applicants", name: "AdmissionStatusID", newName: "AdmissionStatus_AdmissionStatusID");
            CreateTable(
                "dbo.GivenPrograms",
                c => new
                    {
                        GivenProgramID = c.Int(nullable: false, identity: true),
                        ApplicantID = c.Int(nullable: false),
                        ProgramID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GivenProgramID)
                .ForeignKey("dbo.Applicants", t => t.ApplicantID)
                .ForeignKey("dbo.Programs", t => t.ProgramID)
                .Index(t => t.ApplicantID)
                .Index(t => t.ProgramID);
            
            AddColumn("dbo.Applicants", "Title", c => c.String());
            AddColumn("dbo.Applicants", "CountryOfBirth", c => c.String(nullable: false));
            AddColumn("dbo.Applicants", "CountrOfResidence", c => c.String(nullable: false));
            AddColumn("dbo.Applicants", "Nationlt", c => c.String());
            AddColumn("dbo.Applicants", "HomeAddress", c => c.String());
            AddColumn("dbo.Applicants", "PostalAddress", c => c.String());
            AddColumn("dbo.Applicants", "City", c => c.String());
            AddColumn("dbo.Applicants", "PostCode", c => c.String());
            AddColumn("dbo.Applicants", "CorHomeAddress", c => c.String());
            AddColumn("dbo.Applicants", "CorPostalAddress", c => c.String());
            AddColumn("dbo.Applicants", "CorCity", c => c.String());
            AddColumn("dbo.Applicants", "CorPostCode", c => c.String());
            AddColumn("dbo.Applicants", "CorTelNo", c => c.String());
            AddColumn("dbo.Applicants", "CorEmail", c => c.String());
            AddColumn("dbo.Applicants", "InstitutionNameAndAddress", c => c.String());
            AddColumn("dbo.Applicants", "QualificationObtained", c => c.String());
            AddColumn("dbo.Applicants", "QualificationObtainedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Applicants", "Session", c => c.Int(nullable: false));
            AddColumn("dbo.Applicants", "EmployerName", c => c.String());
            AddColumn("dbo.Applicants", "PositionAndWorkCarriedOut", c => c.String());
            AddColumn("dbo.Applicants", "From", c => c.DateTime(nullable: false));
            AddColumn("dbo.Applicants", "To", c => c.DateTime(nullable: false));
            AddColumn("dbo.Applicants", "ProffessionalQualificationName", c => c.String());
            AddColumn("dbo.Applicants", "DateObtained", c => c.DateTime(nullable: false));
            AddColumn("dbo.Applicants", "EnglishLanguageQualification", c => c.Boolean(nullable: false));
            AddColumn("dbo.Applicants", "EngQualificName", c => c.String());
            AddColumn("dbo.Applicants", "EngQualificNameDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Applicants", "AdminState", c => c.Int(nullable: false));
            AlterColumn("dbo.Applicants", "FirstName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Applicants", "DOB", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Applicants", "EntryYear", c => c.Int(nullable: false));
            AlterColumn("dbo.Applicants", "AdmissionStatus_AdmissionStatusID", c => c.Int());
            CreateIndex("dbo.Applicants", "AdmissionStatus_AdmissionStatusID");
            AddForeignKey("dbo.Applicants", "AdmissionStatus_AdmissionStatusID", "dbo.AdmissionStatus", "AdmissionStatusID");
            DropColumn("dbo.Staffs", "Nationality_NationalityID");
            DropColumn("dbo.Applicants", "NationalityID");
            DropColumn("dbo.AlevelDocs", "LevelID");
            DropColumn("dbo.AlevelSubjects", "SubjectGrade_SubjectGradeID");
            DropColumn("dbo.OlevelDocs", "LevelID");
            DropTable("dbo.Addresses");
            DropTable("dbo.Levels");
            DropTable("dbo.CorrespondenceAddresses");
            DropTable("dbo.FormerEmployments");
            DropTable("dbo.Nationalities");
            DropTable("dbo.OtherDocs");
            DropTable("dbo.ProffessionalQualifications");
            DropTable("dbo.SubjectGrades");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubjectGrades",
                c => new
                    {
                        SubjectGradeID = c.Int(nullable: false, identity: true),
                        SubjectGradeName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectGradeID);
            
            CreateTable(
                "dbo.ProffessionalQualifications",
                c => new
                    {
                        ProffessionalQualificationID = c.Int(nullable: false, identity: true),
                        ProffessionalQualificationName = c.String(),
                        ApplicantID = c.Int(nullable: false),
                        DateObtained = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProffessionalQualificationID);
            
            CreateTable(
                "dbo.OtherDocs",
                c => new
                    {
                        OtherDocID = c.Int(nullable: false, identity: true),
                        QualificationObtained = c.String(),
                        ApplicantID = c.Int(nullable: false),
                        InstitutionNameAndAddress = c.String(),
                        YearOfExamination = c.String(),
                        Session = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OtherDocID);
            
            CreateTable(
                "dbo.Nationalities",
                c => new
                    {
                        NationalityID = c.Int(nullable: false, identity: true),
                        NationalityName = c.String(),
                    })
                .PrimaryKey(t => t.NationalityID);
            
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
                .PrimaryKey(t => t.FormerEmploymentID);
            
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
                .PrimaryKey(t => t.CorrespondenceAddressID);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        LevelID = c.Int(nullable: false, identity: true),
                        LevelName = c.String(),
                    })
                .PrimaryKey(t => t.LevelID);
            
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
                .PrimaryKey(t => t.AddressID);
            
            AddColumn("dbo.OlevelDocs", "LevelID", c => c.Int(nullable: false));
            AddColumn("dbo.AlevelSubjects", "SubjectGrade_SubjectGradeID", c => c.Int());
            AddColumn("dbo.AlevelDocs", "LevelID", c => c.Int(nullable: false));
            AddColumn("dbo.Applicants", "NationalityID", c => c.Int(nullable: false));
            AddColumn("dbo.Staffs", "Nationality_NationalityID", c => c.Int());
            DropForeignKey("dbo.Applicants", "AdmissionStatus_AdmissionStatusID", "dbo.AdmissionStatus");
            DropForeignKey("dbo.GivenPrograms", "ProgramID", "dbo.Programs");
            DropForeignKey("dbo.GivenPrograms", "ApplicantID", "dbo.Applicants");
            DropIndex("dbo.Applicants", new[] { "AdmissionStatus_AdmissionStatusID" });
            DropIndex("dbo.GivenPrograms", new[] { "ProgramID" });
            DropIndex("dbo.GivenPrograms", new[] { "ApplicantID" });
            AlterColumn("dbo.Applicants", "AdmissionStatus_AdmissionStatusID", c => c.Int(nullable: false));
            AlterColumn("dbo.Applicants", "EntryYear", c => c.String());
            AlterColumn("dbo.Applicants", "DOB", c => c.String());
            AlterColumn("dbo.Applicants", "FirstName", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.Applicants", "AdminState");
            DropColumn("dbo.Applicants", "EngQualificNameDate");
            DropColumn("dbo.Applicants", "EngQualificName");
            DropColumn("dbo.Applicants", "EnglishLanguageQualification");
            DropColumn("dbo.Applicants", "DateObtained");
            DropColumn("dbo.Applicants", "ProffessionalQualificationName");
            DropColumn("dbo.Applicants", "To");
            DropColumn("dbo.Applicants", "From");
            DropColumn("dbo.Applicants", "PositionAndWorkCarriedOut");
            DropColumn("dbo.Applicants", "EmployerName");
            DropColumn("dbo.Applicants", "Session");
            DropColumn("dbo.Applicants", "QualificationObtainedDate");
            DropColumn("dbo.Applicants", "QualificationObtained");
            DropColumn("dbo.Applicants", "InstitutionNameAndAddress");
            DropColumn("dbo.Applicants", "CorEmail");
            DropColumn("dbo.Applicants", "CorTelNo");
            DropColumn("dbo.Applicants", "CorPostCode");
            DropColumn("dbo.Applicants", "CorCity");
            DropColumn("dbo.Applicants", "CorPostalAddress");
            DropColumn("dbo.Applicants", "CorHomeAddress");
            DropColumn("dbo.Applicants", "PostCode");
            DropColumn("dbo.Applicants", "City");
            DropColumn("dbo.Applicants", "PostalAddress");
            DropColumn("dbo.Applicants", "HomeAddress");
            DropColumn("dbo.Applicants", "Nationlt");
            DropColumn("dbo.Applicants", "CountrOfResidence");
            DropColumn("dbo.Applicants", "CountryOfBirth");
            DropColumn("dbo.Applicants", "Title");
            DropTable("dbo.GivenPrograms");
            RenameColumn(table: "dbo.Applicants", name: "AdmissionStatus_AdmissionStatusID", newName: "AdmissionStatusID");
            CreateIndex("dbo.ProffessionalQualifications", "ApplicantID");
            CreateIndex("dbo.OtherDocs", "ApplicantID");
            CreateIndex("dbo.FormerEmployments", "ApplicantID");
            CreateIndex("dbo.CorrespondenceAddresses", "Country_CountryID");
            CreateIndex("dbo.CorrespondenceAddresses", "ApplicantID");
            CreateIndex("dbo.OlevelDocs", "LevelID");
            CreateIndex("dbo.AlevelSubjects", "SubjectGrade_SubjectGradeID");
            CreateIndex("dbo.AlevelDocs", "LevelID");
            CreateIndex("dbo.Applicants", "AdmissionStatusID");
            CreateIndex("dbo.Applicants", "NationalityID");
            CreateIndex("dbo.Addresses", "Staff_StaffID");
            CreateIndex("dbo.Addresses", "CountryID");
            CreateIndex("dbo.Addresses", "ApplicantID");
            CreateIndex("dbo.Staffs", "Nationality_NationalityID");
            AddForeignKey("dbo.Applicants", "AdmissionStatusID", "dbo.AdmissionStatus", "AdmissionStatusID");
            AddForeignKey("dbo.AlevelSubjects", "SubjectGrade_SubjectGradeID", "dbo.SubjectGrades", "SubjectGradeID");
            AddForeignKey("dbo.Staffs", "Nationality_NationalityID", "dbo.Nationalities", "NationalityID");
            AddForeignKey("dbo.Addresses", "Staff_StaffID", "dbo.Staffs", "StaffID");
            AddForeignKey("dbo.Addresses", "CountryID", "dbo.Countries", "CountryID");
            AddForeignKey("dbo.Addresses", "ApplicantID", "dbo.Applicants", "ApplicantID");
            AddForeignKey("dbo.ProffessionalQualifications", "ApplicantID", "dbo.Applicants", "ApplicantID");
            AddForeignKey("dbo.OtherDocs", "ApplicantID", "dbo.Applicants", "ApplicantID", cascadeDelete: true);
            AddForeignKey("dbo.Applicants", "NationalityID", "dbo.Nationalities", "NationalityID");
            AddForeignKey("dbo.FormerEmployments", "ApplicantID", "dbo.Applicants", "ApplicantID");
            AddForeignKey("dbo.CorrespondenceAddresses", "Country_CountryID", "dbo.Countries", "CountryID");
            AddForeignKey("dbo.CorrespondenceAddresses", "ApplicantID", "dbo.Applicants", "ApplicantID");
            AddForeignKey("dbo.AlevelDocs", "LevelID", "dbo.Levels", "LevelID");
            AddForeignKey("dbo.OlevelDocs", "LevelID", "dbo.Levels", "LevelID");
        }
    }
}
