namespace CobaltElectronics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Proizvods", "ImgURL", c => c.String(nullable: false));
            AlterColumn("dbo.Proizvods", "Ime", c => c.String(nullable: false));
            AlterColumn("dbo.Proizvods", "Proizvoditel", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Proizvods", "Proizvoditel", c => c.String());
            AlterColumn("dbo.Proizvods", "Ime", c => c.String());
            AlterColumn("dbo.Proizvods", "ImgURL", c => c.String());
        }
    }
}
