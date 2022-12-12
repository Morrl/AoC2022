namespace Dec11;

public enum Operation
{
    Add,
    Multiply
}


public class Monkey
{
    public Queue<int> Items;
    public int Test { get; set; }
    public int TrueMonkey { get; set; }
    public int FalseMonkey { get; set; }
    public Operation OperationType { get; set; }
    public int OperationValue { get; set; }

    public bool UseOldValue { get; set; }
    
    
    public Monkey()
    {
        Items = new Queue<int>();
    }

    public Monkey(List<string> monkeyRows)
    {
        Items = new Queue<int>();
        
        
        string temp = monkeyRows[1];
        temp = temp.Replace("  Starting items: ", "");
        temp = temp.Replace(",", "");

        var items = temp.Split(" ");
        
        foreach (var item in items)
        {
            Items.Enqueue(Int32.Parse(item));
        }

        temp = monkeyRows[2];
        var temp2 = temp.Split(" ");

        OperationType = Operation.Multiply;
        if (temp2[6] == "+")
        {
            OperationType = Operation.Add;
        }

        if (temp2[7] != "old")
        {
            OperationValue = Int32.Parse(temp2[7]);
        }
        else
        {
            UseOldValue = true;
        }
        
        //Test divisible
        temp = monkeyRows[3];
        temp2 = temp.Split(" ");
        Test = Int32.Parse(temp2[5]);
        
        //if trye
        temp = monkeyRows[4];
        temp2 = temp.Split(" ");
        TrueMonkey = Int32.Parse(temp2[9]);
        
        //if false
        temp = monkeyRows[5];
        temp2 = temp.Split(" ");
        FalseMonkey = Int32.Parse(temp2[9]);
    }
}