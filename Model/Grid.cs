namespace TaquinPuzzle.Model;

public class Grid
{
    public Form1 Display { get; set; }
    public int Size { get; set; }
    public List<Agent> Agents { get; set; } = new();

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
        while (!Agents.All(a => a.Position.Equals(a.Target)))
        {
            foreach (var agent in Agents)
            {
                if (agent.Move())
                {
                    Thread.Sleep(stepTime);
                    Display.DrawGrid();
                }
            }
        }
    }

    public List<Coordinates> GetAvailablePositionsAround(Coordinates pos)
    {
        var nearbyPositions = new List<Coordinates>();
        if (pos.X > 0)
            nearbyPositions.Add(new() { X = pos.X - 1, Y = pos.Y });
        if (pos.X < Size - 1)
            nearbyPositions.Add(new() { X = pos.X + 1, Y = pos.Y });
        if (pos.Y > 0)
            nearbyPositions.Add(new() { X = pos.X, Y = pos.Y - 1 });
        if (pos.Y < Size - 1)
            nearbyPositions.Add(new() { X = pos.X, Y = pos.Y + 1 });

        foreach (var agent in Agents)
        {
            nearbyPositions.RemoveAll(p => p.Equals(agent.Position));
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
