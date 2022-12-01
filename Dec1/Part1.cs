using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dec1.Properties
{
    public class Part1
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
            int biggestCal = elves.Max(x => x.Calories);
            Console.WriteLine(biggestCal);
        }

    }
}