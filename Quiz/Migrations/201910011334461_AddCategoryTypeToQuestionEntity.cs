namespace Quiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryTypeToQuestionEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.QuestionModels", "Category_Id", c => c.Int());
            CreateIndex("dbo.QuestionModels", "Category_Id");
            AddForeignKey("dbo.QuestionModels", "Category_Id", "dbo.CategoryModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionModels", "Category_Id", "dbo.CategoryModels");
            DropIndex("dbo.QuestionModels", new[] { "Category_Id" });
            DropColumn("dbo.QuestionModels", "Category_Id");
            DropTable("dbo.AnswerModels");
        }
    }
}
