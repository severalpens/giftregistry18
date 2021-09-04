namespace GR2018.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deprecateInvites : DbMigration
    {
        public override void Up()
        {
            AddColumn("GR.Member", "HasEmail", c => c.Boolean(nullable: false));
            AddColumn("GR.Member", "AccountID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("GR.Member", "AccountID");
            DropColumn("GR.Member", "HasEmail");
        }
    }
}
