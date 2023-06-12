namespace TaquinPuzzle.Model;

public class Agent
{
    public int Id { get; set; }
    public Coordinates Position { get; set; }
    public Coordinates Target { get; set; }
    public Grid Grid { get; set; }
    public Color Color { get; set; }
    public List<Agent> Others { get { return Grid.Agents.Where(a => a.Id != this.Id).ToList(); } }


    #region public methods

    public void Run(int stepTime)
    {
        while (Position.Equals(Target))
        {
            Grid.Mutex.WaitOne();
            bool hasMoved = Move();
            if (hasMoved)
            {
                Thread.Sleep(stepTime);
            }
            Grid.Mutex.ReleaseMutex();
        }
    }

    public bool Move()
    {
        var availablePositions = Grid.GetAvailablePositionsAround(Position);
        foreach (var nextPosition in availablePositions)
        {
            if (GetDistanceBetween(nextPosition, Target) < GetDistanceToTarget())
            {
                Position = nextPosition;
                return true;
            }
        }
        return false;
    }

    #endregion


    #region private methods
    private static int GetDistanceBetween(Coordinates a, Coordinates b)
    {
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }

    private int GetDistanceToTarget()
    {
        return GetDistanceBetween(Position, Target);
    }
    #endregion
}
