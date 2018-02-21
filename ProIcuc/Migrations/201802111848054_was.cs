namespace ProIcuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class was : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlevelDocs", "LevelID", c => c.Int(nullable: false));
            CreateIndex("dbo.AlevelDocs", "LevelID");
            AddForeignKey("dbo.AlevelDocs", "LevelID", "dbo.Levels", "LevelID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlevelDocs", "LevelID", "dbo.Levels");
            DropIndex("dbo.AlevelDocs", new[] { "LevelID" });
            DropColumn("dbo.AlevelDocs", "LevelID");
        }
    }
}
