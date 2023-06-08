namespace TaquinPuzzle.Model;

public class Coordinates
{
    public int X { get; set; }
    public int Y { get; set; }

    public bool Equals(Coordinates other)
    {
        return X == other.X && Y == other.Y;
    }
}
