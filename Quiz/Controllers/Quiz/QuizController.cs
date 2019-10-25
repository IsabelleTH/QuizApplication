using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiz.Models;
using System.Threading.Tasks;
using System.Data.Entity;
using PagedList;
using Microsoft.Ajax.Utilities;

namespace Quiz.Controllers.Quiz
{
    public class QuizController : Controller
    {
        public static int correct = 0;
        private ApplicationDbContext _context;

        public QuizController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Quiz
        public ActionResult Index()
        {
            //return RedirectToAction("DisplayQuiz");
            Console.WriteLine("Hello");
            return View();
        }

        public ActionResult CreateCategory()
        {
            return View();
        }

        // ------------

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory(CategoryModel model)
        {
            if (ModelState != null)
            {
                if (model.Id == 1)
                {
                    _context.CategoryModels.Add(model);
                    _context.SaveChanges();

                }

                return RedirectToAction("CreateQuestions");
            }

            else
            {
                ModelState.AddModelError("", "Add a category to create quiz.");
            }
            return View(model);
        }


        public ActionResult CreateQuestions()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateQuestions(QuestionModel questionModel)
        {
            if (ModelState != null)
            {
                _context.QuestionModels.Add(questionModel);
                _context.SaveChanges();

                return RedirectToAction("CreateAnswer");
            }

            else
            {
                ModelState.AddModelError("", "You must add one or several questions to continue.");
            }

            return View(questionModel);
        }
        //-------------

        public ActionResult CreateAnswer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAnswer(AnswerModel answerModel)
        {
            if (ModelState != null)
            {
                _context.AnswerModels.Add(answerModel);
                _context.SaveChanges();
                return RedirectToAction("");
            }

            else
            {
                ModelState.AddModelError("", "Please enter answers");
            }
            return View(answerModel);

        }


   
        public ActionResult ChooseCategory()
        {
            return View(_context.CategoryModels.ToList());
        }


   ////////////  PROGRAMMING QUESTIONS /////////////////

        public ActionResult QuestionOne(int? page)
        {
             var pageNumber = page ?? 1;
            //var onePageOfQuestion = quiz.ToPagedList(pageNumber, 1);
            //ViewBag.OneQuestionPerPage = onePageOfQuestion;

            var question = _context.QuestionModels.Where(model => model.Id == 1).FirstOrDefault();

            return View(question);
        }

        [HttpPost]
        public ActionResult QuestionOne( QuestionModel questionModel)
        {
            if (questionModel.AnswerModel.Answer == "C++")
            {
                return View("WrongAnswerQuestionOne");
            }
            else if (questionModel.AnswerModel.Answer == "Python")
            {
                return View("WrongAnswerQuestionOne");
            }
            else if (questionModel.AnswerModel.Answer == "C#")
            {
                correct++;
                return RedirectToAction("QuestionTwo", "Quiz");

            }

                return View("Index");
        }

        public ActionResult QuestionTwo()
        {
            var question = _context.QuestionModels.Where(model => model.Id == 3).FirstOrDefault();
            return View(question);
        }

        [HttpPost]
        public ActionResult QuestionTwo(QuestionModel questionModel)
        {
            
            if (questionModel.AnswerModel.Answer == "Java")
            {
                correct--;
                return View("WrongAnswerQuestionTwo");
            }
            else if (questionModel.AnswerModel.Answer == "JavaScript")
            {
                correct--;
                return View("WrongAnswerQuestionTwo");
            } 
            else if (questionModel.AnswerModel.Answer == "Rudy")
            {
                correct++;
                return RedirectToAction("QuestionThree", "Quiz");
            }

            return View("Index");
        }

        public ActionResult QuestionThree ()
        {
            var question = _context.QuestionModels.Where(model => model.Id == 3).FirstOrDefault();
            return View(question);
        }

        [HttpPost]
        public ActionResult QuestionThree (QuestionModel questionModel)
        {
            if(questionModel.AnswerModel.Answer == "1995")
            {
                correct--;
                return View("WrongAnswerQuestionThree");
            } 
            else if (questionModel.AnswerModel.Answer == "2005")
            {
                correct--;
                return View("WrongAnswerQuestionThree");
            }
            else if (questionModel.AnswerModel.Answer == "2000")
            {
                correct++;
                return RedirectToAction("FinishedTest", "Quiz");
            }

            return View("Index");
        }

        public ActionResult FinishedTest()
        {
            ViewBag.Score = correct;
            return View();
        }

        public ActionResult WrongAnswerQuestionOne()
        {
            return View();
        }

         public ActionResult WrongAnswerQuestionTwo()
        {
            return View();
        }

        public ActionResult WrongAnswerQuestionThree ()
        {
            return View();
        }


    ////////  COMPUTER QUESTIONS ///////

    public ActionResult ComputerQuestions()
        {
            var quiz = _context.QuestionModels.Where(model => model.Category.Id == 2).Include(m => m.Question).ToList();
            return View(quiz);
        }

        [HttpPost]
        public ActionResult ComputerQuestions(string hej, string hejj, string hejjj)
        {
            return View();
        }

    
    }
}
