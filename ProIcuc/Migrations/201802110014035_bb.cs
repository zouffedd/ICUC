namespace ProIcuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OlevelDocs", "Document_DocumentID", "dbo.Documents");
            DropForeignKey("dbo.OtherDocs", "DocumentID", "dbo.Documents");
            DropForeignKey("dbo.AlevelDocs", "DocumentID", "dbo.Documents");
            DropIndex("dbo.AlevelDocs", new[] { "DocumentID" });
            DropIndex("dbo.OlevelDocs", new[] { "Document_DocumentID" });
            DropIndex("dbo.OtherDocs", new[] { "DocumentID" });
            AddColumn("dbo.AlevelDocs", "AlevelDocName", c => c.String());
            AddColumn("dbo.OtherDocs", "OtherDocName", c => c.String());
            DropColumn("dbo.AlevelDocs", "DocumentID");
            DropColumn("dbo.OlevelDocs", "Document_DocumentID");
            DropColumn("dbo.OtherDocs", "DocumentID");
            DropTable("dbo.Documents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentID = c.Int(nullable: false, identity: true),
                        DocumentName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.DocumentID);
            
            AddColumn("dbo.OtherDocs", "DocumentID", c => c.Int(nullable: false));
            AddColumn("dbo.OlevelDocs", "Document_DocumentID", c => c.Int());
            AddColumn("dbo.AlevelDocs", "DocumentID", c => c.Int(nullable: false));
            DropColumn("dbo.OtherDocs", "OtherDocName");
            DropColumn("dbo.AlevelDocs", "AlevelDocName");
            CreateIndex("dbo.OtherDocs", "DocumentID");
            CreateIndex("dbo.OlevelDocs", "Document_DocumentID");
            CreateIndex("dbo.AlevelDocs", "DocumentID");
            AddForeignKey("dbo.AlevelDocs", "DocumentID", "dbo.Documents", "DocumentID", cascadeDelete: false);
            AddForeignKey("dbo.OtherDocs", "DocumentID", "dbo.Documents", "DocumentID", cascadeDelete: false);
            AddForeignKey("dbo.OlevelDocs", "Document_DocumentID", "dbo.Documents", "DocumentID");
        }
    }
}
