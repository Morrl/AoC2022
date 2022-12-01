using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dec1
{
    public class Part2
    {
        public static void Calculate()
        {
            List<string> lines = new List<string>();
            lines = File.ReadLines("Input.txt").ToList();

            List<Elf> elves = new List<Elf>();
            Elf currentElf = new Elf();
            foreach (var line in lines)
            {
                if (String.IsNullOrEmpty(line))
                {
                    elves.Add(currentElf);
                    currentElf = new Elf();
                    continue;
                }
            
                currentElf.Calories += Int32.Parse(line);
            
            }
            elves.Add(currentElf);

            List<Elf> top3 = new List<Elf>();
            top3.Add(elves[0]);
            top3.Add(elves[0]);
            top3.Add(elves[0]);

            foreach (var elf in elves)
            {
                if (top3.Any(x => x.Calories < elf.Calories))
                {
                    top3[0] = elf;
                    top3.Sort();
                }
            }


            int sumOfCalories = top3.Sum(x => x.Calories);
            Console.WriteLine(sumOfCalories);


        }
    }
}