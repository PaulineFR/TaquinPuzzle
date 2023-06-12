namespace TaquinPuzzle.Model;

public class Message
{
    public Agent Sender { get; set; } = new();
    public Agent Receiver { get; set; } = new();
    public Action Action { get; set; }

}
