namespace Dec12;

public class Position
{
    public int Row { get; set; }
    public int Col { get; set; }

    public Position()
    {
        Row = 0;
        Col = 0;
    }

    public Position(int row, int col)
    {
        Row = row;
        Col = col;
    }

    public Position North => new Position(Row - 1, Col);
    public Position South => new Position(Row + 1, Col);
    public Position West => new Position(Row, Col - 1);
    public Position East => new Position(Row, Col + 1);

    public List<Position> GetNeighbours()
    {
        return new List<Position>() { North, South, West, East };
    }

    public override string ToString()
    {
        return $"Row {Row} Col {Col}";
    }

    public override bool Equals(object? obj)
    {
        Position other = obj as Position;
        return other.Row == Row && other.Col == Col;
    }
}