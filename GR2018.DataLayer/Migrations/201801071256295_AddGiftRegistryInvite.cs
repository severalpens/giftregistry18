namespace GR2018.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGiftRegistryInvite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "GR.GiftRegistryInvite",
                c => new
                    {
                        GiftRegistryInviteID = c.Int(nullable: false, identity: true),
                        GiftRegistryID = c.Int(nullable: false),
                        InviteeName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.GiftRegistryInviteID)
                .ForeignKey("GR.GiftRegistry", t => t.GiftRegistryID, cascadeDelete: true)
                .Index(t => t.GiftRegistryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("GR.GiftRegistryInvite", "GiftRegistryID", "GR.GiftRegistry");
            DropIndex("GR.GiftRegistryInvite", new[] { "GiftRegistryID" });
            DropTable("GR.GiftRegistryInvite");
        }
    }
}
