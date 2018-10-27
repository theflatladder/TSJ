namespace TSJCommunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tes : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Votes", "sth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Votes", "sth", c => c.String());
        }
    }
}
