namespace ProIcuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adoc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AlevelDocs", "Level_LevelID", "dbo.Levels");
            DropIndex("dbo.AlevelDocs", new[] { "Level_LevelID" });
            AddColumn("dbo.AlevelDocs", "ExaminingAuthorityID", c => c.Int(nullable: false));
            AlterColumn("dbo.AlevelDocs", "ExaminationYear", c => c.String());
            CreateIndex("dbo.AlevelDocs", "ExaminingAuthorityID");
            AddForeignKey("dbo.AlevelDocs", "ExaminingAuthorityID", "dbo.ExaminingAuthorities", "ExaminingAuthorityID", cascadeDelete: false);
            DropColumn("dbo.AlevelDocs", "ExaminingAuthority");
            DropColumn("dbo.AlevelDocs", "Program");
            DropColumn("dbo.AlevelDocs", "Level_LevelID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AlevelDocs", "Level_LevelID", c => c.Int());
            AddColumn("dbo.AlevelDocs", "Program", c => c.String());
            AddColumn("dbo.AlevelDocs", "ExaminingAuthority", c => c.String());
            DropForeignKey("dbo.AlevelDocs", "ExaminingAuthorityID", "dbo.ExaminingAuthorities");
            DropIndex("dbo.AlevelDocs", new[] { "ExaminingAuthorityID" });
            AlterColumn("dbo.AlevelDocs", "ExaminationYear", c => c.DateTime(nullable: false));
            DropColumn("dbo.AlevelDocs", "ExaminingAuthorityID");
            CreateIndex("dbo.AlevelDocs", "Level_LevelID");
            AddForeignKey("dbo.AlevelDocs", "Level_LevelID", "dbo.Levels", "LevelID");
        }
    }
}
