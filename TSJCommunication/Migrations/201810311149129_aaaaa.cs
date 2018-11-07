namespace TSJCommunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaaaa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Votes", "OptionId", c => c.Int(nullable: false));
            DropColumn("dbo.Votes", "OptionIndex");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Votes", "OptionIndex", c => c.Int(nullable: false));
            DropColumn("dbo.Votes", "OptionId");
        }
    }
}
