namespace TSJCommunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sugg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserSuggestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Options = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserSuggestions");
        }
    }
}
