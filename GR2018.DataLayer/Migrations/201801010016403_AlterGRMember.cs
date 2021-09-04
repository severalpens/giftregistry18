namespace GR2018.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterGRMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("GR.GiftRegistryMember", "IsAdmin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("GR.GiftRegistryMember", "IsAdmin");
        }
    }
}
