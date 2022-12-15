namespace Dec12;

public static class TerrainParser
{
    public static (Terrain terrain, Position start, Position end) ParseInput(string inputFile, char startChar,
        char endChar)
    {
        var lines = File.ReadAllLines(inputFile).ToList();
        int[,] heights = new int[lines.Count, lines.First().Length];
        Position start = new Position();
        Position end = new Position();

        //Build grid
        
        for (int row = 0; row < lines.Count; row++)
        {
            for (int col = 0; col < lines[row].Length; col++)
            {
                heights[row, col] = lines[row][col] - 'a';
 
                if (lines[row][col] == 'S')
                {
                    heights[row, col] = 0;
                }
                
                if (lines[row][col] == 'E')
                {
                    heights[row, col] = 'z' - 'a';
                }
                if (lines[row][col]  == startChar)
                {
                    start = new Position(row, col);
                }

                if (lines[row][col] == endChar)
                {
                    end = new Position(row, col);
                }
            }
        }

        Terrain t = new Terrain(heights);
        
        return (t,start,end);
    }
}