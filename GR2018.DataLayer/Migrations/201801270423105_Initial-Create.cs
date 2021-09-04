namespace GR2018.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "GR.GiftRegistry",
                c => new
                    {
                        GiftRegistryID = c.Int(nullable: false, identity: true),
                        GiftRegistryName = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.GiftRegistryID);
            
            CreateTable(
                "GR.GiftRegistryInvite",
                c => new
                    {
                        GiftRegistryInviteID = c.Int(nullable: false, identity: true),
                        GiftRegistryID = c.Int(nullable: false),
                        InviteeName = c.String(unicode: false),
                        Email = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.GiftRegistryInviteID)
                .ForeignKey("GR.GiftRegistry", t => t.GiftRegistryID)
                .Index(t => t.GiftRegistryID);
            
            CreateTable(
                "GR.GiftRegistryMember",
                c => new
                    {
                        GiftRegistryMemberID = c.Int(nullable: false, identity: true),
                        GiftRegistryID = c.Int(nullable: false),
                        MemberID = c.Int(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GiftRegistryMemberID)
                .ForeignKey("GR.Member", t => t.MemberID)
                .ForeignKey("GR.GiftRegistry", t => t.GiftRegistryID)
                .Index(t => t.GiftRegistryID)
                .Index(t => t.MemberID);
            
            CreateTable(
                "GR.Member",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        MemberName = c.String(maxLength: 500, unicode: false),
                        MemberEmail = c.String(maxLength: 500, unicode: false),
                        HasEmail = c.Boolean(nullable: false),
                        AccountID = c.String(),
                    })
                .PrimaryKey(t => t.MemberID);
            
            CreateTable(
                "GR.MemberGift",
                c => new
                    {
                        MemberGiftID = c.Int(nullable: false, identity: true),
                        GiftID = c.Int(nullable: false),
                        MemberID = c.Int(nullable: false),
                        Recipient = c.Boolean(nullable: false),
                        Suggestor = c.Boolean(nullable: false),
                        Contributor = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MemberGiftID)
                .ForeignKey("GR.Gift", t => t.GiftID)
                .ForeignKey("GR.Member", t => t.MemberID)
                .Index(t => t.GiftID)
                .Index(t => t.MemberID);
            
            CreateTable(
                "GR.Gift",
                c => new
                    {
                        GiftID = c.Int(nullable: false, identity: true),
                        GiftRegistryID = c.Int(nullable: false),
                        GiftName = c.String(maxLength: 500, unicode: false),
                        GiftDescription = c.String(maxLength: 4000, unicode: false),
                        Email = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.GiftID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("GR.GiftRegistryMember", "GiftRegistryID", "GR.GiftRegistry");
            DropForeignKey("GR.MemberGift", "MemberID", "GR.Member");
            DropForeignKey("GR.MemberGift", "GiftID", "GR.Gift");
            DropForeignKey("GR.GiftRegistryMember", "MemberID", "GR.Member");
            DropForeignKey("GR.GiftRegistryInvite", "GiftRegistryID", "GR.GiftRegistry");
            DropIndex("GR.MemberGift", new[] { "MemberID" });
            DropIndex("GR.MemberGift", new[] { "GiftID" });
            DropIndex("GR.GiftRegistryMember", new[] { "MemberID" });
            DropIndex("GR.GiftRegistryMember", new[] { "GiftRegistryID" });
            DropIndex("GR.GiftRegistryInvite", new[] { "GiftRegistryID" });
            DropTable("GR.Gift");
            DropTable("GR.MemberGift");
            DropTable("GR.Member");
            DropTable("GR.GiftRegistryMember");
            DropTable("GR.GiftRegistryInvite");
            DropTable("GR.GiftRegistry");
        }
    }
}
