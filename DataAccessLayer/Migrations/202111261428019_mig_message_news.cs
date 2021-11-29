namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_message_news : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsRead", c => c.Boolean(nullable: false));
            DropColumn("dbo.Messages", "Draft");
            DropColumn("dbo.Messages", "Read");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Read", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "Draft", c => c.Boolean(nullable: false));
            DropColumn("dbo.Messages", "IsRead");
        }
    }
}
