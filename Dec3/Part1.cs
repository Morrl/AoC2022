using System.IO.Pipes;

namespace Dec3;

public class Part1
{
    public static void Calculate()
    {
        Console.WriteLine("Part1");

        List<string> lines = new List<string>();
        lines = File.ReadLines("Input.txt").ToList();

        Dictionary<string, int> priorities = new Dictionary<string, int>();

        int i = 1;
        for (char c='a'; c<='z';c++)
        {
            priorities.Add(c.ToString(),i);

            int unicode = (int)c;
            int upperUnicode = c - 32;
            char upperChar = (char)upperUnicode;
            
            priorities.Add(upperChar.ToString(),i+26);
            i++;
        }
        
        //Split compartments
        var compartments = SplitLinesIntoCompartments(lines);

        int result = 0;
        foreach (var compartment in compartments)
        {
            result += GetPriority(compartment, priorities);
        }

        Console.WriteLine("Result:");
        Console.WriteLine(result);


    }

    private static List<Tuple<string,string>> SplitLinesIntoCompartments(List<string> lines)
    {
        List<Tuple<string, string>> compartments = new List<Tuple<string, string>>();
        foreach (var line in lines)
        {
            var first = line.Substring(0, line.Length / 2);
            var last = line.Substring(line.Length / 2, line.Length / 2);
            compartments.Add(new Tuple<string, string>(first,last));
        }
        
        return compartments;
    }

    private static int GetPriority(Tuple<string, string> compartment, Dictionary<string, int> priorities)
    {
        var first = compartment.Item1;
        var last = compartment.Item2;

        var firstList = first.ToArray().ToList();
        var lastList = last.ToArray().ToList();

        var duplicates = firstList.Intersect(lastList).ToList();

        int result = 0;
        foreach (var duplicate in duplicates)
        {
            result += priorities[duplicate.ToString()];
        }
        
        
        return result;
    }
}