namespace KursMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategoria",
                c => new
                    {
                        KategoriaID = c.Int(nullable: false, identity: true),
                        NazwaKategori = c.String(nullable: false, maxLength: 100),
                        OpisKategorii = c.String(nullable: false),
                        NazwaPlikuIkony = c.String(),
                    })
                .PrimaryKey(t => t.KategoriaID);
            
            CreateTable(
                "dbo.Kurs",
                c => new
                    {
                        KursID = c.Int(nullable: false, identity: true),
                        KategoriaID = c.Int(nullable: false),
                        TytulKursu = c.String(nullable: false, maxLength: 100),
                        AutorKursu = c.String(nullable: false, maxLength: 100),
                        DataDodania = c.DateTime(nullable: false),
                        NazwaPlikuObrazka = c.String(maxLength: 100),
                        OpisKursu = c.String(),
                        CenaKursu = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bestseller = c.Boolean(nullable: false),
                        Ukryty = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.KursID)
                .ForeignKey("dbo.Kategoria", t => t.KategoriaID, cascadeDelete: true)
                .Index(t => t.KategoriaID);
            
            CreateTable(
                "dbo.PozycjaZamowienia",
                c => new
                    {
                        PozycjaZamowieniaID = c.Int(nullable: false, identity: true),
                        ZamowieniaID = c.Int(nullable: false),
                        KursID = c.Int(nullable: false),
                        Ilosc = c.Int(nullable: false),
                        CenaZakupu = c.Decimal(nullable: false, precision: 18, scale: 2),
                        zamowienie_ZamowienieID = c.Int(),
                    })
                .PrimaryKey(t => t.PozycjaZamowieniaID)
                .ForeignKey("dbo.Kurs", t => t.KursID, cascadeDelete: true)
                .ForeignKey("dbo.Zamowienie", t => t.zamowienie_ZamowienieID)
                .Index(t => t.KursID)
                .Index(t => t.zamowienie_ZamowienieID);
            
            CreateTable(
                "dbo.Zamowienie",
                c => new
                    {
                        ZamowienieID = c.Int(nullable: false, identity: true),
                        Imie = c.String(nullable: false, maxLength: 50),
                        Nazwisko = c.String(nullable: false, maxLength: 50),
                        Ulica = c.String(nullable: false, maxLength: 100),
                        Miasto = c.String(nullable: false, maxLength: 100),
                        KodPocztowy = c.String(nullable: false, maxLength: 6),
                        Telefon = c.String(),
                        Komentarz = c.String(),
                        DataDodania = c.DateTime(nullable: false),
                        StanZamowienia = c.Int(nullable: false),
                        WartoscZamowienia = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ZamowienieID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PozycjaZamowienia", "zamowienie_ZamowienieID", "dbo.Zamowienie");
            DropForeignKey("dbo.PozycjaZamowienia", "KursID", "dbo.Kurs");
            DropForeignKey("dbo.Kurs", "KategoriaID", "dbo.Kategoria");
            DropIndex("dbo.PozycjaZamowienia", new[] { "zamowienie_ZamowienieID" });
            DropIndex("dbo.PozycjaZamowienia", new[] { "KursID" });
            DropIndex("dbo.Kurs", new[] { "KategoriaID" });
            DropTable("dbo.Zamowienie");
            DropTable("dbo.PozycjaZamowienia");
            DropTable("dbo.Kurs");
            DropTable("dbo.Kategoria");
        }
    }
}
