using Microsoft.AspNetCore.Mvc;
using Quizz.Models;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Quizz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QuizContext _context;

        public HomeController(ILogger<HomeController> logger, QuizContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            GameData.SetQuestions(GetRandomQuestions(10));
            return View();
        }

        [HttpPost]
        public IActionResult Index(string PlayerName)
        {
            // Utilisez ILogger pour enregistrer un message pour le débogage
            _logger.LogInformation("PlayerName received: {PlayerName}", PlayerName);

            TempData["PlayerName"] = PlayerName;
            GameData.ResetPoint();
            if (!string.IsNullOrEmpty(PlayerName))
            {
                // Supposons que vous avez une action nommée "Game" ou autre dans votre contrôleur.
                return RedirectToAction("index","Game", new { Id = 0 });
            }
            return RedirectToAction("Index");
        }


        private List<Question> GetRandomQuestions(int numberOfQuestions)
        {
            // Attention, cette opération peut être coûteuse en fonction de la taille de la table car elle charge toutes les lignes en mémoire
            var questions = _context.Questions.ToList();
            // Mélangez les questions et prenez-en 10
            var randomQuestions = questions.OrderBy(q => Guid.NewGuid()).Take(numberOfQuestions).ToList();

            return randomQuestions;
        }

        /*  public void SetupDataQuestions()
          {
              var csvFilePath = @"C:\data\Questions CSV.txt";
             var importer = new CSVDataImporter(csvFilePath, _context);

             importer.Import();
          }
          public IActionResult Privacy()
          {
              return View();
          }

          [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
          public IActionResult Error()
          {
              return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
          }




          public class CSVDataImporter
          {
              private readonly string _csvFilePath;
              private readonly QuizContext _context;

              public CSVDataImporter(string csvFilePath, QuizContext context)
              {
                  _csvFilePath = csvFilePath;
                  _context = context;
              }

              public void Import()
              {
                  var questions =System.IO.File.ReadAllLines(_csvFilePath)
                                      .Skip(1) // Skip header line if there is one
                                      .Select(line => CreateQuestionFromCsvLine(line))
                                      .ToList();

                  _context.Questions.AddRange(questions);
                  _context.SaveChanges();
              }

              private Question CreateQuestionFromCsvLine(string csvLine)
              {
                  var columns = csvLine.Split(';');

                  return new Question
                  {
                      QuestionContent = columns[0],
                      ChoiceA = columns[1],
                      ChoiceB = columns[2],
                      ChoiceC = columns[3],
                      ChoiceD = columns[4],
                      CorrectAnswer = columns[5]
                  };
              }
          }*/
    }
}