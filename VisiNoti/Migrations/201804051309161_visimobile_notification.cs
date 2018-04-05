namespace VisiNoti.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class visimobile_notification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "FCMToken", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "FCMToken");
        }
    }
}
