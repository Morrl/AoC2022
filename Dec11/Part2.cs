namespace Dec11;

public class Part2
{
    public static void Calculate()
    {
        Console.WriteLine("Part2");

        var monkeys = new List<Monkey>();
        var lines = File.ReadLines("Input.txt").ToList();

        for (int i = 0; i <= lines.Count / 7; i++)
        {
            var range = lines.GetRange((i * 6 + i), 6);

            monkeys.Add(new Monkey(range.ToList()));

        }
        long cutOff = 1;
        List<int> inspects = new List<int>();
        foreach (var monkey in monkeys)
        {
            cutOff *= monkey.Test;
            inspects.Add(0);
        }

        for (int j = 0; j < 10000; j++)
        {
            for (var index = 0; index < monkeys.Count; index++)
            {
                var monkey = monkeys[index];

                int nMonkeyItems = monkey.Items.Count;
                for (int i = 0; i < nMonkeyItems; i++)
                {
                    inspects[index]++;
                    long worry = monkey.Items.Dequeue();

                    if (monkey.UseOldValue)
                    {
                        monkey.OperationValue = (int)worry;
                    }

                    if (monkey.OperationType == Operation.Add)
                    {
                        worry = worry + monkey.OperationValue;
                    }
                    else
                    {
                        worry = worry * monkey.OperationValue;
                    }

                    worry %= cutOff;
                    //Test

                    int targetMonkey = monkey.FalseMonkey;
                    if (worry % monkey.Test == 0)
                    {
                        targetMonkey = monkey.TrueMonkey;
                    }

                    monkeys[targetMonkey].Items.Enqueue((int)worry);
                }
            }
        }

        inspects = inspects.OrderByDescending(x => x).ToList();
        var top2 = inspects.Take(2).ToList();
        Console.WriteLine("Result");
        long result = (long)top2[0] * (long)top2[1];
        Console.WriteLine(result);
    }
}