using System.Drawing;
using System.Windows.Forms.Design;
using System.Xml;
using TaquinPuzzle.Model;

namespace TaquinPuzzle;

public partial class Form1 : Form
{
    private Grid _grid { get; set; }
    private List<Color> colorList = new List<Color>();

    public Form1()
    {
        InitializeComponent();
    }

    #region Events

    private void numericGridSize_ValueChanged(object sender, EventArgs e)
    {
        numericNbAgents.Maximum = numericGridSize.Value * numericGridSize.Value - 1;
    }

    private void btnRun_Click(object sender, EventArgs e)
    {
        _grid = new Grid((int)numericGridSize.Value, (int)numericNbAgents.Value, this);

        _grid.Agents.ForEach(agent =>
        {
            agent.Color = getNewRandomColor();
        });
        DrawGrid();
    }

    private void solveButton_Click(object sender, EventArgs e)
    {
        _grid.Solve(500);
        while (!_grid.Solved)
        {
            DrawGrid();
            Thread.Sleep(250);
        }
    }

    #endregion

    #region Drawing grid

    public void DrawGrid()
    {
        panelGrid.Refresh();

        Graphics graph = panelGrid.CreateGraphics();
        Pen penIs = new Pen(Brushes.Black, 1);

        int lines = (int)numericGridSize.Value;
        float x = 0;
        float y = 0;
        float xSpace = (float)panelGrid.Width / lines;
        float ySpace = (float)panelGrid.Height / lines;

        // draw targets
        _grid.Agents.ForEach(agent =>
        {
            graph.FillRectangle(new SolidBrush(agent.Color), agent.Target.X * xSpace, agent.Target.Y * ySpace, (int)xSpace, (int)ySpace);

        });

        // draw agents
        _grid.Agents.ForEach(agent =>
        {
            graph.FillEllipse(new SolidBrush(agent.Color), new Rectangle(agent.Position.X * (int)xSpace + agent.Position.X/2, agent.Position.Y * (int)ySpace + agent.Position.Y/2, (int)xSpace, (int)ySpace));
            graph.DrawEllipse(penIs, new Rectangle(agent.Position.X * (int)xSpace + agent.Position.X/2, agent.Position.Y * (int)ySpace + agent.Position.Y/2, (int)xSpace, (int)ySpace));
        });


        // vertical lines
        for (int i = 0; i < lines + 1; i++)
        {
            graph.DrawLine(penIs, x, y, x, panelGrid.Height);
            x += xSpace;

        }

        // vertical lines
        x = 0;
        for (int i = 0; i < lines + 1; i++)
        {
            graph.DrawLine(penIs, x, y, panelGrid.Width, y);
            y += ySpace;

        }

    }
    private Color getNewRandomColor()
    {
        // Sets a random color for the truck, this function has been extracted to be more readable
        Random random = new Random();
        Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        while (this.colorList.Contains(randomColor))
        {
            randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }
        this.colorList.Add(randomColor);

        return randomColor;
    }

    #endregion
}