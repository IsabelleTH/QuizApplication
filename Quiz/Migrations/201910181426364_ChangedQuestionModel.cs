namespace Quiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedQuestionModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AnswerModels", "Question_Id", "dbo.QuestionModels");
            DropIndex("dbo.AnswerModels", new[] { "Question_Id" });
            AddColumn("dbo.QuestionModels", "AnswerModel_Id", c => c.Int());
            CreateIndex("dbo.QuestionModels", "AnswerModel_Id");
            AddForeignKey("dbo.QuestionModels", "AnswerModel_Id", "dbo.AnswerModels", "Id");
            DropColumn("dbo.AnswerModels", "Question_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AnswerModels", "Question_Id", c => c.Int());
            DropForeignKey("dbo.QuestionModels", "AnswerModel_Id", "dbo.AnswerModels");
            DropIndex("dbo.QuestionModels", new[] { "AnswerModel_Id" });
            DropColumn("dbo.QuestionModels", "AnswerModel_Id");
            CreateIndex("dbo.AnswerModels", "Question_Id");
            AddForeignKey("dbo.AnswerModels", "Question_Id", "dbo.QuestionModels", "Id");
        }
    }
}
