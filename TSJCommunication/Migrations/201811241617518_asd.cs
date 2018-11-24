namespace TSJCommunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Votes", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Votes", "UserId", c => c.Int(nullable: false));
        }
    }
}
