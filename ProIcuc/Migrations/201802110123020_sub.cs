namespace ProIcuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sub : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OlevelSubjects", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.AlevelSubjects", "SubjectID", "dbo.Subjects");
            DropIndex("dbo.AlevelSubjects", new[] { "SubjectID" });
            DropIndex("dbo.OlevelSubjects", new[] { "SubjectID" });
            DropColumn("dbo.AlevelSubjects", "SubjectID");
            DropColumn("dbo.OlevelSubjects", "SubjectID");
            DropTable("dbo.Subjects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            AddColumn("dbo.OlevelSubjects", "SubjectID", c => c.Int(nullable: false));
            AddColumn("dbo.AlevelSubjects", "SubjectID", c => c.Int(nullable: false));
            CreateIndex("dbo.OlevelSubjects", "SubjectID");
            CreateIndex("dbo.AlevelSubjects", "SubjectID");
            AddForeignKey("dbo.AlevelSubjects", "SubjectID", "dbo.Subjects", "SubjectID", cascadeDelete: false);
            AddForeignKey("dbo.OlevelSubjects", "SubjectID", "dbo.Subjects", "SubjectID", cascadeDelete: false);
        }
    }
}
