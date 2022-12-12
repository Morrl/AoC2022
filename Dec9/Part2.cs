namespace Dec9;

public class Part2
{
public static void Calculate()
    {
        Console.WriteLine("Part2");

        var lines = File.ReadAllLines("Input.txt").ToList();

        var knots = new List<Position>();
        for (int i = 0; i < 10; i++)
        {
            knots.Add(new Position());
        }

        Position tPos = knots.Last();
        Position hPos = knots.First();
        // Position tempPos = new Position();
        Position aheadOldPos = new Position();

        List<Position> visitedTailPositions = new List<Position>();
        visitedTailPositions.Add(tPos.Clone() as Position);

        foreach (var line in lines)
        {
            var movement = GetMovement(line);
            Directions d = movement.Item1;
            int length = movement.Item2;

            for (int i = 0; i < length; i++)
            {
                
                
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

                
                for (var j = 1; j < knots.Count; j++)
                {
                    // var knot = knots[j];
                    // var aheadPos = knots[j - 1];
                    // double dist = knot.DistanceTo(aheadPos);
                    // if (!knot.Equals(aheadPos) && dist >= 2)
                    // {
                    //     // knots[j] = aheadOldPos.Clone() as Position;
                    //     knots[j].SetPosition(aheadPos.OldPosition);
                    //
                    //
                    // }
                    var head = knots[j - 1];
                    var currentPosition = knots[j].Clone() as Position;

                    if (Math.Abs(head.X - currentPosition.X) > 1 || Math.Abs(head.Y - currentPosition.Y) > 1)
                    {
                        if (head.X != currentPosition.X)
                        {
                            var xDiff = (head.X - currentPosition.X) / Math.Abs(head.X - currentPosition.X);
                            currentPosition.X += xDiff;
                        }

                        if (head.Y != currentPosition.Y)
                        {
                            var yDiff = (head.Y - currentPosition.Y) / Math.Abs(head.Y - currentPosition.Y);
                            currentPosition.Y += yDiff;
                        }
                    }
                    knots[j] = currentPosition;

                    if (j == 9)
                    {
                        var t = knots[9].Clone() as Position;
                        
                        if (!visitedTailPositions.Contains(t))
                        {
                            visitedTailPositions.Add(t);
                        }
                    }
                    
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