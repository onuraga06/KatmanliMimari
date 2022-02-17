namespace Mimari_Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sinifs", "SinifMevcudu", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sinifs", "SinifMevcudu");
        }
    }
}
