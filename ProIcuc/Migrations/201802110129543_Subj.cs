namespace ProIcuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Subj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlevelSubjects", "AlevelSubjectName", c => c.String());
            AddColumn("dbo.OlevelSubjects", "OlevelSubjectName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OlevelSubjects", "OlevelSubjectName");
            DropColumn("dbo.AlevelSubjects", "AlevelSubjectName");
        }
    }
}
