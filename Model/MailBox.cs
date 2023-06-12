namespace TaquinPuzzle.Model;

public class MailBox
{
    public Dictionary<Agent, List<Message>> Messages { get; set; }
    public Grid Grid { get; set; }

    public MailBox(Grid grid) { 
        Grid = grid;
        Messages = new();
        foreach(Agent ag in Grid.Agents)
        {
            Messages.Add(ag, new());
        }
    }
}
