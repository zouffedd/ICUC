namespace ProIcuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sujc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AlevelSubjects", "AlevelDocID", "dbo.AlevelDocs");
            DropForeignKey("dbo.AlevelDocs", "ApplicantID", "dbo.Applicants");
            DropForeignKey("dbo.AlevelDocs", "ExaminingAuthorityID", "dbo.ExaminingAuthorities");
            DropForeignKey("dbo.OlevelDocs", "ApplicantID", "dbo.Applicants");
            DropForeignKey("dbo.OlevelDocs", "ExaminingAuthorityID", "dbo.ExaminingAuthorities");
            DropForeignKey("dbo.OlevelSubjects", "OlevelDocsID", "dbo.OlevelDocs");
            DropIndex("dbo.AlevelDocs", new[] { "ApplicantID" });
            DropIndex("dbo.AlevelDocs", new[] { "ExaminingAuthorityID" });
            DropIndex("dbo.AlevelSubjects", new[] { "AlevelDocID" });
            DropIndex("dbo.OlevelDocs", new[] { "ApplicantID" });
            DropIndex("dbo.OlevelDocs", new[] { "ExaminingAuthorityID" });
            DropIndex("dbo.OlevelSubjects", new[] { "OlevelDocsID" });
            DropColumn("dbo.AlevelSubjects", "AlevelDocID");
            DropColumn("dbo.OlevelSubjects", "OlevelDocsID");
            DropTable("dbo.AlevelDocs");
            DropTable("dbo.OlevelDocs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OlevelDocs",
                c => new
                    {
                        OlevelDocID = c.Int(nullable: false, identity: true),
                        DocName = c.String(),
                        ApplicantID = c.Int(nullable: false),
                        ExaminingAuthorityID = c.Int(nullable: false),
                        SchoolNameAndAddress = c.String(nullable: false),
                        ExaminationYear = c.String(nullable: false),
                        IndexNo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OlevelDocID);
            
            CreateTable(
                "dbo.AlevelDocs",
                c => new
                    {
                        AlevelDocID = c.Int(nullable: false, identity: true),
                        AlevelDocName = c.String(),
                        ApplicantID = c.Int(nullable: false),
                        ExaminingAuthorityID = c.Int(nullable: false),
                        SchoolNameAndAddress = c.String(),
                        ExaminationYear = c.String(),
                        IndexNo = c.String(),
                    })
                .PrimaryKey(t => t.AlevelDocID);
            
            AddColumn("dbo.OlevelSubjects", "OlevelDocsID", c => c.Int(nullable: false));
            AddColumn("dbo.AlevelSubjects", "AlevelDocID", c => c.Int(nullable: false));
            CreateIndex("dbo.OlevelSubjects", "OlevelDocsID");
            CreateIndex("dbo.OlevelDocs", "ExaminingAuthorityID");
            CreateIndex("dbo.OlevelDocs", "ApplicantID");
            CreateIndex("dbo.AlevelSubjects", "AlevelDocID");
            CreateIndex("dbo.AlevelDocs", "ExaminingAuthorityID");
            CreateIndex("dbo.AlevelDocs", "ApplicantID");
            AddForeignKey("dbo.OlevelSubjects", "OlevelDocsID", "dbo.OlevelDocs", "OlevelDocID");
            AddForeignKey("dbo.OlevelDocs", "ExaminingAuthorityID", "dbo.ExaminingAuthorities", "ExaminingAuthorityID");
            AddForeignKey("dbo.OlevelDocs", "ApplicantID", "dbo.Applicants", "ApplicantID");
            AddForeignKey("dbo.AlevelDocs", "ExaminingAuthorityID", "dbo.ExaminingAuthorities", "ExaminingAuthorityID");
            AddForeignKey("dbo.AlevelDocs", "ApplicantID", "dbo.Applicants", "ApplicantID");
            AddForeignKey("dbo.AlevelSubjects", "AlevelDocID", "dbo.AlevelDocs", "AlevelDocID");
        }
    }
}
