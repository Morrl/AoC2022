namespace Dec8;

public class Part2
{
public static void Calculate()
    {
        Console.WriteLine("Part2");
        string treesInput = File.ReadAllText("Input.txt");

        var treeGrid = GetTreeGrid(treesInput);

        var result = CalculateNumberOfVisibleTrees(treeGrid);

        Console.WriteLine("Result");
        Console.WriteLine(result);


    }

    private static int[,] GetTreeGrid(string input)
    {
        List<string> rows = input.Split("\r\n").ToList();
        
        int[,] treegrid = new int[rows.Count, rows.First().Length];

        for (int i = 0; i < rows.Count; i++)
        {
            for (int j = 0; j < rows[i].Length; j++)
            {
                string tmp = rows[i][j].ToString();
                
                treegrid[i, j] = Int32.Parse(tmp);
            }
        }
            
        
        return treegrid;
    }

    private static int CalculateNumberOfVisibleTrees(int[,] treeGrid)
    {
        
        int result = 0;
        int nRows = treeGrid.GetLength(0);
        int nCols = treeGrid.GetLength(1);

        
        for (int i = 0; i < nRows; i++)
        {
            for (int j = 0; j < nCols; j++)
            {
                int scenicScore = GetScenicScore(treeGrid, i, j);
                if (scenicScore > result)
                {
                    result = scenicScore;
                }
            }
        }
        
        return result;
    }

    
    public static int GetScenicScore(int[,] treeGrid, int row, int col)
    {
        
        int tree = treeGrid[row, col];
        int up = row - 1;
        int down = row + 1;
        int left = col - 1;
        int right = col + 1;
        int lastRow = treeGrid.GetLength(0)-1;
        int lastCol = treeGrid.GetLength(1)-1;

        if (row == 0)
        {
            up = 0;
        }

        if (row == lastRow)
        {
            down = 0;
        }

        if (col == 0)
        {
            left = 0;
        }

        if (col == lastCol)
        {
            right = lastCol;
        }
        
        while (up>-0)
        {
            if (treeGrid[up, col]>=tree)
            {
                break;
            }
            up--;
        }
        while (down<lastRow)
        {
            if (treeGrid[down, col]>=tree)
            {
                break;
            }
            down++;
        }
        while (left>0)
        {
            if (treeGrid[row, left]>=tree)
            {
                break;
            }
            left--;
        }
        while (right<lastCol)
        {
            if (treeGrid[row, right]>=tree)
            {
                break;
            }
            right++;
        }
        
        // return up < 0 || down > lastRow-1 || left < 0 || right > lastCol-1;

        int up2 = row - up;
        int down2 = down - row;
        int left2 = col - left;
        int right2 = right - col;

        if (up2 <= 0)
        {
            up2 = 1;
        }
        if (down2 > lastRow)
        {
            down2 = lastRow;
        }
        if (left2 <= 1)
        {
            left2 = 1;
        }
        if (right2 >= lastCol)
        {
            right2 = lastCol;
        }
        
        return up2 * down2 * left2 * right2;
    }
}