namespace ProIcuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AApl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applicants", "AlevelDocName", c => c.String());
            AddColumn("dbo.Applicants", "ExamAuthorityID", c => c.String());
            AddColumn("dbo.Applicants", "SecSchoolNameAndAddress", c => c.String());
            AddColumn("dbo.Applicants", "SecSchoolExaminationYear", c => c.Int(nullable: false));
            AddColumn("dbo.Applicants", "SecSchoolIndexNo", c => c.String());
            AddColumn("dbo.Applicants", "ODocName", c => c.String());
            AddColumn("dbo.Applicants", "OSchoolNameAndAddress", c => c.String());
            AddColumn("dbo.Applicants", "OExaminatingYear", c => c.Int(nullable: false));
            AddColumn("dbo.Applicants", "OIndexNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applicants", "OIndexNo");
            DropColumn("dbo.Applicants", "OExaminatingYear");
            DropColumn("dbo.Applicants", "OSchoolNameAndAddress");
            DropColumn("dbo.Applicants", "ODocName");
            DropColumn("dbo.Applicants", "SecSchoolIndexNo");
            DropColumn("dbo.Applicants", "SecSchoolExaminationYear");
            DropColumn("dbo.Applicants", "SecSchoolNameAndAddress");
            DropColumn("dbo.Applicants", "ExamAuthorityID");
            DropColumn("dbo.Applicants", "AlevelDocName");
        }
    }
}
