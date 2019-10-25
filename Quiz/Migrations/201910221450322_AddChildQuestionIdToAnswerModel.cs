namespace Quiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChildQuestionIdToAnswerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnswerModels", "ChildQuestionId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AnswerModels", "ChildQuestionId");
        }
    }
}
