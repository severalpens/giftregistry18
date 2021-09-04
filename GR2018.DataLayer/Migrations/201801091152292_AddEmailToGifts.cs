namespace GR2018.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailToGifts : DbMigration
    {
        public override void Up()
        {
            AddColumn("GR.Gift", "Email", c => c.String(maxLength: 500, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("GR.Gift", "Email");
        }
    }
}
