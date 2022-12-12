using System.Text;

namespace Dec10;

public class Part2
{
    public static void Calculate()
    {
        Console.WriteLine("Part2");

        var commands = File.ReadLines("Input.txt").ToList();

        var registryValueAtClockCycle = new List<int>();
        //Add dummy value to shift all cycles 1 step
        registryValueAtClockCycle.Add(1);
        int currentValue = 1;

        foreach (var command in commands)
        {
            if (command == "noop")
            {
                registryValueAtClockCycle.Add(currentValue);
                continue;
            }

            var substrings = command.Split(" ");
            int increment = Int32.Parse(substrings[1]);
            registryValueAtClockCycle.Add(currentValue);
            currentValue += increment;
            registryValueAtClockCycle.Add(currentValue);

        }
        

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < registryValueAtClockCycle.Count; i++)
        {
            int hozPos = i % 40;

            int registryVal = registryValueAtClockCycle[i];
            string pixel = ".";
            if (Math.Abs(registryVal - hozPos) <= 1)
            {
                pixel = "#";
            }

            sb.Append(pixel);

            if (hozPos == 39)
            {
                sb.Append("\n");
            }
        }

        string result = sb.ToString();
        
        Console.WriteLine("Result");
        Console.WriteLine(result);

    }
}