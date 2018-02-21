namespace ProIcuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vvc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExaminingAuthorities", "ExaminingAuthority_ExaminingAuthorityID", "dbo.ExaminingAuthorities");
            DropIndex("dbo.ExaminingAuthorities", new[] { "ExaminingAuthority_ExaminingAuthorityID" });
            DropColumn("dbo.ExaminingAuthorities", "ExaminingAuthority_ExaminingAuthorityID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExaminingAuthorities", "ExaminingAuthority_ExaminingAuthorityID", c => c.Int());
            CreateIndex("dbo.ExaminingAuthorities", "ExaminingAuthority_ExaminingAuthorityID");
            AddForeignKey("dbo.ExaminingAuthorities", "ExaminingAuthority_ExaminingAuthorityID", "dbo.ExaminingAuthorities", "ExaminingAuthorityID");
        }
    }
}
