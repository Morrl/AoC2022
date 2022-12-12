namespace Dec9;

public class Part1
{
    public static void Calculate()
    {
        Console.WriteLine("Part1");

        var lines = File.ReadAllLines("Input.txt").ToList();
        Directions lastDir;
        Position tPos = new Position();
        Position hPos = new Position();
        Position oldHPos = new Position();

        List<Position> visitedTailPositions = new List<Position>();
        visitedTailPositions.Add(tPos);

        foreach (var line in lines)
        {
            var movement = GetMovement(line);
            Directions d = movement.Item1;
            int length = movement.Item2;

            for (int i = 0; i < length; i++)
            {
                oldHPos = hPos.Clone() as Position;
                
                switch (d)
                {
                    case Directions.Up:
                        hPos.Y++;
                        break;
                    case Directions.Down:
                        hPos.Y--;
                        break;
                    case Directions.Left:
                        hPos.X--;
                        break;
                    case Directions.Right:
                        hPos.X++;
                        break;
                    
                }

                double dist = hPos.DistanceTo(tPos);
                if (!hPos.Equals(tPos) && dist>=2)
                {
                    tPos = oldHPos.Clone() as Position;
                }

                if (!visitedTailPositions.Contains(tPos))
                {
                    visitedTailPositions.Add(tPos);
                }
                
            }
            
        }
        Console.WriteLine("Result");
        Console.WriteLine(visitedTailPositions.Count);
    }

    public static (Directions, int) GetMovement(string line)
    {
        string[] lineArray = line.Split(" ");
        int length = Int32.Parse(lineArray[1]);
        Directions d = Directions.Up;
        
        switch (lineArray[0])
        {
            case "U":
                d = Directions.Up;
            break;
            case "D":
                d = Directions.Down;
            break;
            case "L":
                d = Directions.Left; 
            break;
            case "R":
                d = Directions.Right; 
            break;
        }

        return (d, length);

    }
    

}