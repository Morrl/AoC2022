using System.Security.Cryptography.X509Certificates;

namespace Dec12;

public class Part1
{
    public static void Calculate()
    {
        Console.WriteLine("Part1");

        (Terrain terain, Position start, Position end) = TerrainParser.ParseInput("Input.txt", 'S', 'E');
        Explorer explorer = new Explorer(terain, start);
        Position currentPosition = new Position();
        
        
        
        while (explorer.IsExploring())
        {
            currentPosition = explorer.Explore();
            if (currentPosition.Equals(end))
            {
                break;
            }
        }
        Console.WriteLine("Heights");
        // DisplayMap(terain.Heights);
        
        Console.WriteLine("Distances");
        // DisplayMap(explorer.Distances);
        
        Console.WriteLine("Result");
        Console.WriteLine(explorer.DistanceTo(end));

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

