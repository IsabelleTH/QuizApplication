namespace Quiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuestionTypeToAnswerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnswerModels", "Question_Id", c => c.Int());
            CreateIndex("dbo.AnswerModels", "Question_Id");
            AddForeignKey("dbo.AnswerModels", "Question_Id", "dbo.QuestionModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnswerModels", "Question_Id", "dbo.QuestionModels");
            DropIndex("dbo.AnswerModels", new[] { "Question_Id" });
            DropColumn("dbo.AnswerModels", "Question_Id");
        }
    }
}
