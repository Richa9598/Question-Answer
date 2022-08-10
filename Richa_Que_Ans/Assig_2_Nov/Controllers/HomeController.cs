using Richa_Que_Ans.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Richa_Que_Ans.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private ContextDBcs context { get; set; }

        public HomeController(ILogger<HomeController> logger, ContextDBcs ctx)
        {
            _logger = logger;
            context = ctx;
        }

        public IActionResult Index()
        {
            var questions = context.Questions
                .Take(10)
                .ToList();
            return View(questions);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }


        public IActionResult Categories()
        {
            var categories = context.Categories
                .Take(10)
                .ToList();
            return View(categories);
        }


        public IActionResult Questions(string type = "All")
        {
            var categories = context.Categories.ToList();
            List<Question> questions;

            if (type == "All")
            {
                questions = context.Questions.ToList();
            }
            else
            {
                questions = context.Questions
                    .Where(q => q.Category.Name == type).ToList();
            }
            ViewBag.Categories = categories;
            ViewBag.SelectedCategoryName = type;
            return View(questions);
        }

        [HttpPost]
        public IActionResult AddQuestion(Question q)
        {
            if (q.QuestionID == 0)
                context.Questions.Add(q);
            else
                context.Questions.Update(q);

            context.SaveChanges();
            return RedirectToAction("Questions", "Home");
        }

        [Route("[controller]/{qid}/{ques}")]
        public IActionResult Answers(int qid, string ques)
        {
            Answers answerObj = new Answers();
            answerObj.QuestionID = qid;
            var answers = context.Answers.Where(a => a.QuestionID == qid).ToList();
            ViewBag.questionId = qid;
            ViewBag.question = ques;
            ViewBag.answers = answers;
            return View(answerObj);
        }

        [HttpPost]
        public IActionResult AddAnswer(Answers answer)
        {
            context.Answers.Add(answer);
            context.SaveChanges();
            return RedirectToAction("Questions", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
