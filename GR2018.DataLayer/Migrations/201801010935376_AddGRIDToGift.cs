namespace GR2018.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGRIDToGift : DbMigration
    {
        public override void Up()
        {
            AddColumn("GR.Gift", "GiftRegistryID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("GR.Gift", "GiftRegistryID");
        }
    }
}
