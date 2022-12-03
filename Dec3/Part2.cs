namespace Dec3;

public class Part2
{
    public static void Calculate()
    {
        Console.WriteLine("Part2");

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

        int result = 0;
        for (int j = 0; j < lines.Count; j += 3)
        {
            var badge = GetBadge(lines[j], lines[j + 1], lines[j + 2]);
            var prority = GetPriority(badge,priorities);
            result += prority;
        }
        
        
        
        
        Console.WriteLine("Result:");
        Console.WriteLine(result);


    }



    private static int GetPriority(string badge, Dictionary<string,int> priorities)
    {
        int result;

        result = priorities[badge];
        
        
        return result;
    }

    private static string GetBadge(string bag1, string bag2, string bag3)
    {
        string result;

        var bag1List = bag1.ToArray().ToString();
        var bag2List = bag2.ToArray().ToString();
        var bag3List = bag3.ToArray().ToString();

        var common = bag1.Intersect(bag2).ToList();
        common = common.Intersect(bag3).ToList();

        result = common[0].ToString();

        return result;
    }
}
