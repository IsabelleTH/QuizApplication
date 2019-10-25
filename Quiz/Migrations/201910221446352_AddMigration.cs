namespace Quiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnswerModels", "QuestionModel_Id", c => c.Int());
            AddColumn("dbo.QuestionModels", "ParentQuestionId", c => c.Int(nullable: false));
            AddColumn("dbo.QuestionModels", "SelectedAnswer", c => c.Int(nullable: false));
            CreateIndex("dbo.AnswerModels", "QuestionModel_Id");
            AddForeignKey("dbo.AnswerModels", "QuestionModel_Id", "dbo.QuestionModels", "Id");
            DropColumn("dbo.QuestionModels", "Points");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuestionModels", "Points", c => c.Int(nullable: false));
            DropForeignKey("dbo.AnswerModels", "QuestionModel_Id", "dbo.QuestionModels");
            DropIndex("dbo.AnswerModels", new[] { "QuestionModel_Id" });
            DropColumn("dbo.QuestionModels", "SelectedAnswer");
            DropColumn("dbo.QuestionModels", "ParentQuestionId");
            DropColumn("dbo.AnswerModels", "QuestionModel_Id");
        }
    }
}
