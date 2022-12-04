using Microsoft.VisualBasic;

namespace Dec4;

public class Part1
{

    public static void Calculate()
    {
        Console.WriteLine("Part1");
        var lines = File.ReadLines("Input.txt").ToList();
        int containedPairs = 0;

        foreach (var line in lines)
        {
            var assignments = line.Split(",");
            var interval1 = GetInterval(assignments[0]);
            var interval2 = GetInterval(assignments[1]);

            if ((interval1.start <= interval2.start && interval2.end <= interval1.end) ||
                (interval2.start <= interval1.start && interval1.end <= interval2.end))
            {
                containedPairs++;
            }
            
        }
        
        
        Console.WriteLine("Result");
        Console.WriteLine(containedPairs);
    }

    public static (int start, int end) GetInterval(string intervalString)
    {
        
        var subStrings = intervalString.Split("-");
        var start = Int32.Parse(subStrings[0]);
        var end = Int32.Parse(subStrings[1]);

        return (start, end);

    }

}