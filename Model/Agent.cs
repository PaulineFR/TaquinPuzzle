using AStar;
using AStar.Options;
using System.Threading.Channels;

namespace TaquinPuzzle.Model;

public class Agent
{
    public int Id { get; set; }
    public Coordinates Position { get; set; }
    public Coordinates Target { get; set; }
    public Grid Grid { get; set; }
    public Color Color { get; set; }
    public List<Agent> Others { get { return Grid.Agents.Where(a => a.Id != this.Id).ToList(); } }
    public Channel<Message> MailBox { get; } = Channel.CreateUnbounded<Message>();


    #region public methods

    public async Task RunAsync(int stepTime)
    {
        //while (!Position.Equals(Target))
        while (!Grid.Solved)
        {
            Grid.Mutex.WaitOne();
            if (!Position.Equals(Target) || MailBox.Reader.Count > 0)
            {
                await MoveAsync(stepTime);
            }
            Grid.Mutex.ReleaseMutex();
        }
    }

    public async Task<bool> MoveAsync(int stepTime)
    {
        Random rnd = new();

        var availablePositions = Grid.GetAvailablePositionsAround(Position);

        Message? message = null;
        if (MailBox.Reader.Count > 0)
            message = await MailBox.Reader.ReadAsync();

        while (availablePositions.Any())
        {
            var nextPosition = availablePositions.ElementAt(rnd.Next(availablePositions.Count));
            if (message != null || GetDistanceBetween(nextPosition.Item1, Target) < GetDistanceToTarget())
            {
                if (nextPosition.Item2)
                {
                    Thread.Sleep(stepTime);
                    Position = nextPosition.Item1;
                    Grid.Repaint();
                    return true;
                }
                else
                {
                    var agent = Grid.Agents.FirstOrDefault(a => a.Position.Equals(nextPosition.Item1));
                    //agent = Grid.Agents[1];
                    if (agent != null)
                        agent.MailBox.Writer.TryWrite(new Message() { Sender = this, Receiver = agent, Action = Action.North });
                    return false;
                }
            }
            availablePositions.Remove(nextPosition);

        }
        return false;

    }

    #endregion


    #region private methods
    //private int GetDistanceBetween(Coordinates a, Coordinates b)
    //{
    //    var pathFinderOptions = new PathFinderOptions
    //    {
    //        PunishChangeDirection = true,
    //        UseDiagonals = false
    //    };

    //    short[,] tiles = new short[Grid.Size, Grid.Size];
    //    for (int i = 0; i < Grid.Size; i++)
    //    {
    //        for (int j = 0; j < Grid.Size; j++)
    //        {
    //            tiles[i, j] = (short)(Grid.Agents.Any(a => a.Position.Equals(new Coordinates { X = i, Y = j })) ? 0 : 1);
    //        }
    //    }
    //    tiles[a.X, a.Y] = 1;
    //    tiles[b.X, b.Y] = 1;

    //    var worldGrid = new WorldGrid(tiles);
    //    var pathFinder = new PathFinder(worldGrid, pathFinderOptions);

    //    Point[] path = pathFinder.FindPath(new Point(a.X, a.Y), new Point(b.X, b.Y));
    //    var ret = path.Length;
    //    return ret;
    //}

    private int GetDistanceBetween(Coordinates a, Coordinates b)
    {
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }

    private int GetDistanceToTarget()
    {
        return GetDistanceBetween(Position, Target);
    }
    #endregion
}
