namespace TaquinPuzzle.Model;

public class Grid
{
    public Form1 Display { get; set; }
    public int Size { get; set; }
    public bool Solved { get { return Agents.All(a => a.Position.Equals(a.Target)); } }
    public List<Agent> Agents { get; set; } = new();
    public Mutex Mutex { get; } = new();

    public Grid(int size, int nbAgents, Form1 form)
    {
        Display = form;
        Size = size;

        Random rnd = new();
        List<Coordinates> remainingPositions = listAllCoordinates();
        List<Coordinates> remainingTargets = listAllCoordinates();
        for (int i = 0; i < nbAgents; i++)
        {
            Coordinates position = remainingPositions[rnd.Next(0, remainingPositions.Count)];
            Coordinates target = remainingTargets[rnd.Next(0, remainingPositions.Count)];
            Agents.Add(new() { Id = i, Position = position, Target = target, Grid = this });
            remainingPositions.Remove(position);
            remainingTargets.Remove(target);
        }

    }

    #region Public methods

    /// <summary>
    ///     Solve the puzzle
    /// </summary>
    /// <param name="stepTime">time of a step (ms)</param>
    public void Solve(int stepTime)
    {
        foreach (var agent in Agents)
        {
            new Thread(() => agent.RunAsync(stepTime)).Start();
        }
    }

    public void Repaint()
    {
        Display.Invoke(new MethodInvoker(delegate
        {
            Display.DrawGrid();
        }));
    }

    public List<Tuple<Coordinates, bool>> GetAvailablePositionsAround(Coordinates pos)
    {
        var nearbyPositions = new List<Tuple<Coordinates, bool>>();
        if (pos.X > 0)
        {
            Coordinates newPos = new() { X = pos.X - 1, Y = pos.Y };
            nearbyPositions.Add(new(newPos, !Agents.Any(a => a.Position.Equals(newPos))));
        }
        if (pos.X < Size - 1)
        {
            Coordinates newPos = new() { X = pos.X + 1, Y = pos.Y };
            nearbyPositions.Add(new(newPos, !Agents.Any(a => a.Position.Equals(newPos))));
        }
        if (pos.Y > 0)
        {
            Coordinates newPos = new() { X = pos.X, Y = pos.Y - 1 };
            nearbyPositions.Add(new(newPos, !Agents.Any(a => a.Position.Equals(newPos))));
        }
        if (pos.Y < Size - 1)
        {
            Coordinates newPos = new() { X = pos.X, Y = pos.Y + 1 };
            nearbyPositions.Add(new(newPos, !Agents.Any(a => a.Position.Equals(newPos))));
        }

        return nearbyPositions;
    }

    #endregion

    #region Private methods

    private List<Coordinates> listAllCoordinates()
    {
        List<Coordinates> coordinates = new List<Coordinates>();
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                coordinates.Add(new() { X = i, Y = j });
            }
        }
        return coordinates;
    }

    #endregion
}
