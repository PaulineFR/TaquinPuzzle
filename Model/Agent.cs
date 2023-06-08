namespace TaquinPuzzle.Model;

public class Agent
{
    public int Id { get; set; }
    public Coordinates Position { get; set; }
    public Coordinates Target { get; set; }
    public Grid Grid { get; set; }
    public List<Agent> Others { get { return Grid.Agents.Where(a => a.Id != this.Id).ToList(); } }
}
