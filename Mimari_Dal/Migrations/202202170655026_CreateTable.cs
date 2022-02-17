namespace Mimari_Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ogrencis",
                c => new
                    {
                        OgrenciID = c.Int(nullable: false, identity: true),
                        OgrenciAd = c.String(nullable: false),
                        OgrenciSoyad = c.String(nullable: false),
                        Adres = c.String(maxLength: 200),
                        Yas = c.DateTime(nullable: false),
                        SinifID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OgrenciID)
                .ForeignKey("dbo.Sinifs", t => t.SinifID, cascadeDelete: true)
                .Index(t => t.SinifID);
            
            CreateTable(
                "dbo.Sinifs",
                c => new
                    {
                        SinifID = c.Int(nullable: false, identity: true),
                        Sube = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SinifID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ogrencis", "SinifID", "dbo.Sinifs");
            DropIndex("dbo.Ogrencis", new[] { "SinifID" });
            DropTable("dbo.Sinifs");
            DropTable("dbo.Ogrencis");
        }
    }
}
