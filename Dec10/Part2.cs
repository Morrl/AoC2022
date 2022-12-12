using System.Text;

namespace Dec10;

public class Part2
{
    public static void Calculate()
    {
        Console.WriteLine("Part2");

        var commands = File.ReadLines("Input.txt").ToList();

        var registryValueAtClockCycle = new List<int>();
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

        // int cycle_20Val = registryValueAtClockCycle[20];
        // int cycle_60Val = registryValueAtClockCycle[60];
        // int cycle_100Val = registryValueAtClockCycle[100];
        // int cycle_140Val = registryValueAtClockCycle[140];
        // int cycle_180Val = registryValueAtClockCycle[180];
        // int cycle_220Val = registryValueAtClockCycle[220];
        //
        // int signal20 = 20 * cycle_20Val;
        // int signal60 = 60 * cycle_60Val;
        // int signal100 = 100 * cycle_100Val;
        // int signal140 = 140 * cycle_140Val;
        // int signal180 = 180 * cycle_180Val;
        // int signal200 = 220 * cycle_220Val;
        //
        //
        // int result = signal20 + signal60 + signal100 + signal140 +signal180+ signal200;

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