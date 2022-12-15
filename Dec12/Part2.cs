namespace Dec12;

public class Part2
{
    public static void Calculate()
    {
        Console.WriteLine("Part2");

        (Terrain terain, Position start, Position end) = TerrainParser.ParseInput("Sample.txt", 'E', 'S');
        Explorer explorer = new Explorer(terain, start);
        Position currentPosition = new Position();
        
        
        
        while (explorer.IsExploring())
        {
            currentPosition = explorer.Explore();
            if (terain.Heights[currentPosition.Row,currentPosition.Col] == terain.Heights[end.Row,end.Col])
            {
                break;
            }
        }
        Console.WriteLine("Heights");
        // DisplayMap(terain.Heights);
        
        Console.WriteLine("Distances");
        // DisplayMap(explorer.Distances);
        
        Console.WriteLine("Result");
        Console.WriteLine(explorer.DistanceTo(currentPosition));

    }
    public static void DisplayMap(int[,] map)
    {
        for (int row = 0; row < map.GetLength(0); row++)
        {
            for (int col = 0; col < map.GetLength(1); col++)
            {
                string separator = ",";
                if (col == map.GetLength(1)-1)
                {
                    separator = ";";
                }
                Console.Write($"{map[row, col]}{separator}");

            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}