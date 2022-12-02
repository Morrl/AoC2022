namespace Dec2
        {

            public enum OutCome
            {
                Loose,
                Draw,
                Win
            }
            public class RockPaperScissor2
            {
                public RPS OpponentChoice { get; set; }
                public OutCome MyOutCome { get; set; }
        
                public int Score
                {
                    get => CalculateScore();
                }
                
                public RockPaperScissor2()
                {
                    OpponentChoice = RPS.Rock;
                    MyOutCome = OutCome.Loose;

                }
        
                private int CalculateScore()
                {
                    int score=0;
                    switch (MyOutCome)
                    {
                        case OutCome.Loose:
                            score = 0;
                            break;
                        case OutCome.Draw:
                            score = 3;
                            break;
                        case OutCome.Win:
                            score = 6;
                            break;
                    }

                    if (MyOutCome == OutCome.Win)
                    {
                        if (OpponentChoice == RPS.Rock)
                        {
                            score += 2;
                            return score;
                        }

                        if (OpponentChoice == RPS.Paper)
                        {
                            score += 3;
                            return score;
                        }
                        if (OpponentChoice == RPS.Scissor)
                        {
                            score += 1;
                            return score;
                        }
                    }
                    
                    if (MyOutCome == OutCome.Draw)
                    {
                        if (OpponentChoice == RPS.Rock)
                        {
                            score += 1;
                            return score;
                        }

                        if (OpponentChoice == RPS.Paper)
                        {
                            score += 2;
                            return score;
                        }
                        if (OpponentChoice == RPS.Scissor)
                        {
                            score += 3;
                            return score;
                        }
                    }
                    if (MyOutCome == OutCome.Loose)
                    {
                        if (OpponentChoice == RPS.Rock)
                        {
                            score += 3;
                            return score;
                        }

                        if (OpponentChoice == RPS.Paper)
                        {
                            score += 1;
                            return score;
                        }
                        if (OpponentChoice == RPS.Scissor)
                        {
                            score += 2;
                            return score;
                        }
                    }
                    // if (MyChoice == OpponentChoice)
                    // {
                    //     score += 3;
                    //     return score;
                    // }
                    //
                    // if (MyChoice == RPS.Paper && OpponentChoice == RPS.Rock)
                    // {
                    //     score += 6;
                    //     return score;
                    // }
                    //
                    // if (MyChoice == RPS.Rock && OpponentChoice == RPS.Scissor)
                    // {
                    //     score += 6;
                    //     return score;
                    // }
                    //
                    // if (MyChoice == RPS.Scissor && OpponentChoice == RPS.Paper)
                    // {
                    //     score += 6;
                    //     return score; 
                    // }
        
                    return score;
        
        
                }
                
            }
        }
