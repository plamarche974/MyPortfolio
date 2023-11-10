namespace Quizz.Models
{

    public class GameParameter
    {
        public bool isPlaying;
        public bool isGettingRightAnswer;
    }

    public static class GameData
    {
        static List<Question> _questions = new List<Question>();
        public static List<Question> GetQuestions() { return _questions; }

        static int points = 0;

        public static int GetPoints { get { return points; } }
        public static void Addpoint()
        {
            points++;
        }

        public static void ResetPoint()
        {
            points = 0;
        }

        public static void SetQuestions(List<Question> questions) { _questions = questions; }

        static string _playerName = "";

        public static string PlayerName { get { return _playerName; } }

        public static void SetPlayerName(string playerName)
        {
            _playerName = playerName;
        }
    }
}
