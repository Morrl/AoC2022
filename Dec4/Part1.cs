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

    // public static void Calculate()
    // {
    //     Console.WriteLine("Part1");
    //     var lines = File.ReadLines("Input.txt").ToList();
    //     int containedPairs = 0;
    //
    //     foreach (var line in lines)
    //     {
    //         var subStrings = line.Split(",");
    //         var first = GetRangeFromString(subStrings[0]);
    //         var last = GetRangeFromString(subStrings[1]);
    //
    //         if (first.All(x => last.Contains(x)) || last.All(x => first.Contains(x)))
    //         {
    //             containedPairs++;
    //         }
    //         
    //     }
    //     
    //     Console.WriteLine("Result");
    //     Console.WriteLine(containedPairs);
    //     
    //
    // }
    //
    // public static List<int> GetRangeFromString(string input)
    // {
    //     string[] boundries = input.Split("-");
    //     int first = Int32.Parse(boundries[0]);
    //     int last = Int32.Parse(boundries[1]);
    //     List<int> result = new List<int>();
    //
    //     for (int i = first; i <= last; i++)
    //     {
    //         result.Add(i);
    //     }
    //
    //     return result;
    //
    // }
    
    // public static void Calculate()
    // {
    //     Console.WriteLine("Part1");
    //
    //     var lines = File.ReadLines("Input.txt").ToList();
    //
    //     int containedPairs = 0;
    //
    //     foreach (var line in lines)
    //     {
    //         var subStrings = line.Split(",");
    //         var firstRange = GetBinaryRepresentationFromRange(subStrings[0]);
    //         var secondRange = GetBinaryRepresentationFromRange(subStrings[1]);
    //
    //         var bitmask = firstRange & secondRange;
    //
    //         if (bitmask == firstRange || bitmask == secondRange)
    //         {
    //             containedPairs++;
    //         }
    //         
    //
    //     }
    //     Console.WriteLine("Result:");
    //     Console.WriteLine(containedPairs);
    //
    // }
    //
    // private static System.Numerics.BigInteger GetBinaryRepresentationFromRange(string range)
    // {
    //     System.Numerics.BigInteger result = 0;
    //
    //     string[] boundries = range.Split("-");
    //     int first = Int32.Parse(boundries[0]);
    //     int last = Int32.Parse(boundries[1]);
    //
    //     for (int i = first; i <= last; i++)
    //     {
    //         result += (System.Numerics.BigInteger)Math.Pow(2, i);
    //     }
    //
    //     if (first == last)
    //     {
    //         result -= (System.Numerics.BigInteger)Math.Pow(2, last);
    //     }
    //     
    //     
    //     
    //     return result;
    // }
    
}