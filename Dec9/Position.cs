namespace Dec9;

public class Position : ICloneable
{
    private int _x;
    private int _y;
    public int X {
        get => _x;
        set
        {
            OldPosition = new Position(_x, _y);
            _x = value;
        }
    }
    public int Y
    {
        get => _y;
        
        set
        {
            OldPosition = new Position(_x, _y);
            _y = value;
        }
    }
    public Position OldPosition { get; set; }

    public Position()
    {
        _x = 0;
        _y = 0;
    }

    public Position(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public override bool Equals(object? obj)
    {
        if (!(obj is Position))
        {
            return false;
        }

        var p = obj as Position;
        return p.X == X && p.Y == Y;


    }

    public Double DistanceTo(Position p)
    {
        return Math.Sqrt(Math.Pow(p.X - X, 2) + Math.Pow(p.Y - Y, 2));
    }

    public void SetPosition(Position p)
    {
        OldPosition = new Position(_x, _y);
        _x = p._x;
        _y = p._y;
    }

    public override string ToString()
    {
        return $"X={_x} Y={_y}";
    }
    
    
}