﻿namespace Mimari_Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Asasad : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sinifs", "SinifMevcudu", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sinifs", "SinifMevcudu", c => c.String());
        }
    }
}
