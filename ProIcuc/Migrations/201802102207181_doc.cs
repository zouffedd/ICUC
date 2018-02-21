namespace ProIcuc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OlevelDocs", "DocumentID", "dbo.Documents");
            DropIndex("dbo.OlevelDocs", new[] { "DocumentID" });
            RenameColumn(table: "dbo.OlevelDocs", name: "DocumentID", newName: "Document_DocumentID");
            AddColumn("dbo.OlevelDocs", "DocName", c => c.String());
            AlterColumn("dbo.OlevelDocs", "Document_DocumentID", c => c.Int());
            CreateIndex("dbo.OlevelDocs", "Document_DocumentID");
            AddForeignKey("dbo.OlevelDocs", "Document_DocumentID", "dbo.Documents", "DocumentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OlevelDocs", "Document_DocumentID", "dbo.Documents");
            DropIndex("dbo.OlevelDocs", new[] { "Document_DocumentID" });
            AlterColumn("dbo.OlevelDocs", "Document_DocumentID", c => c.Int(nullable: false));
            DropColumn("dbo.OlevelDocs", "DocName");
            RenameColumn(table: "dbo.OlevelDocs", name: "Document_DocumentID", newName: "DocumentID");
            CreateIndex("dbo.OlevelDocs", "DocumentID");
            AddForeignKey("dbo.OlevelDocs", "DocumentID", "dbo.Documents", "DocumentID", cascadeDelete: false);
        }
    }
}
