namespace CobaltElectronics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryInit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Proizvods", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Proizvods", new[] { "Category_Id" });
            CreateTable(
                "dbo.ProizvodCategories",
                c => new
                    {
                        Proizvod_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Proizvod_Id, t.Category_Id })
                .ForeignKey("dbo.Proizvods", t => t.Proizvod_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Proizvod_Id)
                .Index(t => t.Category_Id);
            
            DropColumn("dbo.Proizvods", "Category_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Proizvods", "Category_Id", c => c.Int());
            DropForeignKey("dbo.ProizvodCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.ProizvodCategories", "Proizvod_Id", "dbo.Proizvods");
            DropIndex("dbo.ProizvodCategories", new[] { "Category_Id" });
            DropIndex("dbo.ProizvodCategories", new[] { "Proizvod_Id" });
            DropTable("dbo.ProizvodCategories");
            CreateIndex("dbo.Proizvods", "Category_Id");
            AddForeignKey("dbo.Proizvods", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
