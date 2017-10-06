namespace KursMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Zamowienia : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Zamowienie", name: "ApplicationUser_Id", newName: "UserID");
            RenameIndex(table: "dbo.Zamowienie", name: "IX_ApplicationUser_Id", newName: "IX_UserID");
            AddColumn("dbo.Zamowienie", "Adres", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Zamowienie", "Email", c => c.String());
            AddColumn("dbo.AspNetUsers", "DaneUzytkownika_KodPocztowy", c => c.String());
            DropColumn("dbo.Zamowienie", "Ulica");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Zamowienie", "Ulica", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.AspNetUsers", "DaneUzytkownika_KodPocztowy");
            DropColumn("dbo.Zamowienie", "Email");
            DropColumn("dbo.Zamowienie", "Adres");
            RenameIndex(table: "dbo.Zamowienie", name: "IX_UserID", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Zamowienie", name: "UserID", newName: "ApplicationUser_Id");
        }
    }
}
