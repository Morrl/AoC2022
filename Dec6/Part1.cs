namespace Dec6;

public class Part1
{
    public static void Calculate()
    {
        Console.WriteLine("Part1");

        string message = File.ReadAllText("Input.txt");
        int i = 0;
        bool foundStartPacket = false;
        while (i < message.Length && !foundStartPacket)
        {
            var tmp = message.Substring(i, 4);
            foundStartPacket = StartOfPacketIdentified(tmp);
            i++;
        }

        i--;
        Console.WriteLine("Result:");
        Console.WriteLine(i+4);

    }

    public static bool StartOfPacketIdentified(string s)
    {
        bool startOfPacketIdentified = true;
        var charArray = s.ToCharArray();
        for (int i = 0; i < charArray.Length; i++)
        {
            for (int j = i + 1; j < charArray.Length; j++)
            {
                startOfPacketIdentified &= charArray[i] != charArray[j];
            }
        }

        return startOfPacketIdentified;
    }
    
    
}