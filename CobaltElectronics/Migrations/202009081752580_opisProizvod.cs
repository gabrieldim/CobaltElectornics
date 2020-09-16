namespace CobaltElectronics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class opisProizvod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proizvods", "Opis", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Proizvods", "Opis");
        }
    }
}
