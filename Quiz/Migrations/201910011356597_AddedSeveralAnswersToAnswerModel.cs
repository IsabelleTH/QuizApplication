namespace Quiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSeveralAnswersToAnswerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnswerModels", "Answer1", c => c.String());
            AddColumn("dbo.AnswerModels", "Answer2", c => c.String());
            AddColumn("dbo.AnswerModels", "RightAnswer", c => c.String());
            DropColumn("dbo.AnswerModels", "Answer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AnswerModels", "Answer", c => c.String());
            DropColumn("dbo.AnswerModels", "RightAnswer");
            DropColumn("dbo.AnswerModels", "Answer2");
            DropColumn("dbo.AnswerModels", "Answer1");
        }
    }
}
