using TaquinPuzzle.Model;

namespace TaquinPuzzle;

public partial class Form1 : Form
{
    private Grid _grid { get; set; }

    public Form1()
    {
        InitializeComponent();
    }

    #region Events

    private void numericGridSize_ValueChanged(object sender, EventArgs e)
    {
        numericNbAgents.Maximum = numericGridSize.Value * numericGridSize.Value - 1 ;
    }

    private void btnRun_Click(object sender, EventArgs e)
    {
        _grid = new Grid((int)numericGridSize.Value, (int)numericNbAgents.Value);
        drawGrid();
    }

    #endregion

    #region Drawing grid

    private void drawGrid()
    {
        panelGrid.Refresh();

        Graphics graph = panelGrid.CreateGraphics();
        Pen penIs = new Pen(Brushes.Black, 1);

        int lines = (int)numericGridSize.Value;
        float x = 0;
        float y = 0;
        float xSpace = panelGrid.Width / lines;
        float ySpace = panelGrid.Height / lines;

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

    #endregion
}