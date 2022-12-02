using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dec2
{
    public class Part1
    {
        public static void Calculate()
        {
            List<string> lines;
            lines = File.ReadLines("Input.txt").ToList();

            List<RockPaperScissor> tournament = new List<RockPaperScissor>();
            
            foreach (var line in lines)
            {
                RockPaperScissor rockPaperScissor = new RockPaperScissor();
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
                    rockPaperScissor.MyChoice = RPS.Rock;
                }
                if (choices[1] == "Y")
                {
                    rockPaperScissor.MyChoice = RPS.Paper;
                }
                if (choices[1] == "Z")
                {
                    rockPaperScissor.MyChoice = RPS.Scissor;
                }

                
            }

            var score = tournament.Sum(x => x.Score);
            Console.WriteLine(score);
        }
    }
}