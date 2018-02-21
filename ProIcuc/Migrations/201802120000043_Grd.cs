namespace ProIcuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Grd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlevelSubjects", "SubjectGrade", c => c.String(nullable: false, maxLength: 1));
            AddColumn("dbo.AlevelSubjects", "PaperGrade", c => c.Int(nullable: false));
            AddColumn("dbo.OlevelSubjects", "Grading", c => c.Int(nullable: false));
            AlterColumn("dbo.AlevelSubjects", "AlevelSubjectName", c => c.String(nullable: false));
            AlterColumn("dbo.AlevelSubjects", "PaperNo", c => c.String(nullable: false, maxLength: 1));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AlevelSubjects", "PaperNo", c => c.String());
            AlterColumn("dbo.AlevelSubjects", "AlevelSubjectName", c => c.String());
            DropColumn("dbo.OlevelSubjects", "Grading");
            DropColumn("dbo.AlevelSubjects", "PaperGrade");
            DropColumn("dbo.AlevelSubjects", "SubjectGrade");
        }
    }
}
