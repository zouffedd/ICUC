namespace ProIcuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Grades : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OlevelSubjects", "GradeID", "dbo.Grades");
            DropForeignKey("dbo.AlevelSubjects", "GradeID", "dbo.Grades");
            DropForeignKey("dbo.AlevelSubjects", "SubjectGradeID", "dbo.SubjectGrades");
            DropIndex("dbo.AlevelSubjects", new[] { "GradeID" });
            DropIndex("dbo.AlevelSubjects", new[] { "SubjectGradeID" });
            DropIndex("dbo.OlevelSubjects", new[] { "GradeID" });
            RenameColumn(table: "dbo.AlevelSubjects", name: "SubjectGradeID", newName: "SubjectGrade_SubjectGradeID");
            AlterColumn("dbo.AlevelSubjects", "SubjectGrade_SubjectGradeID", c => c.Int());
            CreateIndex("dbo.AlevelSubjects", "SubjectGrade_SubjectGradeID");
            AddForeignKey("dbo.AlevelSubjects", "SubjectGrade_SubjectGradeID", "dbo.SubjectGrades", "SubjectGradeID");
            DropColumn("dbo.AlevelSubjects", "GradeID");
            DropColumn("dbo.OlevelSubjects", "GradeID");
            DropTable("dbo.Grades");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeID = c.Int(nullable: false, identity: true),
                        GradeName = c.String(),
                    })
                .PrimaryKey(t => t.GradeID);
            
            AddColumn("dbo.OlevelSubjects", "GradeID", c => c.Int(nullable: false));
            AddColumn("dbo.AlevelSubjects", "GradeID", c => c.Int(nullable: false));
            DropForeignKey("dbo.AlevelSubjects", "SubjectGrade_SubjectGradeID", "dbo.SubjectGrades");
            DropIndex("dbo.AlevelSubjects", new[] { "SubjectGrade_SubjectGradeID" });
            AlterColumn("dbo.AlevelSubjects", "SubjectGrade_SubjectGradeID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.AlevelSubjects", name: "SubjectGrade_SubjectGradeID", newName: "SubjectGradeID");
            CreateIndex("dbo.OlevelSubjects", "GradeID");
            CreateIndex("dbo.AlevelSubjects", "SubjectGradeID");
            CreateIndex("dbo.AlevelSubjects", "GradeID");
            AddForeignKey("dbo.AlevelSubjects", "SubjectGradeID", "dbo.SubjectGrades", "SubjectGradeID");
            AddForeignKey("dbo.AlevelSubjects", "GradeID", "dbo.Grades", "GradeID");
            AddForeignKey("dbo.OlevelSubjects", "GradeID", "dbo.Grades", "GradeID");
        }
    }
}
