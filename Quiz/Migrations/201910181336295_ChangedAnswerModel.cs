namespace Quiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAnswerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnswerModels", "Answer", c => c.String());
            DropColumn("dbo.AnswerModels", "Answer1");
            DropColumn("dbo.AnswerModels", "Answer2");
            DropColumn("dbo.AnswerModels", "RightAnswer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AnswerModels", "RightAnswer", c => c.String());
            AddColumn("dbo.AnswerModels", "Answer2", c => c.String());
            AddColumn("dbo.AnswerModels", "Answer1", c => c.String());
            DropColumn("dbo.AnswerModels", "Answer");
        }
    }
}
