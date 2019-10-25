namespace Quiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateWebsite : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.AnswerModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AnswerModels",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        Answer1 = c.String(nullable: false),
                        Answer2 = c.String(nullable: false),
                        Answer3 = c.String(nullable: false),
                        RightAnswer = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerId);
            
        }
    }
}
