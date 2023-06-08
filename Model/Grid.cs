namespace TaquinPuzzle.Model;

public class Grid
{
    public int Size { get; set; }
    public List<Agent> Agents { get; set; } = new();

    public Grid(int size, int nbAgents)
    {
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
