namespace ProIcuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stud : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Preferences", "ModeOfStudyID", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "FacultyID", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "FacultyDepartmentID", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Faculty_FacultyID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Preferences", "ModeOfStudyID");
            CreateIndex("dbo.Students", "FacultyDepartmentID");
            CreateIndex("dbo.Students", "Faculty_FacultyID");
            AddForeignKey("dbo.Students", "Faculty_FacultyID", "dbo.Faculties", "FacultyID");
            AddForeignKey("dbo.Students", "FacultyDepartmentID", "dbo.FacultyDepartments", "FacultyDepartmentID");
            AddForeignKey("dbo.Preferences", "ModeOfStudyID", "dbo.ModeOfStudies", "ModeOfStudyID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Preferences", "ModeOfStudyID", "dbo.ModeOfStudies");
            DropForeignKey("dbo.Students", "FacultyDepartmentID", "dbo.FacultyDepartments");
            DropForeignKey("dbo.Students", "Faculty_FacultyID", "dbo.Faculties");
            DropIndex("dbo.Students", new[] { "Faculty_FacultyID" });
            DropIndex("dbo.Students", new[] { "FacultyDepartmentID" });
            DropIndex("dbo.Preferences", new[] { "ModeOfStudyID" });
            DropColumn("dbo.Students", "Faculty_FacultyID");
            DropColumn("dbo.Students", "FacultyDepartmentID");
            DropColumn("dbo.Students", "FacultyID");
            DropColumn("dbo.Preferences", "ModeOfStudyID");
        }
    }
}
