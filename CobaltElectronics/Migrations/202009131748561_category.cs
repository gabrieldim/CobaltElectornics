namespace CobaltElectronics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Proizvods", "Kategorija_Id", "dbo.Kategorijas");
            DropIndex("dbo.Proizvods", new[] { "Kategorija_Id" });
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Proizvods", "Category_Id", c => c.Int());
            CreateIndex("dbo.Proizvods", "Category_Id");
            AddForeignKey("dbo.Proizvods", "Category_Id", "dbo.Categories", "Id");
            DropColumn("dbo.Proizvods", "Kategorija_Id");
            DropTable("dbo.Kategorijas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Kategorijas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Proizvods", "Kategorija_Id", c => c.Int());
            DropForeignKey("dbo.Proizvods", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Proizvods", new[] { "Category_Id" });
            DropColumn("dbo.Proizvods", "Category_Id");
            DropTable("dbo.Categories");
            CreateIndex("dbo.Proizvods", "Kategorija_Id");
            AddForeignKey("dbo.Proizvods", "Kategorija_Id", "dbo.Kategorijas", "Id");
        }
    }
}
