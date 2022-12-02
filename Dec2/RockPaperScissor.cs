using System.Security.Cryptography;

namespace Dec2
{
    public enum RPS
    {
        Rock,
        Paper,
        Scissor
    }
    public class RockPaperScissor
    {
        public RPS OpponentChoice { get; set; }
        public RPS MyChoice { get; set; }

        public int Score
        {
            get => CalculateScore();
        }
        
        public RockPaperScissor()
        {
            OpponentChoice = RPS.Rock;
            MyChoice = RPS.Rock;
            
        }

        private int CalculateScore()
        {
            int score=0;
            switch (MyChoice)
            {
                case RPS.Rock:
                    score = 1;
                    break;
                case RPS.Paper:
                    score = 2;
                    break;
                case RPS.Scissor:
                    score = 3;
                    break;
            }

            if (MyChoice == OpponentChoice)
            {
                score += 3;
                return score;
            }

            if (MyChoice == RPS.Paper && OpponentChoice == RPS.Rock)
            {
                score += 6;
                return score;
            }

            if (MyChoice == RPS.Rock && OpponentChoice == RPS.Scissor)
            {
                score += 6;
                return score;
            }

            if (MyChoice == RPS.Scissor && OpponentChoice == RPS.Paper)
            {
                score += 6;
                return score; 
            }

            return score;


        }
        
    }
}