using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dec2
{
    public class Part2
    {
        public static void Calculate()
        {
            List<string> lines;
            lines = File.ReadLines("Input.txt").ToList();

            List<RockPaperScissor2> tournament = new List<RockPaperScissor2>();
            
            foreach (var line in lines)
            {
                RockPaperScissor2 rockPaperScissor = new RockPaperScissor2();
                tournament.Add(rockPaperScissor);
                
                var choices = line.Split(" ".ToCharArray());
                if (choices[0] == "A")
                {
                    rockPaperScissor.OpponentChoice = RPS.Rock;
                }
                if (choices[0] == "B")
                {
                    rockPaperScissor.OpponentChoice = RPS.Paper;
                }
                if (choices[0] == "C")
                {
                    rockPaperScissor.OpponentChoice = RPS.Scissor;
                }

                if (choices[1] == "X")
                {
                    rockPaperScissor.MyOutCome = OutCome.Loose;
                }
                if (choices[1] == "Y")
                {
                    rockPaperScissor.MyOutCome = OutCome.Draw;
                }
                if (choices[1] == "Z")
                {
                    rockPaperScissor.MyOutCome = OutCome.Win;
                }

                
            }

            var score = tournament.Sum(x => x.Score);
            Console.WriteLine(score);
        }

    }
}