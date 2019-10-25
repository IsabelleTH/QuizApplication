namespace Quiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFirstAndLastNameToUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Users", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "FirstName");
        }
    }
}
