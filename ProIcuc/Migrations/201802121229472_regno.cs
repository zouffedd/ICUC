namespace ProIcuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class regno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "RegNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "RegNo");
        }
    }
}
