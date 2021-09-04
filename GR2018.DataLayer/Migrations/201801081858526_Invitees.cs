namespace GR2018.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Invitees : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("GR.GiftRegistryInvite", "GiftRegistryID", "GR.GiftRegistry");
            AlterColumn("GR.GiftRegistryInvite", "InviteeName", c => c.String(unicode: false));
            AlterColumn("GR.GiftRegistryInvite", "Email", c => c.String(unicode: false));
            AddForeignKey("GR.GiftRegistryInvite", "GiftRegistryID", "GR.GiftRegistry", "GiftRegistryID");
        }
        
        public override void Down()
        {
            DropForeignKey("GR.GiftRegistryInvite", "GiftRegistryID", "GR.GiftRegistry");
            AlterColumn("GR.GiftRegistryInvite", "Email", c => c.String());
            AlterColumn("GR.GiftRegistryInvite", "InviteeName", c => c.String());
            AddForeignKey("GR.GiftRegistryInvite", "GiftRegistryID", "GR.GiftRegistry", "GiftRegistryID", cascadeDelete: true);
        }
    }
}
