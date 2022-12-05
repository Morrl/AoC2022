using System.Text.RegularExpressions;

namespace Dec5;

public class Part2
{
    public static void Calculate()
    {
        Console.WriteLine("Part2");

        var lines = File.ReadAllLines("Input.txt").ToList();
        var crates = GetCrates(lines);
        
        //Get first line of movements
        int n = 0;
        while (!string.IsNullOrWhiteSpace(lines[n]))
        {
            n++;
        }
        n++;

        for (int i = n; i < lines.Count; i++)
        {
            ExecuteMovement(lines[i],crates);
        }

        var result = GetResult(crates);
        
        Console.WriteLine("Result:");
        Console.WriteLine(result);
    }

    public static void ExecuteMovement(string movement, Dictionary<int, List<string>> crates)
    {
        string s = movement;
        var charArray = s.ToArray();

        string regexPattern = @"\D+(\d+)\D+(\d+)\D+(\d+)";
        var reg = new Regex(regexPattern);
        var m = reg.Matches(movement);


        int amount = Int32.Parse(m[0].Groups[1].ToString());
        int from = Int32.Parse(m[0].Groups[2].ToString());
        int to = Int32.Parse(m[0].Groups[3].ToString());
        
        var cratesToMove = crates[from].TakeLast(amount).ToList();
        for (int i = 0; i < amount; i++)
        {
            crates[from].RemoveAt(crates[from].Count-1);
        }
        crates[to].AddRange(cratesToMove);

    }

    public static string GetResult(Dictionary<int, List<string>> crates)
    {
        string result = "";

        for (int i = 1; i <= crates.Count; i++)
        {
            result += crates[i].Last();
        }
        
        return result;
    }
    
    
    public static Dictionary<int, List<string>> GetCrates(List<string> lines)
    {
        var crates = new Dictionary<int, List<string>>();
         
        //Get last number
        int n = 0;
        while (!string.IsNullOrWhiteSpace(lines[n]))
        {
            n++;
        }

        n--;
        var tmp = lines[n].Replace(" ", "");
        var numbers = tmp.ToArray();
        foreach (var number in numbers)
        {
            var nbr = number.ToString();
            int i = Int32.Parse(nbr);
            crates.Add(i,new List<string>());
        }

        foreach (var crate in crates)
        {
            var crateNo = crate.Key.ToString();
            var posInString = lines[n].IndexOf(crateNo, StringComparison.Ordinal);

            for (int i = 0; i < n; i++)
            {
                var s = lines[i].ElementAt(posInString).ToString();
                if (!string.IsNullOrWhiteSpace(s))
                {
                    crate.Value.Add(s);
                }
                    
            }

            crate.Value.Reverse();


        }
        
        
        

        return crates;
    }
}