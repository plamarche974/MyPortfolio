using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quizz.Models
{

    [Table("Question")]
        public class Question
        {
        [Key]
        public int QuestionId { get; set; }
            public string QuestionContent { get; set; }
            public string ChoiceA { get; set; }
            public string ChoiceB { get; set; }
            public string ChoiceC { get; set; }
            public string ChoiceD { get; set; }
            public string CorrectAnswer { get; set; }
        }

    [Table("Score")]
        public class Score
        {
        [Key]
        public int ScoreId { get; set; }
            public string PlayerName { get; set; }
            public int PlayerScore { get; set; }
            // public DateTime Date { get; set; }
        }
    
}
