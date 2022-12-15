namespace Dec12;

public class Explorer
{
    public Terrain Map { get; }
    public Position Start { get; }
    public Queue<Position> ExplorationQueue { get; private set; }
    public int[,] Distances;

    public Explorer(Terrain terrain, Position start)
    {
        this.Map = terrain;
        this.Start = start;
        this.Distances = new int[Map.Rows, Map.Columns];
        
        //Initialize distances
        for (int r = 0; r < Map.Rows; r++)
        {
            for (int c = 0; c < Map.Columns; c++)
            {
                Distances[r, c] = -1;
            }
        }

        Distances[start.Row, start.Col] = 0;
        ExplorationQueue = new Queue<Position>();
        ExplorationQueue.Enqueue(start);



    }

    public int DistanceTo(Position p)
    {
        return Distances[p.Row, p.Col];
    }

    public bool IsExploring()
    {
        return ExplorationQueue.Count > 0;
    }

    public Position Explore()
    {
        // If there is nothing left in the ExplorationQueue
        // there is nothing left to do.
        if (ExplorationQueue.Count == 0)
        {
            throw new Exception("Nothing left to explore!");
        }

        Position exploringPosition = ExplorationQueue.Dequeue();
        var neighbours = Map.FindNeighbours(exploringPosition);
        
        foreach (var neighbour in neighbours)
        {
            if(Distances[neighbour.Row,neighbour.Col] == -1)
            {
                Distances[neighbour.Row, neighbour.Col] = Distances[exploringPosition.Row, exploringPosition.Col] + 1;
                ExplorationQueue.Enqueue(neighbour);
            }
        }

        return exploringPosition;
    }
    
}