namespace KursMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zamowieniaupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Zamowienie", "Telefon", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Zamowienie", "Telefon", c => c.String());
        }
    }
}
