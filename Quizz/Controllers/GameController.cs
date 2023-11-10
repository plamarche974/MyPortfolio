using Microsoft.AspNetCore.Mvc;
using Quizz.Models;
using System.Data.Entity;

namespace Quizz.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QuizContext _context;

        public GameController(ILogger<HomeController> logger, QuizContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(int Id)
        {
            this.ViewBag.question = GameData.GetQuestions()[Id];
            int rightAnswer = (char.Parse(GameData.GetQuestions()[Id].CorrectAnswer) - 'A');
            string[] questionRange = { "false", "false", "false", "false" };
            questionRange[rightAnswer] = "true";
            this.ViewBag.questionRange = questionRange;
            this.ViewBag.rightAnswer = rightAnswer;

            return View(true);
        }

        [HttpPost]
        public IActionResult Index(int Id, string answer)
        {
            if (answer == "true")
            {
                GameData.Addpoint();
            }

            this.ViewBag.question = GameData.GetQuestions()[Id];
            int rightAnswer = (char.Parse(GameData.GetQuestions()[Id].CorrectAnswer) - 'A');
            this.ViewBag.id = Id + 1;
            this.ViewBag.rightAnswer = rightAnswer;

            return View(false);
        }

        public IActionResult Result()
        {
            List<Score> scores = GetScores(10);

            this.ViewBag.numberOfValue = scores.Count();

            return View(scores);
        }

        private List<Score> GetScores(int numberScores)
        {
            // Récupérer tous les scores de la base de données, triés par PlayerScore décroissant
            var scores = _context.Scores.OrderByDescending(s => s.PlayerScore).ToList();

            // Créer un nouveau score avec les informations du joueur et le score obtenu
            // Score myScore = new Score { PlayerName = TempData["PlayerName"] as string, PlayerScore = GameData.GetPoints };

            Score myScore = new Score { PlayerName = TempData["PlayerName"] as string, PlayerScore = GameData.GetPoints };
            // Ajouter le nouveau score à la liste
            scores.Add(myScore);

            // Trier à nouveau la liste avec le nouveau score inclus et prendre les 'numberScores' meilleurs scores
            scores = scores.OrderByDescending(s => s.PlayerScore).Take(numberScores).ToList();

            // Ajouter le nouveau score à la base de données
            _context.Scores.Add(myScore);

            // Vérifier si le nombre total de scores dans la base de données dépasse 'numberScores'
            if (_context.Scores.Count() > numberScores)
            {
                // Récupérer les scores qui ne font pas partie des 'numberScores' meilleurs pour les supprimer
                var scoresToRemove = _context.Scores.OrderByDescending(s => s.PlayerScore)
                                           .Skip(numberScores)
                                           .ToList();

                // Supprimer les scores supplémentaires de la base de données
                _context.Scores.RemoveRange(scoresToRemove);
            }

            // Sauvegarder les changements dans la base de données
            _context.SaveChanges();

            // Retourner la liste des 'numberScores' meilleurs scores
            return scores;
        }
    }
}


