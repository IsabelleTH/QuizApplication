using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiz.Models
{
    public class QuestionModel
    {
        public int ParentQuestionId { get; set; }
        public int Id { get; set; }
        public string Question { get; set; }
        public int QuestionNumber { get; set; }
        public List<AnswerModel> GetAnswerModels { get; set; }

        public CategoryModel Category { get; set; }
        public AnswerModel AnswerModel { get; set; }

       
        public int SelectedAnswer { get; set; }
        
    }
}