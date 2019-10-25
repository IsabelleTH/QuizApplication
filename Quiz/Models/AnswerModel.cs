using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Quiz.Controllers;

namespace Quiz.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public int ChildQuestionId { get; set; }
        public string Answer { get; set; }

       
    

    //public void Switch(string answer)
    //{
    //    Controllers.Quiz.QuizController quizController;
    //    quizController = new Controllers.Quiz.QuizController();
        
    //        switch (answer)
    //        {
    //            case "C++":
    //            quizController.WrongAnswer();
    //                break;

    //            case "Python":
    //            quizController.WrongAnswer();
    //                break;

    //            default:
    //            quizController.RightAnswer();
    //                break;
    //        }
        
    //}

    

   }
}