namespace CobaltElectronics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proizvods", "ImgURL", c => c.String());
            AddColumn("dbo.Proizvods", "Proizvoditel", c => c.String());
            AddColumn("dbo.Proizvods", "DaliNaZaliha", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Proizvods", "DaliNaZaliha");
            DropColumn("dbo.Proizvods", "Proizvoditel");
            DropColumn("dbo.Proizvods", "ImgURL");
        }
    }
}
