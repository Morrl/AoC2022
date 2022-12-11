using System.Reflection.Metadata.Ecma335;

namespace Dec8;

public class Part1
{
    public static void Calculate()
    {
        Console.WriteLine("Part1");
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
        //Get trees from border
        result += nRows * 2;
        result += nCols * 2;
        //dont count corners twise
        result -= 4;

        for (int i = 1; i < nRows-1; i++)
        {
            for (int j = 1; j < nCols-1; j++)
            {
                if (IsTreeVisible(treeGrid, i, j))
                {
                    result++;
                }
            }
        }
        
        return result;
    }

    private static bool IsTreeVisible(int[,] treeGrid, int row, int col)
    {
        int tree = treeGrid[row, col];
        int up = row - 1;
        int down = row + 1;
        int left = col - 1;
        int right = col + 1;
        int lastRow = treeGrid.GetLength(0);
        int lastCol = treeGrid.GetLength(1);

        bool visibleFromUp = true;
        bool visibleFromDown = true;
        bool visibleFromLeft = true;
        bool visibleFromRight = true;

        while (up>-1)
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
        while (left>-1)
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

        return up < 0 || down > lastRow-1 || left < 0 || right > lastCol-1;
    }


}