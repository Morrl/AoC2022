namespace Dec12;

public class Terrain
{
    public int[,] Heights;

    public Terrain(int[,] heights)
    {
        Heights = heights;
    }

    public int Rows => Heights.GetLength(0);
    public int Columns => Heights.GetLength(1);

    public List<Position> FindNeighbours(Position p)
    {
        List<Position> neighbours = new List<Position>();
        
        foreach (var neighbour in p.GetNeighbours())
        {
            if (PositionWithinMap(neighbour) && IsMoveValid(p,neighbour))
            {
                neighbours.Add(neighbour);
            }
            
        }

        return neighbours;
    }

    public bool PositionWithinMap(Position p)
    {
        return p.Row >= 0 && p.Col >= 0 && p.Row < this.Rows && p.Col < this.Columns;
    }
    
    public bool IsMoveValid(Position from, Position to)
    {
        if (!PositionWithinMap(from) || !PositionWithinMap(to))
        {
            return false;
        }

        int fromHeight = Heights[from.Row, from.Col];
        int toHeight = Heights[to.Row, to.Col];

        return toHeight <= fromHeight -1;

    }
    

}