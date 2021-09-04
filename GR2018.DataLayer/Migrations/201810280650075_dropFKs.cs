namespace GR2018.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropFKs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("GR.GiftRegistryMember", "GiftRegistryID", "GR.GiftRegistry");
            DropForeignKey("GR.MemberGift", "MemberID", "GR.Member");
            DropForeignKey("GR.MemberGift", "GiftID", "GR.Gift");
            DropForeignKey("GR.GiftRegistryMember", "MemberID", "GR.Member");
            DropForeignKey("GR.GiftRegistryInvite", "GiftRegistryID", "GR.GiftRegistry");

        }

        public override void Down()
        {
        }
    }
}
