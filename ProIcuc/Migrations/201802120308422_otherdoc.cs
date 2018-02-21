namespace ProIcuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class otherdoc : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OtherDocs", "YearOfExamination", c => c.String());
            DropColumn("dbo.OtherDocs", "OtherDocName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OtherDocs", "OtherDocName", c => c.String());
            AlterColumn("dbo.OtherDocs", "YearOfExamination", c => c.DateTime(nullable: false));
        }
    }
}
